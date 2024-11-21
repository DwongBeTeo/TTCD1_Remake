﻿using System;
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
    public class AdminSAN_PHAMController : Controller
    {
        private K22CNT2_TDD_ShoppingCartDbEntities db = new K22CNT2_TDD_ShoppingCartDbEntities();

        // GET: TDDAdmin/AdminSAN_PHAM
        public ActionResult Index()
        {
            var sAN_PHAM = db.SAN_PHAM.Include(s => s.LOAI_SAN_PHAM);
            return View(sAN_PHAM.ToList());
        }

        // GET: TDDAdmin/AdminSAN_PHAM/Details/5
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

        // GET: TDDAdmin/AdminSAN_PHAM/Create
        public ActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(db.LOAI_SAN_PHAM, "ID", "MaLoai");
            return View();
        }

        // POST: TDDAdmin/AdminSAN_PHAM/Create
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

        // GET: TDDAdmin/AdminSAN_PHAM/Edit/5
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

        // POST: TDDAdmin/AdminSAN_PHAM/Edit/5
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

        // GET: TDDAdmin/AdminSAN_PHAM/Delete/5
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

        // POST: TDDAdmin/AdminSAN_PHAM/Delete/5
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