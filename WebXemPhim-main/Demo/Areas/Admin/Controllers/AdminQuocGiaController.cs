using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Areas.Admin.Controllers
{
    public class AdminQuocGiaController : Controller
    {
        dbQLFilmDataContext db = new dbQLFilmDataContext();
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View(db.QuocGias.ToList());
        }

        // Create Quoc Gia
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(QuocGia QuocGia)
        {
            db.QuocGias.InsertOnSubmit(QuocGia);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        //Delete Quoc Gia
        [HttpGet]
        public ActionResult Delete(int id)
        {
            QuocGia QuocGia = db.QuocGias.SingleOrDefault(n => n.id_quoc_gia == id);

            ViewBag.id_quoc_gia = QuocGia.id_quoc_gia;
            if (QuocGia == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(QuocGia);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {

            //Get object by id
            QuocGia QuocGia = db.QuocGias.SingleOrDefault(n => n.id_quoc_gia == id);
            ViewBag.id_quoc_gia = QuocGia.id_quoc_gia;
            if (QuocGia == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.QuocGias.DeleteOnSubmit(QuocGia);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        //Edit Quoc Gia
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //Get object by id
            QuocGia QuocGia = db.QuocGias.SingleOrDefault(n => n.id_quoc_gia == id);
            ViewBag.id_quoc_gia = QuocGia.id_quoc_gia;
            if (QuocGia == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(QuocGia);
        }

        [ValidateInput(false)]
        public ActionResult Edit(QuocGia QuocGia)
        {
            QuocGia QuocGia2 = db.QuocGias.Single(n => n.id_quoc_gia == QuocGia.id_quoc_gia);

            QuocGia2.ten_quoc_gia = QuocGia.ten_quoc_gia;
            db.SubmitChanges();

            return RedirectToAction("Index");

        }
    }
}