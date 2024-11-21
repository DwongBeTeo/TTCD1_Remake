using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using K22CNT2_TDD_2210900097_Remake.Models;

namespace K22CNT2_TDD_2210900097_Remake.Controllers
{
    public class TDD_SAN_PHAMController : Controller
    {
        private K22CNT2_TDD_ShoppingCartDbEntities db = new K22CNT2_TDD_ShoppingCartDbEntities();

        // GET: TDD_SAN_PHAM
        public ActionResult Index(string Search ="")
        {
            List<SAN_PHAM> sp= db.SAN_PHAM.Where(i => i.TenSanPham.Contains(Search)).ToList();
            ViewBag.SAN_PHAM = Search;
            return View(sp);
        }

        // GET: TDD_SAN_PHAM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAN_PHAM sAN_PHAM = db.SAN_PHAM.Find(id);
            if (sAN_PHAM == null)
            {
                return HttpNotFound();
            }
            return View(sAN_PHAM);
        }

        // GET: TDD_SAN_PHAM/Create
        public ActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(db.LOAI_SAN_PHAM, "ID", "MaLoai");
            return View();
        }

        // POST: TDD_SAN_PHAM/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MaSanPham,TenSanPham,HinhAnh,SoLuong,DonGia,MaLoai,TrangThai")] SAN_PHAM sAN_PHAM)
        {
            if (ModelState.IsValid)
            {
                db.SAN_PHAM.Add(sAN_PHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoai = new SelectList(db.LOAI_SAN_PHAM, "ID", "MaLoai", sAN_PHAM.MaLoai);
            return View(sAN_PHAM);
        }

        // GET: TDD_SAN_PHAM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAN_PHAM sAN_PHAM = db.SAN_PHAM.Find(id);
            if (sAN_PHAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoai = new SelectList(db.LOAI_SAN_PHAM, "ID", "MaLoai", sAN_PHAM.MaLoai);
            return View(sAN_PHAM);
        }

        // POST: TDD_SAN_PHAM/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MaSanPham,TenSanPham,HinhAnh,SoLuong,DonGia,MaLoai,TrangThai")] SAN_PHAM sAN_PHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sAN_PHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(db.LOAI_SAN_PHAM, "ID", "MaLoai", sAN_PHAM.MaLoai);
            return View(sAN_PHAM);
        }

        // GET: TDD_SAN_PHAM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAN_PHAM sAN_PHAM = db.SAN_PHAM.Find(id);
            if (sAN_PHAM == null)
            {
                return HttpNotFound();
            }
            return View(sAN_PHAM);
        }

        // POST: TDD_SAN_PHAM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SAN_PHAM sAN_PHAM = db.SAN_PHAM.Find(id);
            db.SAN_PHAM.Remove(sAN_PHAM);
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
