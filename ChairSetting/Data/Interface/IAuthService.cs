namespace ChairSetting.Data.Interface
{
    public interface IAuthService
    {
        string Login(string username, string password);
        void Signup(string username, string password);
    }
}
