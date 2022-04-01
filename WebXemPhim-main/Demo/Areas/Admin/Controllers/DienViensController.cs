
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Models;
namespace Demo.Areas.Admin.Controllers
{
    public class DienViensController : Controller
    {
        dbQLFilmDataContext db = new dbQLFilmDataContext();
        // GET: Admin/DienViens
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View(db.DienViens.ToList());
        }

        // GET: Admin/DienViens/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/DienViens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DienViens/Create
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

        // GET: Admin/DienViens/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/DienViens/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/DienViens/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/DienViens/Delete/5
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
