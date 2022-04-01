using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Models;
namespace Demo.Areas.Admin.Controllers
{
    public class ReleaseYearController : Controller
    {
        dbQLFilmDataContext db = new dbQLFilmDataContext();
        // GET: Admin/ReleaseYear
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View(db.NamPhatHanhs.ToList());
        }

        // GET: Admin/ReleaseYear/Details/5
        public ActionResult Details(int id)
        {

            NamPhatHanh nph = db.NamPhatHanhs.SingleOrDefault(n => n.id_nam == id);
            ViewBag.id_nam = nph.id_nam;
            if (nph == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nph);
        }
        [HttpGet]
        // GET: Admin/ReleaseYear/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ReleaseYear/Create
        [HttpPost]
        public ActionResult Create(NamPhatHanh nph)
        {
            db.NamPhatHanhs.InsertOnSubmit(nph);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        // GET: Admin/ReleaseYear/Edit/5
        public ActionResult Edit(int id)
        {
            NamPhatHanh nph = db.NamPhatHanhs.SingleOrDefault(n => n.id_nam == id);
            if (nph == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nph);
        }

        // POST: Admin/ReleaseYear/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(NamPhatHanh nph)
        {
            NamPhatHanh nph2 = db.NamPhatHanhs.Single(n => n.id_nam == nph.id_nam);

            nph2.nam_phat_hanh = nph.nam_phat_hanh;
            db.SubmitChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        // GET: Admin/ReleaseYear/Delete/5
        public ActionResult Delete(int id)
        {
            NamPhatHanh nph = db.NamPhatHanhs.SingleOrDefault(n => n.id_nam == id);

            ViewBag.id_nam = nph.id_nam;
            if (nph == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nph);
        }

        // POST: Admin/ReleaseYear/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteOK(int id)
        {
            NamPhatHanh nph = db.NamPhatHanhs.SingleOrDefault(n => n.id_nam == id);
            ViewBag.nam_phat_hanh = nph.nam_phat_hanh;

            if (nph == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.NamPhatHanhs.DeleteOnSubmit(nph);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}
