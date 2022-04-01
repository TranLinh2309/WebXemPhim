using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Areas.Admin.Controllers
{
    public class AdminLoaiController : Controller
    {
        // GET: Admin/AdminLoai
        dbQLFilmDataContext db = new dbQLFilmDataContext();
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View(db.Loais.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Loai loai)
        {
            
            db.Loais.InsertOnSubmit(loai);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        //Delete Loai
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Loai loai = db.Loais.SingleOrDefault(n => n.id_loai == id);

            ViewBag.id_loai = loai.id_loai;
            if (loai == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(loai);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {

            //Get object by id
            Loai loai = db.Loais.SingleOrDefault(n => n.id_loai == id);
            ViewBag.id_loai = loai.id_loai;
            if (loai == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.Loais.DeleteOnSubmit(loai);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        //Edit Loai
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //Get object by id
            Loai loai = db.Loais.SingleOrDefault(n => n.id_loai == id);
            ViewBag.id_loai = loai.id_loai;
            if (loai == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(loai);
        }

        [ValidateInput(false)]
        public ActionResult Edit(Loai loai)
        {
            Loai loai2 = db.Loais.Single(n => n.id_loai == loai.id_loai);

            loai2.ten_loai = loai.ten_loai;
            db.SubmitChanges();

            return RedirectToAction("Index");

        }
    }
}
   
