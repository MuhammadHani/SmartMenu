using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartMenuAPIs.Areas.Manage.Controllers
{
    public class testController : Controller
    {
        //
        // GET: /Manage/test/
        public ActionResult Index()
        {
            return Content("ala");
        }
	}
}