using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PagedList;
using PagedList.Mvc;

namespace Demo.Controllers
{
    public class LoadPhimController : Controller
    {
        // GET: LoadPhim
        dbQLFilmDataContext db = new dbQLFilmDataContext();
        private List<Phim> layPhimMoi(int count)
        {
            return db.Phims.OrderByDescending(a => a.id_phim).Take(count).ToList();
        }

        public ActionResult Index(int ? page)
        {
            int pages = 6;
            int pagen = (page ?? 1);
            var phimMoi = layPhimMoi(1000);
            return View(phimMoi.ToPagedList(pagen,pages));
        }

        public ActionResult Details(int id)
        {
            var phim = from p in db.Phims
                       where p.id_phim == id
                       select p;
            return View(phim.Single());
        }

        public ActionResult WatchFilm(int id)
        {
            var phim = from p in db.Phims
                       where p.id_phim == id
                       select p;
            return View(phim.Single());
        }

        //Type Movie
        public ActionResult TypeFilm()
        {
            var type = from t in db.Loais select t;
            return PartialView(type);
        }
      
        public ActionResult FilmForType(int id)
        {
            var movie = from m in db.Phims
                        join ml in db.ChiTietLoais
                        on m.id_phim equals ml.id_phim
                        where ml.id_loai == id
                        select m;
            return View(movie);
        }

        public ActionResult TypeNation()
        {
            var type = from t in db.QuocGias select t;
            return PartialView(type);
        }

        public ActionResult NationForType(int id)
        {
            var nation = from m in db.Phims
                         where m.id_quoc_gia == id
                        select m;
            return View(nation);
        }

        public ActionResult TypeYear()
        {
            var type = from t in db.NamPhatHanhs select t;
            return PartialView(type);
        }

        public ActionResult YearForType(int id)
        {
            var year = from m in db.Phims
                         where m.id_nam == id
                         select m;
            return View(year);
        }

        public ActionResult TypeStatus()
        {
            var type = from t in db.TrangThais select t;
            return PartialView(type);
        }

        public ActionResult StatusForType(int id)
        {
            var status = from m in db.Phims
                       where m.id_trang_thai == id
                       select m;
            return View(status);
        }


        public ActionResult Search(String searchMovie)
        {
          
            var phim = from p in db.Phims
                       where p.ten_phim.Contains(searchMovie)
                       select p;

            return View(phim);
        }
    }
}