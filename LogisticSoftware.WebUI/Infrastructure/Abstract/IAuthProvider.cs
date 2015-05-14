namespace LogisticSoftware.WebUI.Infrastructure.Abstract
{
    public interface IAuthProvider
    {
        bool Authenticate(string username, string password);
        void LogOut();
    } 
}
