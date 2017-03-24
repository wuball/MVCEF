using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Light.Framework.Web.Base.Security;

namespace Light.Framework.Web.Areas.Admin.Controllers
{
    [MvcAuthorize]
    public class RoleController : Controller
    {
        // GET: Admin/Role
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult Del()
        {
            return View();
        }
        public ActionResult Authen()
        {
            return View();
        }
    }
}