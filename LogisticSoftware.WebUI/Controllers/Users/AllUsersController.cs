using System.Web.Mvc;
using LogisticSoftware.WebUI.Models;

namespace LogisticSoftware.WebUI.Controllers.Users
{
    [Authorize]
    public class AllUsersController : Controller
    {
        private readonly LogisticsDbContext _context = new LogisticsDbContext();


        public ActionResult Index()
        {
            return View(_context.Users);
        }

    }
}
