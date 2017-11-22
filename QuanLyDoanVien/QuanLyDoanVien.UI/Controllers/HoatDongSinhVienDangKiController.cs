using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyDoanVien.DAL;
using QuanLyDoanVien.Models;

namespace QuanLyDoanVien.UI.Controllers
{
    public class HoatDongSinhVienDangKiController : Controller
    {
        // GET: HoatDongSinhVienDangKi
        public ActionResult DanhSachHoatDongDangKi( string masv)
        {
            ViewBag.User = Session["USER_SESSION"];
            HoatDongSinhVienDangKiDAL hd = new HoatDongSinhVienDangKiDAL();
            return View(hd.HoatDongSinhVien(ViewBag.User.MaSinhVien));
        }

        // GET: HoatDongSinhVienDangKi/Details/5
        public ActionResult ThongTinHoatDong(int maHD)
        {
            HoatDongSinhVienDangKiDAL hd = new HoatDongSinhVienDangKiDAL();
            return View(hd.ThongTinHoatDong(maHD));
        }

        // GET: HoatDongSinhVienDangKi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HoatDongSinhVienDangKi/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HoatDongSinhVienDangKi/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HoatDongSinhVienDangKi/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //GET: HoatDongSinhVienDangKi/Delete/5
        public ActionResult DeleteHoatDong(string masv, int mahd)
        {
            try
            {
                HoatDongSinhVienDangKiDAL hd = new HoatDongSinhVienDangKiDAL();
                hd.XoaHoatDongDangky(masv, mahd);
                ViewBag.ErrorMessage = "Xóa Thành Công!";
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = string.Format(e.Message);
               
            }
            HoatDongSinhVienDangKiDAL sv = new HoatDongSinhVienDangKiDAL();
            return View("DanhSachHoatDongDangKi", sv.HoatDongSinhVien(masv));
        }
    }
}
