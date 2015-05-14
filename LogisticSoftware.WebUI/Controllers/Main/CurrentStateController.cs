using System.Web.Mvc;

namespace LogisticSoftware.WebUI.Controllers.Main
{
    [Authorize]
    public class CurrentStateController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

    }
}
