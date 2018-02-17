using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAT.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetSiteMenu()
        {
            using (dbpatcdagEntities dc = new dbpatcdagEntities())
            {
                var menu = dc.au_menu.ToList();
                return new JsonResult { Data = menu, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
    }
}