using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Models;
namespace Demo.Controllers
{
    public class UsersController : Controller
    {
        dbQLFilmDataContext db = new dbQLFilmDataContext();
        [HttpGet]
        // GET: Users
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection collection, NguoiDung nd)
        {
            var hoten = collection["ten_nguoi_dung"];
            var tendn = collection["tai_khoan"];
            var matkhau = collection["mat_khau"];
            var matkhaunhaplai = collection["mat_khau_nhap_lai"];
            var Email = collection["email"];
            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Họ tên người dùng không được để trống";
            }
            else if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi2"] = "Phải nhập tên đăng nhập";
            }
            else if(String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = " Phải nhập mật khẩu";
            }
            else if (String.IsNullOrEmpty(matkhaunhaplai))
            {
                ViewData["Loi4"] = "Phải nhập lại mật khẩu";
            }
            else if (String.IsNullOrEmpty(Email))
            {
                ViewData["Loi5"] = "Email không được bỏ trống";
            }
            else
            {
                nd.ten_nguoi_dung = hoten;
                nd.tai_khoan = tendn;
                nd.mat_khau = matkhau;
                nd.email = Email;
                db.NguoiDungs.InsertOnSubmit(nd);
                db.SubmitChanges();
                return RedirectToAction("DangNhap");
            }
            return this.DangKy();
        }

        // GET: Users/Edit/5
        public ActionResult DangNhap()
        {
            if (Session["nguoidung"] != null)
            {
                return RedirectToAction("Index", "LoadPhim");
            }
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Dangnhap(string username, string password)
        {
            var tendn = username;
            var matkhau = password;
            var acc = db.NguoiDungs.SingleOrDefault(X => X.tai_khoan == tendn && X.mat_khau == matkhau);
            if (acc != null)
            {
                //dang nhap thanh cong
                Session["nguoidung"] = acc;
                return RedirectToAction("Index", "LoadPhim");
            }
            else
            {

                return View();
            }
        }

        
    }
}
