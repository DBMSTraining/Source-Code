using QuanLyDoanVien.DAL;
using QuanLyDoanVien.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDoanVien.UI.Controllers
{
    public class ThongTinCaNhanSinhVienController : Controller
    {
        // GET: ThongTinCaNhanSinhVien
        public ActionResult ThongTinCaNhanSinhVien( string masv)
        {

            ThongTinSinhVienDAL sv = new ThongTinSinhVienDAL();
            ModelState.Clear();
            var model = Session["USER_SESSION"];
            ViewBag.USer = model;
            return View(sv.ThongTinSinhVien(ViewBag.User.MaSinhVien));
        }
        public ActionResult DanhSachKhoa()
        {
            ThongTinSinhVienDAL sv = new ThongTinSinhVienDAL();
            ModelState.Clear();
            return View(sv.DoanKhoa());
        }
        [HttpGet]
        public ActionResult CapNhatThongTinSinhVien()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CapNhatThongTinSinhVien(SinhVienModel sinhvien)
        {
            if (string.IsNullOrEmpty(sinhvien.Hinh))
            {
                sinhvien.Hinh = "s";
            }
            ThongTinSinhVienDAL sv = new ThongTinSinhVienDAL();
            try
            {
                sv.CapNhatThongTin(sinhvien);
                ViewBag.Message = "Cập Nhật Thành Công";
            }catch(Exception ex)
            {
                ViewBag.Message = string.Format(ex.Message);
            }
            ThongTinSinhVienDAL tt = new ThongTinSinhVienDAL();
            ModelState.Clear();
            var model = Session["USER_SESSION"];
            ViewBag.User = model;
            return View("ThongTinCaNhanSinhVien", tt.ThongTinSinhVien(ViewBag.User.MaSinhVien));

        }
        public ActionResult ThayDoiMatKhau(string masv)
        {
            ThongTinSinhVienDAL sv = new ThongTinSinhVienDAL();
            return View(sv.TaiKhoanSV(masv));
        }
        [HttpPost]
        public ActionResult ThayDoimatKhau(TaiKhoanSinhVienModel tksv)
        {
            return View();
        }

        public ActionResult CapNhatAnhDaiDien()
        {
            return View();
        }
    }
}