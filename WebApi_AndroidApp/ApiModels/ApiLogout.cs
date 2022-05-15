namespace WebApi_AndroidApp.ApiModels
{
    public class ApiLogout
    {
        public string Token { get; private set; }
        public ApiLogout(string token)
        {
            Token = token;
        }

    }
}
