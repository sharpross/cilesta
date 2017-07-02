namespace Cilesta.Security.Katarina.Implimentation
{
    using System.Security.Principal;
    using Cilesta.Security.Interfaces;

    public class IdentityPrincipal : IIdentityPrincipal
    {
        private IIdentity identity { get; set; }

        public IIdentity Identity
        {
            get 
            {
                return this.identity;
            }
        }

        public IdentityPrincipal(IIdentity userPrincipal)
        {
            this.identity = userPrincipal;    
        }

        public bool IsInRole(string role)
        {
            if (this.Identity != null && this.Identity.IsAuthenticated)
            {
                
            }

            return true;
        }
    }
}
