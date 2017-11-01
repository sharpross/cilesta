namespace Cilesta.Security.Katarina.Models
{
    using Security.Models;

    public class IndentityUser : IUserIndentity
    {
        public IndentityUser(string name)
        {
            Name = name;
        }

        public string Name { get; } = string.Empty;

        public string AuthenticationType => "Cilesta.Security.Katarina";

        public bool IsAuthenticated => true;
    }
}