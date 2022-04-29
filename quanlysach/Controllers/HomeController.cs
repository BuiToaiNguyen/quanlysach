using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using quanlysach.Models.DB;
namespace quanlysach.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //if (Session["user"] == null)
            //{
            //    Response.Redirect("/login/index");

            //}
            //else
            //{

            //}
            return View();
        }

        
    }
}
