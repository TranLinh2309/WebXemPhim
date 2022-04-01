using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Areas.Admin.Controllers
{
    public class AdminTrangThaiController : Controller
    {
        dbQLFilmDataContext db = new dbQLFilmDataContext();
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View(db.TrangThais.ToList());
        }

        // Create Trang Thai
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TrangThai trangThai)
        {
            db.TrangThais.InsertOnSubmit(trangThai);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        //Delete Trang Thai
        [HttpGet]
        public ActionResult Delete(int id)
        {
            TrangThai TrangThai = db.TrangThais.SingleOrDefault(n => n.id_trang_thai == id);

            ViewBag.id_trang_thai = TrangThai.id_trang_thai;
            if (TrangThai == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(TrangThai);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {

            //Get object by id
            TrangThai TrangThai = db.TrangThais.SingleOrDefault(n => n.id_trang_thai == id);
            ViewBag.id_trang_thai = TrangThai.id_trang_thai;
            if (TrangThai == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.TrangThais.DeleteOnSubmit(TrangThai);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        //Edit Trang Thai
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //Get object by id
            TrangThai TrangThai = db.TrangThais.SingleOrDefault(n => n.id_trang_thai == id);
            ViewBag.id_trang_thai = TrangThai.id_trang_thai;
            if (TrangThai == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(TrangThai);
        }

        [ValidateInput(false)]
        public ActionResult Edit(TrangThai TrangThai)
        {
            TrangThai TrangThai2 = db.TrangThais.Single(n => n.id_trang_thai == TrangThai.id_trang_thai);

            TrangThai2.id_trang_thai = TrangThai.id_trang_thai;
            db.SubmitChanges();

            return RedirectToAction("Index");

        }
    }
}