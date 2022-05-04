using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using quanlysach.Models.DB;
using quanlysach.Models.Query;

namespace quanlysach.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int page=1,int pageSize=12,string searchString="")
        {
            DBIO db = new DBIO();

            var listbook = db.getListBookHome(page, pageSize, searchString);


            return View(listbook);
        }

        
    }
}
