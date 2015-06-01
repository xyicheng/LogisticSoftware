using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
using LogisticSoftware.WebUI.Infrastructure.Abstract;
using LogisticSoftware.WebUI.Models;

namespace LogisticSoftware.WebUI.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {

        private readonly LogisticsDbContext _context = new LogisticsDbContext();

        public bool Authenticate(string username, string password)
        {
            var result = _context.Users.Any(u => u.Login == username 
                && u.Password == password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, true);
            }
            return result;
        }

        public void LogOut()
        {
            FormsAuthentication.SignOut();
        }
    } 

}