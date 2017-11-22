using QuanLyDoanVien.DAL;
using QuanLyDoanVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDoanVien.UI.Controllers
{
    public class ThayDoiMatKhauController : Controller
    {
        // GET: ThayDoiMatKhau
        public ActionResult ThongTinTaiKhoan()
        {
            TaiKhoanSinhVienDAL sv = new TaiKhoanSinhVienDAL();
            ModelState.Clear();
            return View(sv.TaiKhoanSV("15110171"));
        }

        // GET: ThayDoiMatKhau/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ThayDoiMatKhau/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThayDoiMatKhau/Create
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

        // GET: ThayDoiMatKhau/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: ThayDoiMatKhau/Edit/5
        [HttpPost]
        public ActionResult DoiMatKhau(TaiKhoanSinhVienModel sv)
        {
            try
            {
                TaiKhoanSinhVienDAL tk = new TaiKhoanSinhVienDAL();
                if (tk.DoiMatKhau(sv))
                {
                    ViewBag.ErrorMessage = "Cập Nhật Thành Công";
                }
                else
                {
                    ViewBag.ErrorMessage = "Cập Nhật Không Thành Công";
                }
            }catch(Exception e)
            {
                ViewBag.ErrorMessage = "Cập Nhật Không Thành Công";
            }
            return View("ThongTinTaiKhoan");
        }

        // GET: ThayDoiMatKhau/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ThayDoiMatKhau/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
