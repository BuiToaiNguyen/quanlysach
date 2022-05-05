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
        public ActionResult Index(int page = 1,int pageSize=10,string searchString="",string searchAuthor="",int searchCate =0 )
        {
            if (Session["user"]==null || Session["permission"] == null)
            {
                Response.Redirect($"{IPGlobalProperties.GetIPGlobalProperties().DomainName}/home/Index");

            }

            DBIO db = new DBIO();
            DBIOCate db1 = new DBIOCate();
            var listBook = db.getListBook(page, pageSize, searchString,searchAuthor,searchCate);
            var listCate = db1.getListCategory(1,100000);
            ViewBag.listBook=listBook;
            ViewBag.listcate = listCate;


            ViewBag.tab = "catemanage";
            ViewBag.index = (page - 1) * pageSize + 1; 
            ViewBag.searchString = searchString;
            ViewBag.searchAuthor = searchAuthor;
            ViewBag.searchCate = searchCate;

            return View(listBook);



        }

       

        [HttpPost]
        public JsonResult AddBook( FormCollection form)
        {
            JsonResult js= new JsonResult();
            var name = form["name"];
            var nameauthor = form["nameauthor"];
            int idctg = Convert.ToInt32(form["idctg"]);
            float price  = float.Parse(form["price"]);
            var linkimg = form["linkimg"];
            DBIO db= new DBIO();
            db.AddBook(name,nameauthor,idctg,price, linkimg);
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
            var linkimg = form["linkimg"];
            DBIO db = new DBIO();

            db.EditBook(id,name,nameauthor,idctg,price,linkimg);
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

        //public ActionResult IndexCate(string id)
        //{

        //    DBIO db = new DBIO();
        //    var listCate = db.getListCategory();
        //    var listBook = db.getListBook(1,100, "","",0);
        //    ViewBag.listBook= listBook;
        //    ViewBag.id = id;
        //    return View(listCate);
        //}

        public void LogOut()
        {
            if (Session["user"] == null)
            {
                Response.Redirect($"{IPGlobalProperties.GetIPGlobalProperties().DomainName}/home/Index");
            }
            else
            {
                Session["user"] = null;
                Session["permission"] = null;
                Response.Redirect($"{IPGlobalProperties.GetIPGlobalProperties().DomainName}/login/Index");


            }


        }

    }
}