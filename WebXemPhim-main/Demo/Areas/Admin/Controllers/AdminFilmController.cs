using Demo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Areas.Admin.Controllers
{
    public class AdminFilmController : Controller
    {
        dbQLFilmDataContext db = new dbQLFilmDataContext();
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View(db.Phims.ToList());
        }

        // Create
        [HttpGet]
        public ActionResult Create()
        {
            var model = new Phim();
            
            ViewBag.id_quoc_gia = new SelectList(db.QuocGias.ToList().OrderBy(n => n.ten_quoc_gia), "id_quoc_gia", "ten_quoc_gia");
            ViewBag.id_nam = new SelectList(db.NamPhatHanhs.ToList().OrderBy(n => n.nam_phat_hanh), "id_nam", "nam_phat_hanh");
            ViewBag.id_trang_thai = new SelectList(db.TrangThais.ToList().OrderBy(n => n.ten_trang_thai), "id_trang_thai", "ten_trang_thai");

            ViewBag.id_loai = (from a in db.Loais select a).ToList();
            ViewBag.id_dien_vien = (from a in db.DienViens select a).ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Phim phim, HttpPostedFileBase fileUpload)
        {
            ViewBag.id_quoc_gia = new SelectList(db.QuocGias.ToList().OrderBy(n => n.ten_quoc_gia), "id_quoc_gia", "ten_quoc_gia");
            ViewBag.id_nam = new SelectList(db.NamPhatHanhs.ToList().OrderBy(n => n.nam_phat_hanh), "id_nam", "nam_phat_hanh");
            ViewBag.id_trang_thai = new SelectList(db.TrangThais.ToList().OrderBy(n => n.ten_trang_thai), "id_trang_thai", "ten_trang_thai");

            ViewBag.id_loai = (from a in db.Loais select a).ToList();
            ViewBag.id_dien_vien = (from a in db.DienViens select a).ToList();

            if (fileUpload == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh bìa";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {

                    if (phim.ten_phim == null)
                    {
                        ViewData["Loi"] = "Vui lòng nhập tên";
                        return View();
                    }
                    else
                    {
                        var fileName = Path.GetFileName(fileUpload.FileName);
                        DateTime localDate = DateTime.Now;
                        string date_str = localDate.ToString("ddMMyyyy_HHmmss");
                        fileName = date_str + "_" + fileName;
                        var path = Path.Combine(Server.MapPath("~/img/poster/"), fileName);
                        if (System.IO.File.Exists(path))
                            ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                        else
                        {
                            fileUpload.SaveAs(path);
                        }
                        phim.anh_bia = fileName;

                        db.Phims.InsertOnSubmit(phim);

                        db.SubmitChanges();
                        return RedirectToAction("Index");
                    }
              
                }
                return View();
            }
        }

        //Delete Phim
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Phim Phim = db.Phims.SingleOrDefault(n => n.id_phim == id);

            ViewBag.id_phim = Phim.id_phim;
            if (Phim == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(Phim);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {

            //Get object by id
            Phim Phim = db.Phims.SingleOrDefault(n => n.id_phim == id);
            ViewBag.id_phim = Phim.id_phim;
            if (Phim == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.Phims.DeleteOnSubmit(Phim);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        //Edit Phim
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //Get object by id
            Phim Phim = db.Phims.SingleOrDefault(n => n.id_phim == id);
            ViewBag.id_phim = Phim.id_phim;
            if (Phim == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(Phim);
        }

        [ValidateInput(false)]
        public ActionResult Edit(Phim Phim)
        {
            Phim Phim2 = db.Phims.Single(n => n.id_phim == Phim.id_phim);

            Phim2.ten_phim = Phim.ten_phim;
            Phim2.anh_bia = Phim.anh_bia;
            Phim2.id_loai = Phim.id_loai;
            Phim2.mo_ta = Phim.mo_ta;
            Phim2.trailer = Phim.trailer;
            Phim2.link_phim = Phim.link_phim;
            Phim2.id_trang_thai = Phim.id_trang_thai;
            Phim2.id_quoc_gia = Phim.id_quoc_gia;
            Phim2.id_nam = Phim.id_nam;
            db.SubmitChanges();

            return RedirectToAction("Index");

        }
    }
}