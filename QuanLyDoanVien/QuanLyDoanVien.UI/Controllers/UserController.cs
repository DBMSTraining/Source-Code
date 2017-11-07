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
        [HttpPost]
        public ActionResult Index()
        {
            var model = Session["Student"];
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
            var userSession = new UserLogin();
            userSession.UserName = userLogin.UserName;
            userSession.Password = userLogin.Password;
            userSession.MaSinhVien = userLogin.MaSinhVien;
            userSession.MaKhoa = userLogin.MaKhoa;
            userSession.MaChiDoan = userLogin.MaChiDoan;
            Session.Add(CommonConstants.USER_SESSION, userSession);
            //
            SinhVienModel student = new SinhVienModel();
            student = UserDAL.LoadProfile(userLogin.MaSinhVien);
            //Session["Student"] = student;
            return RedirectToAction("Index", "Home", student);
        }
        // End Login
        // BEGIN LOGOUT
        public ActionResult Logout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logout(LoginModel user)
        {
            Session.Remove(CommonConstants.USER_SESSION);
            return RedirectToAction("Login", "User");
        }
        // End Logout
        // PROFILE
        public new ActionResult Profile()
        {
            return View();
        }

        [HttpPost]
        public new ActionResult Profile(SinhVienModel user)
        {

            if (user == null)
            {
                ViewBag.ErrorMessage = "User null";
                return View(user);
            }

            var student = UserDAL.LoadProfile(user.MaSinhVien);

            if (student == null)
            {
                ViewBag.ErrorMessage = "Load fail";
                return View(user);
            }
            return View(student);
        }

        // End Profile

        public ActionResult CreateProfile(string MaSinhVien)
        {
            return View();
        }
    }
}