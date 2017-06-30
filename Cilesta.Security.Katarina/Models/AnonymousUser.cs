namespace Cilesta.Security.Katarina.Models
{
    using Cilesta.Security.Models;

    public class AnonymousUser : IUserIndentity
    {
        public string Name
        {
            get
            {
                return string.Empty;
            }
        }

        public string AuthenticationType
        {
            get
            {
                return "Неизвестный пользователь";
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return false;
            }
        }
    }
}
