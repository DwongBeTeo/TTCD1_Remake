using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using K22CNT2_TDD_2210900097_Remake.Models;

namespace K22CNT2_TDD_2210900097_Remake.Areas.TDDAdmin.Controllers
{
    public class AdminHOA_DONController : Controller
    {
        private K22CNT2_TDD_ShoppingCartDbEntities db = new K22CNT2_TDD_ShoppingCartDbEntities();

        // GET: TDDAdmin/AdminHOA_DON
        public ActionResult Index()
        {
            var hOA_DON = db.HOA_DON.Include(h => h.KHACH_HANG);
            return View(hOA_DON.ToList());
        }

        // GET: TDDAdmin/AdminHOA_DON/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOA_DON hOA_DON = db.HOA_DON.Find(id);
            if (hOA_DON == null)
            {
                return HttpNotFound();
            }
            return View(hOA_DON);
        }

        // GET: TDDAdmin/AdminHOA_DON/Create
        public ActionResult Create()
        {
            ViewBag.MaKhachHang = new SelectList(db.KHACH_HANG, "ID", "MaKhachHang");
            return View();
        }

        // POST: TDDAdmin/AdminHOA_DON/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MaHoaDon,MaKhachHang,NgayHoaDon,NgayNhan,HoTenKhachHang,Email,DienThoai,DiaChi,TongGiaTri,TrangThai")] HOA_DON hOA_DON)
        {
            if (ModelState.IsValid)
            {
                db.HOA_DON.Add(hOA_DON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKhachHang = new SelectList(db.KHACH_HANG, "ID", "MaKhachHang", hOA_DON.MaKhachHang);
            return View(hOA_DON);
        }

        // GET: TDDAdmin/AdminHOA_DON/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOA_DON hOA_DON = db.HOA_DON.Find(id);
            if (hOA_DON == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKhachHang = new SelectList(db.KHACH_HANG, "ID", "MaKhachHang", hOA_DON.MaKhachHang);
            return View(hOA_DON);
        }

        // POST: TDDAdmin/AdminHOA_DON/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MaHoaDon,MaKhachHang,NgayHoaDon,NgayNhan,HoTenKhachHang,Email,DienThoai,DiaChi,TongGiaTri,TrangThai")] HOA_DON hOA_DON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOA_DON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhachHang = new SelectList(db.KHACH_HANG, "ID", "MaKhachHang", hOA_DON.MaKhachHang);
            return View(hOA_DON);
        }

        // GET: TDDAdmin/AdminHOA_DON/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOA_DON hOA_DON = db.HOA_DON.Find(id);
            if (hOA_DON == null)
            {
                return HttpNotFound();
            }
            return View(hOA_DON);
        }

        // POST: TDDAdmin/AdminHOA_DON/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HOA_DON hOA_DON = db.HOA_DON.Find(id);
            db.HOA_DON.Remove(hOA_DON);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
