namespace Cilesta.Security.Katarina.Models
{
    using Security.Models;

    public class AnonymousUser : IUserIndentity
    {
        public string Name => string.Empty;

        public string AuthenticationType => "Неизвестный пользователь";

        public bool IsAuthenticated => false;
    }
}