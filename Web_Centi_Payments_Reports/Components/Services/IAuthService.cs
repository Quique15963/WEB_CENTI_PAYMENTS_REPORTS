namespace Web_Centi_Payments_Reports.Components.Services
{
    public interface IAuthService
    {
        bool IsAuthenticated { get; }
        void Login(string username, string password);
        void Logout();
    }

    public class AuthService : IAuthService
    {
        private bool isAuthenticated;

        public bool IsAuthenticated => isAuthenticated;

        public void Login(string username, string password)
        {
            // Aquí puedes agregar la lógica de autenticación real
            if (username == "admin" && password == "password")
            {
                isAuthenticated = true;
            }
        }

        public void Logout()
        {
            isAuthenticated = false;
        }

    }

}
