using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web4dotnet.Helper;
using Web4dotnet.Models;

namespace Web4dotnet.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public JsonResult CheckLogin(string username, string password)

        {

            QuanlyLuatEntities db = new QuanlyLuatEntities();

            var dataItem = db.Users.Where(x => x.TenDangNhap == username && x.MatKhau == password).SingleOrDefault();

            bool isLogged = true;

            if (dataItem != null)

            {

                Session["TenDangNhap"] = dataItem.TenDangNhap;

                isLogged = true;

            }

            else

            {

                isLogged = false;

            }

            return Json(isLogged, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Logout()
        {
            Session["TenDangNhap"] = null;
            return RedirectToAction("Login");
        }
    }
}