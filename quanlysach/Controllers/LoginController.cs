using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using quanlysach.Models.DB;
using quanlysach.Models.Query;

namespace quanlysach.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult CheckLogin(FormCollection form)
        {
            JsonResult js = new JsonResult();
            string name = form["name"];
            string password = form["password"];

            DBIO db=new DBIO();

            User user = db.getUser(name);
            if (user == null)
            {
                js.Data = new
                {
                    status = "F"

                };
            }
            else
            {
                if (user.password == password)
                {
                   Session["user"]=user;
                    js.Data = new
                    {
                        status = "OK"

                    };

                }
                else
                {
                    js.Data = new
                    {
                        status = "ERRPass"

                    };
                }

            }
 



            
            return Json(js, JsonRequestBehavior.AllowGet);

        }
    }
}