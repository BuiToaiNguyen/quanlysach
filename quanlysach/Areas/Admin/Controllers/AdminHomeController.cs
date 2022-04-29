using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.NetworkInformation;
using quanlysach.Models.DB;
using quanlysach.Models.Query;

namespace quanlysach.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: Admin/AdminHome
        public ActionResult Index()
        {
            if (Session["user"]==null || Session["permission"] == null)
            {
                Response.Redirect($"{IPGlobalProperties.GetIPGlobalProperties().DomainName}/home/Index");

            }

            DBIO db = new DBIO();
            var listBook = db.getListBook();
            var listCate = db.getListCategory();
            ViewBag.listBook=listBook;
            ViewBag.listcate = listCate;
            return View();



        }

       

        [HttpPost]
        public JsonResult AddBook( FormCollection form)
        {
            JsonResult js= new JsonResult();
            var name = form["name"];
            var nameauthor = form["nameauthor"];
            int idctg = Convert.ToInt32(form["idctg"]);
            float price  = float.Parse(form["price"]);

            DBIO db= new DBIO();
            db.AddBook(name,nameauthor,idctg,price);
            db.Save();
            js.Data = new
            {
                status = "OK"
            };




            return Json(js,JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult EditBook(FormCollection form)
        {
            JsonResult js = new JsonResult();
            int id = Convert.ToInt32(form["id"]);
            var name = form["name"];
            var nameauthor = form["nameauthor"];
            int idctg = Convert.ToInt32(form["idctg"]);
            float price = float.Parse(form["price"]);
            DBIO db = new DBIO();

            db.EditBook(id,name,nameauthor,idctg,price);
            db.Save();
            js.Data = new
            {
                status = "OK"
            };
            return Json(js, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult DeleteBook(FormCollection form)
        {
            JsonResult js = new JsonResult();
            int id = Convert.ToInt32( form["id"]);
            DBIO db = new DBIO();

            Book book = db.getBookById(id);

            if (book != null)
            {
                db.DeleteObj(book);
                db.Save();
                js.Data = new
                {
                    status = "OK"
                };
            }
            else
            {
                js.Data = new
                {
                    status = "Fail"
                };
            }


            return Json(js, JsonRequestBehavior.AllowGet);

        }

    }
}