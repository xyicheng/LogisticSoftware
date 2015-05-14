using System;
using System.Web.Mvc;
using LogisticSoftware.WebUI.Infrastructure.Abstract;
using LogisticSoftware.WebUI.Models;

namespace LogisticSoftware.WebUI.Controllers
{

    public class AccountController : Controller
    {
        readonly IAuthProvider _authProvider;
        public AccountController(IAuthProvider auth)
        {
            _authProvider = auth;
        }

        public ViewResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_authProvider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index","CurrentState"));
                }
                ModelState.AddModelError("", "Неправильний логін чи пароль користувача");
                return View();
            }
            return View();
        }

        public ActionResult Logout()
        {
            _authProvider.LogOut();
            return new RedirectResult("/Account/Login");
        }
    }


}
