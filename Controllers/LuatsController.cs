using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web4dotnet.Models;

namespace Web4dotnet.Controllers
{
    public class LuatsController : Controller
    {
        // GET: Luats
        public ActionResult Index()
        {
            LuatList strLuat = new LuatList();
            List<QLLuat> obj = strLuat.GetLuat(string.Empty);
            return View(obj);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(QLLuat strLuat)
        {
            if (ModelState.IsValid)
            {
                LuatList Luat = new LuatList();
                Luat.AddLuat(strLuat);
                return RedirectToAction("Index");
            }
            return View();
        }

        // Sửa luật

        public ActionResult Edit(string id = "")
        {
            LuatList Luat = new LuatList();
            List<QLLuat> obj = Luat.GetLuat(id);
            return View(obj.FirstOrDefault());
        }

        [HttpPost]

        public ActionResult Edit(QLLuat strLuat)
        {
            LuatList Luat = new LuatList();
            Luat.EditLuat(strLuat);
            return RedirectToAction("Index");
        }

        // Xóa luật

        public ActionResult Delete(string id = "")
        {
            LuatList Luat = new LuatList();
            List<QLLuat> obj = Luat.GetLuat(id);
            return View(obj.FirstOrDefault());
        }

        [HttpPost]

        public ActionResult Delete(QLLuat strLuat)
        {
            LuatList Luat = new LuatList();
            Luat.DeleteLuat(strLuat);
            return RedirectToAction("Index");
        }

        // Hiển thị luật

        public ActionResult Details(string id = "")
        {
            LuatList Luat = new LuatList();
            List<QLLuat> obj = Luat.GetLuat(id);
            return View(obj.FirstOrDefault());
        }

     

    }
}