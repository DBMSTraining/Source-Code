using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyDoanVien.Models;
using QuanLyDoanVien.DAL;
using QuanLyDoanVien.UI.Commons;

namespace QuanLyDoanVien.UI.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var model = Session["student"];
            return View(model);
        }

        // LOGIN
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(LoginModel user)
        {
            if (user == null)
            {
                ViewBag.ErrorMessage = "User null";
                return View(user);
            }

            if (string.IsNullOrEmpty(user.UserName))
            {
                return View(user);
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                return View(user);
            }

            var userLogin = UserDAL.Login(user);
            if (userLogin == null)
            {
                ModelState.AddModelError("", "UserName/Password is incorrect!");
                return View("");
            }

            SinhVienModel student = new SinhVienModel();
            student = UserDAL.LoadProfile(userLogin.MaSinhVien);

            var userSession = new UserLogin();
            userSession.UserName = userLogin.UserName;
            userSession.Password = userLogin.Password;
            userSession.MaSinhVien = userLogin.MaSinhVien;
            userSession.MaKhoa = userLogin.MaKhoa;
            userSession.MaChiDoan = userLogin.MaChiDoan;
            userSession.TenSinhVien = student.TenSinhVien;
            Session.Add(CommonConstants.USER_SESSION, userSession);
            //
            
            return RedirectToAction("Index", "Home");
        }
        // End Login
        // BEGIN LOGOUT
        //public ActionResult Logout()
        //{
        //    return View();
        //}

        //[HttpPost]
        public ActionResult Logout()
        {
            Session.Remove("USER_SESSION");
            return View("Login");
        }
        // End Logout
        // PROFILE
        //public new ActionResult Profile()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public new ActionResult Profile(string masv)
        //{

           
        //    var student = UserDAL.LoadProfile(masv);

        //    if (student == null)
        //    {
        //        ViewBag.ErrorMessage = "Load fail";
        //        return View();
        //    }
        //    return View(student);
        //}

            //[HttpPost]
            //public UserLogin 

        // End Profile

        public ActionResult CreateProfile(string MaSinhVien)
        {
            return View();
        }
    }
}