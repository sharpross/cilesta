namespace Cilesta.Security.Katarina.Mappings
{
    using Cilesta.Data.Interfaces;
    using Cilesta.Security.Katarina.Entities;
    using FluentNHibernate.Mapping;

    public class UserMapping : ClassMap<User>, IMapping
    {
        public UserMapping()
        {
            Table("users");
            Map(x => x.Id);
            Map(x => x.Login);
            Map(x => x.Password);
            Map(x => x.Email);
        }
    }
}
