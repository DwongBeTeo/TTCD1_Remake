using K22CNT2_TDD_2210900097_Remake.Bussiness;
using K22CNT2_TDD_2210900097_Remake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT2_TDD_2210900097_Remake.Controllers
{
    public class TDDCartController : Controller
    {
        private const string TDDCartSessionKey = "TDDCartSessionKey";
        K22CNT2_TDD_ShoppingCartDbEntities dbEntities = new K22CNT2_TDD_ShoppingCartDbEntities();
        
        private TDD_ShoppingCart GetCart()
        {
            var cart = Session[TDDCartSessionKey] as TDD_ShoppingCart;
            if (cart == null)
            {
                cart = new TDD_ShoppingCart();
                Session[TDDCartSessionKey] = cart;
            }
            return cart;
        }
        //add to cart: thêm 1 sản phẩm vào giỏ hàng
        public ActionResult AddToCart(int id, string TenSanPham, string HinhAnh, int SoLuongMua, float DonGiaMua ) 
        {
            var cart =GetCart();
            var item = new TDDCartItem
            {
                ID = id,
                TenSanPham = TenSanPham,
                HinhAnh = HinhAnh,
                SoLuongMua = SoLuongMua,
                DonGiaMua = DonGiaMua,
                ThanhTien = SoLuongMua * DonGiaMua
            };
            cart.AddToCart(item);
            return RedirectToAction("Index");
        }
        // GET: TDDCart --hiển thị các sản phẩm trong giỏ hàng

        public ActionResult Index()
        {
            var cart = GetCart();
            return View(cart.Items);
        }
        //Trang Thong TIn Thanh Toan
        public ActionResult ThongTinThanhToan()
        {
            var cart = GetCart();
            ViewBag.TongGiaTri = cart.GetTongThanhTien();
            DateTime dt = DateTime.Now;
            var MaHoaDOn = "DH-" + dt.ToString("yyyyMMdd-HHmmss");
            ViewBag.MaHoaDon = MaHoaDOn;
            return View(cart.Items);
        }
        // cập nhật và thanh toán
        public ActionResult ThanhToan(FormCollection form)
        {
            var cart = GetCart();
            //Lấy các thông tin trên from để update bảng hóa đơn
            var HoTenKhachHang = form["HoTenKhachHang"];
            var Email = form["Email"];
            var DienThoai = form["DienThoai"];
            var DiaChi = form["DiaChi"];
            //Thong tin don hang
            DateTime dt = DateTime.Now;
            var MaHoaDOn = "DH-" + dt.ToString("yyyyMMdd-HHmmss");
            var NgayNhan = form["NgayNhan"];
            var TongGiaTri = cart.GetTongThanhTien();
            var khachHang = Session["DangNhap"] as KHACH_HANG;
            int maKhach = khachHang != null ? khachHang.ID : 1;

            //Thêm mới vào bảng hóa đơn 
            var hoaDon = new HOA_DON();
            hoaDon.MaHoaDon=MaHoaDOn;
            hoaDon.MaKhachHang = maKhach;
            hoaDon.NgayHoaDon = dt;
            hoaDon.NgayNhan = DateTime.Parse(NgayNhan);
            hoaDon.TongGiaTri = TongGiaTri;
            hoaDon.HoTenKhachHang = HoTenKhachHang;
            hoaDon.Email = Email;
            hoaDon.DienThoai=DienThoai;
            hoaDon.DiaChi = DiaChi;
            hoaDon.TrangThai = 0;

            dbEntities.HOA_DON.Add(hoaDon);
            dbEntities.SaveChanges();

            //lấy id hóa đơn vừa thêm
            int hoaDonId= dbEntities.HOA_DON.Max(x => x.ID);
            //Theme vào chi tiết hóa đơn

            foreach (var item in cart.Items)
            {
                CT_HOA_DON ct = new CT_HOA_DON();
                ct.HoaDonID = hoaDonId;
                ct.SanPhamID = item.ID;
                ct.SoLuongMua = item.SoLuongMua;
                ct.DonGiaMua = item.DonGiaMua;
                ct.ThanhTien = item.ThanhTien;
                dbEntities.CT_HOA_DON.Add(ct);
                dbEntities.SaveChanges ();
            }
            Session[TDDCartSessionKey] = null;
            return RedirectToAction("CamOn");
        }
        public ActionResult CamOn()
        {
            return View();
        }
        //cập nhật giỏ hàng
        public ActionResult UpdateFromCart(FormCollection form)
        {
            var cart = GetCart();
            var ids = form["ID"].Split(',');
            var qtys = form["SoLuongMua"].Split(',');
            for (int i = 0; i < ids.Length; i++)
            {
                int id=int.Parse(ids[i]);
                int qty =int.Parse(qtys[i]);
                cart.UpdateFromCart(id, qty);
            }
            return RedirectToAction("Index");
        }

        //cập nhật item in cart
        public ActionResult UpdateItemCart(int id,int qty)
        {
            var cart = GetCart();
            cart.UpdateFromCart(id,qty);
            return RedirectToAction("Index");
        }
        //xóa sản phẩm trong giỏ hàng
        public ActionResult DeleteItemCart(int id)
        {
            var cart = GetCart();
            cart.RemoveToCart(id);
            return RedirectToAction("Index");
        }
    }
}