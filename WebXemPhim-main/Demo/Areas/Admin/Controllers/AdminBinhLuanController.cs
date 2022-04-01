using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Areas.Admin.Controllers
{
    public class AdminBinhLuanController : Controller
    {
        // GET: Admin/AdminBinhLuan
        dbQLFilmDataContext db = new dbQLFilmDataContext();
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View(db.BinhLuans.ToList());
        }
    }
}