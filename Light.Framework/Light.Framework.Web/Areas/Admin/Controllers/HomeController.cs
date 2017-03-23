using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Light.Framework.Core.Extensions;
using Light.Framework.Service.Admin.Dtos;
using Light.Framework.Service.Admin.Implementations;
using Light.Framework.Web.Base.Controllers;
using Light.Framework.Web.Base.Extensions;

namespace Light.Framework.Web.Areas.Admin.Controllers
{
    public class HomeController : LightControllerBase
    {
        private readonly UserService _us = new UserService();
        private readonly MenuService _ms = new MenuService();

        // GET: Admin/Home
        public ActionResult Index()
        {

            //_ms.GetMyMenus(User.Identity.GetLoginUserId());
            var vm = _ms.GetMyMenus("2f22398a-c792-4e55-95a2-559be136259b".ToGuid());
            return View(vm);
        }

        public ActionResult Login()
        {
            var model = new LoginDto
            {
                ReturnUrl = Request.QueryString["ReturnUrl"],
                LoginName = "admin",
                Password = "111111"
            };
            if (User.Identity.IsAuthenticated)
            {
                if (model.ReturnUrl.IsNullOrSpace())
                    return Redirect(model.ReturnUrl);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginDto model)
        {
            if (model.LoginName.IsNullOrSpace() || model.Password.IsNullOrSpace())
            {
                return View(model);
            }
            //if (!ModelState.IsValid) return View(model);

            model.LoginIP = HttpContext.Request.UserHostAddress;
            var result = _us.Login(model);
            if (result.Success)
            {

                Response.SetAuthCookie(result.Value.Id.ToString());


                //var authenticationManager = HttpContext.GetOwinContext().Authentication;
                //var claims = new List<Claim>
                //{
                //    new Claim("LoginUserId", loginDto.User.Id),
                //    new Claim("IsSuperMan", loginDto.User.IsSuperMan.ToString()),   //判断是否超级管理员
                //    new Claim(ClaimTypes.Name, model.LoginName)
                //};
                //var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                //var pro = new AuthenticationProperties()
                //{
                //    IsPersistent = true
                //};
                //authenticationManager.SignIn(pro, identity);

                if (model.ReturnUrl.IsNullOrSpace())
                    return RedirectToAction("Index");
                return Redirect(model.ReturnUrl);
            }
            return View(model);
        }

    }
}