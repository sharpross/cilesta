namespace Cilesta.Security.Katarina.Implimentation
{
    using System.Security.Principal;
    using Security.Interfaces;

    public class IdentityPrincipal : IIdentityPrincipal
    {
        public IdentityPrincipal(IIdentity userPrincipal)
        {
            identity = userPrincipal;
        }

        private IIdentity identity { get; }

        public IIdentity Identity => identity;

        public bool IsInRole(string role)
        {
            if (Identity != null && Identity.IsAuthenticated)
            {
            }

            return true;
        }
    }
}