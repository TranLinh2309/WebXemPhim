using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        dbQLFilmDataContext db = new dbQLFilmDataContext();
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["admin"] != null)
            {
                return RedirectToAction("Index", "AdminFilm");
            }
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = username;
            var pwd = password;
            var acc = db.AdminPros.SingleOrDefault(X => X.ten_admin == user && X.mat_khau_admin == pwd);
            if(acc != null)
            {
                //dang nhap thanh cong
                Session["admin"] = acc; 
                return RedirectToAction("Index", "AdminFilm");
            }
            else
            {
                return View();
            }
            
        }
    }
}