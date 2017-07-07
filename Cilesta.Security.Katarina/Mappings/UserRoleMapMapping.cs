namespace Cilesta.Security.Katarina.Mappings
{
    using Cilesta.Data.Interfaces;
    using Cilesta.Security.Katarina.Entities;
    using FluentNHibernate.Mapping;

    public class UserRoleMapMapping : ClassMap<UserRoleMap>, IMapping
    {
        public UserRoleMapMapping()
        {
            Table("userrolemap");
            Id(x => x.Id);
            Map(x => x.DateCreated);
            References(x => x.User)
                .Cascade.All();
            HasMany(x => x.Roles);
        }
    }
}
