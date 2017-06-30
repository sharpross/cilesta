namespace Cilesta.Security.Katarina.Models
{
    using Cilesta.Security.Models;

    public class IndentityUser : IUserIndentity
    {
        private string _name = string.Empty;

        public IndentityUser(string name)
        {
            _name = name;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string AuthenticationType
        {
            get
            {
                return "Cilesta.Security.Katarina";
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return true;
            }
        }
    }
}
