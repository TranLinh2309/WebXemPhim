using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Models;

namespace Demo.Areas.Admin.Controllers
{
    public class QlUsersController : Controller
    {
        dbQLFilmDataContext db = new dbQLFilmDataContext();
        // GET: Admin/QlUsers
        public ActionResult NguoidungUser()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View(db.NguoiDungs.ToList());
        }

        // GET: Admin/QlUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/QlUsers/Create
        [HttpPost]
        public ActionResult Create(NguoiDung NguoiDung)
        {
            db.NguoiDungs.InsertOnSubmit(NguoiDung);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/QlUsers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/QlUsers/Edit/5
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

        // GET: Admin/QlUsers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/QlUsers/Delete/5
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
