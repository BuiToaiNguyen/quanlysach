using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.EntitySql;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using quanlysach.Models.Query;
using System.Net.NetworkInformation;

namespace quanlysach.Areas.Admin.Controllers
{
    public class AdminCateController : Controller
    {
        // GET: Admin/AdminCate
        public ActionResult Index(int page = 1, int pageSize = 5,string searchString="")
        {
            if (Session["user"] == null || Session["permission"] == null)
            {
                Response.Redirect($"{IPGlobalProperties.GetIPGlobalProperties().DomainName}/home/Index");

            }
            DBIO db = new DBIO();
            DBIOCate db1 = new DBIOCate();
            var listCate = db1.getListCategory(page,pageSize, searchString);
            var listBook = db.getListBook(1, 99999, "", "", 0);
            ViewBag.listBook = listBook;
            ViewBag.searchString=searchString;

            return View(listCate);
        }

        [HttpPost]
        public JsonResult AddCate(FormCollection form)
        {
            JsonResult js = new JsonResult();
            var nameCate = form["nameCate"];
            var description = form["description"];

            DBIOCate db = new DBIOCate();
            db.AddCate(nameCate, description);
            db.Save();
            js.Data = new
            {
                status = "OK"
            };

            return Json(js, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EditCate(FormCollection form)
        {
            JsonResult js = new JsonResult();

            var nameCate = form["nameCate"];
            var description = form["description"];
            var id =Convert.ToInt32(form["idcate"]);

            DBIOCate db = new DBIOCate();

            db.EditCate(id,nameCate,description);
            db.Save();
            js.Data = new
            {
                status = "OK"
            };
            return Json(js, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult DeleteCate(FormCollection form)
        {
            JsonResult js = new JsonResult();
            DBIOCate db = new DBIOCate();
            var id = Convert.ToInt32(form["id"]);
            db.DeleteCateandBook(id);

            db.Save();
            js.Data = new
            {
                status = "OK"
            };
            return Json(js, JsonRequestBehavior.AllowGet);


        }
    }
}