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

        public string CalculateMd5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            var md5 = MD5.Create();
            var inputBytes = Encoding.UTF8.GetBytes(input);
            var hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            var sb = new StringBuilder();
            foreach (var t in hash)
            {
                sb.Append(t.ToString("x2"));
            }
            return sb.ToString();
        }

        public bool Authenticate(string username, string password)
        {
            var passwordMd5 = CalculateMd5Hash(password);
            var result = _context.Users.Any(u => u.Login == username 
                && u.PasswordMd5 == passwordMd5);
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