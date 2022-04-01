using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Models;

namespace Demo.Controllers
{
    
    public class FilmsController : Controller
    {
        dbQLFilmDataContext db = new dbQLFilmDataContext();
        //private  List<Phim> Laychieurap(int count)
        //{
        //    return db.Phims.OrderByDescending(a => a.ChiTietLoais).Take(count).ToList();
        //}
        // GET: Films
        public ActionResult Index()
        {
            //var chieurap = Laychieurap(4);
            //return View(chieurap);
            return View();

        }

        // GET: Films/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Films/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Films/Create
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

        // GET: Films/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Films/Edit/5
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

        // GET: Films/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Films/Delete/5
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
