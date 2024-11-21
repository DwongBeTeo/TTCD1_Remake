using K22CNT2_TDD_2210900097_Remake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT2_TDD_2210900097_Remake.Controllers
{
    public class TDD_KHACH_HANGController : Controller
    {
        K22CNT2_TDD_ShoppingCartDbEntities dbEntities = new K22CNT2_TDD_ShoppingCartDbEntities();
        // GET: TDD_KHACH_HANG
        //Action:Dăng ký
        public ActionResult dang_ky()
        {
            return View();
        }

        //post dang_ky
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult dang_ky(FormCollection form)
        {
            try
            {
                //lấy thông tin đăng ký trên form
                var email = form["Email"];
                var hoTenKhachHang = form["HoTenKhachHang"];
                var matKhau = form["MatKhau"];
                var diaChi = form["DiaChi"];

                var khachHang = new KHACH_HANG();
                DateTime dt = DateTime.Now;
                khachHang.MaKhachHang = "KH" + dt.ToString("yyyyMMdd-HHmmss");
                khachHang.Email = email;
                khachHang.MatKhau = matKhau;
                khachHang.HoTenKhachHang = hoTenKhachHang;
                khachHang.DiaChi = diaChi;
                khachHang.NgayDangKy = dt;
                khachHang.TrangThai = 0;

                dbEntities.KHACH_HANG.Add(khachHang);
                dbEntities.SaveChanges();
                return RedirectToAction("RegisSuccess");
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }
        public ActionResult RegisSuccess()
        {
            return View();
        }
        public ActionResult dang_nhap()
        {
            return View();
        }

        //Post: dang_nhap
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult dang_nhap(FormCollection form)
        {
            //Lấy thông tin trên form
            var email = form["Email"];
            var matKhau = form["MatKhau"];
            var check = dbEntities.KHACH_HANG.Where(x=>x.Email.Equals(email) && x.MatKhau.Equals(matKhau)).FirstOrDefault();
            if (check != null) 
            {
                //Lưu Thông tin đăng nhập trong session
                Session["DangNhap"] =check;
                return Redirect("/");
            }
            else
            {
                ViewBag.error = "Lỗi Đăng Nhập";
                return View();
            }
        }
        //dang xuat
        public ActionResult dang_xuat()
        {
            Session["DangNhap"] = null;
            return Redirect("/");
        }
    }
}