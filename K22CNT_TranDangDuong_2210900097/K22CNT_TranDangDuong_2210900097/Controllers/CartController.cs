using K22CNT_TranDangDuong_2210900097.Bussiness;
using K22CNT_TranDangDuong_2210900097.Models;
using K22CNT_TranDangDuong_2210900097.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT_TranDangDuong_2210900097.Controllers
{
    public class CartController : Controller
    {
        private const string CartSessionKey = "ShoppingCart";
        K22CNT2_TDD_DB3Entities db = new K22CNT2_TDD_DB3Entities();
        private ShoppingCart GetCarts()
        {
            var cart = Session[CartSessionKey] as ShoppingCart;
            if (cart == null)
            {
                cart = new ShoppingCart();
                Session[CartSessionKey] = cart;
            }
            return cart;
        }
        public ActionResult AddToCart(int Id, string name, string image, float price, int qty)
        {
            var cart = GetCarts();
            var item = new CartItem
            {
                Id = Id,
                Name = name,
                Image = image,
                Price = price,
                Qty = qty,
                Total = price*qty
            };
            cart.AddToCart(item);
            return RedirectToAction("Index");
            // GET: Cart
            
        }
        public ActionResult UpdateToCart(int id,  int qty)
        {
            var cart = GetCarts();
            cart.UpdateToCart(id, qty);
            return RedirectToAction("Index");

        }
        // GET: Cart
        //Thêm sau
        //public ActionResult RemoveItemCart(int id)
        //{
        //    var cart = GetCarts();
        //    cart.RemoveItemCart(id);
        //    return RedirectToAction("Index");
        //}
        public ActionResult Index()
        {
            var cart = GetCarts();
            return View(cart);
        }
        //Action de thanh toan
        public ActionResult ThongTinThanhToan()
        {
            var cart = GetCarts();
            return View();
        }
        public ActionResult ThanhToan(FormCollection form)
        {
            //lay thong tin khach hang
            var ten_nguoi_nhan = form["Ten_Nguoi_Nhan"];
            var diachi_nguoi_nhan = form["Dia_Chi_Nhan"];
            var dienthoai_nguoi_nhan = form["Dien_Thoai_Nhan"];
            //tao don hang (thêm mới 1 đơn hàng vào bảng đơn hàng)
            DON_HANG don_Hang = new DON_HANG();
            DateTime dt = DateTime.Now;
            don_Hang.MaDH = "DH" + dt.ToString("yyyyMMdd-HHmmss"); 
            don_Hang.Ten_Nguoi_Nhan = ten_nguoi_nhan;
            don_Hang.Dia_Chi_Nhan = diachi_nguoi_nhan;
            don_Hang.Dien_Thoai_Nhan = dienthoai_nguoi_nhan;
            don_Hang.Ngay_dat = dt;
            don_Hang.Trang_thai = 0;
            db.DON_HANG.Add(don_Hang);
            db.SaveChanges();
            //lấy mã đơn hàng mới nhất để thêm vào CT_DON_HANG
            int maxID_DH = db.DON_HANG.Max(x=>x.ID);
            var cart = GetCarts();
            foreach (var item in cart.Items)
            {
                CT_DON_HANG ct = new CT_DON_HANG();
                ct.ID_DH = maxID_DH;
                ct.ID_SP = item.Id;
                ct.So_Luong=item.Qty;
                ct.Don_gia=item.Price;
                ct.Thanh_tien = item.Qty*item.Price;
                db.CT_DON_HANG.Add(ct);
                db.SaveChanges();
            }
            return Redirect("/");
        }
    }
}