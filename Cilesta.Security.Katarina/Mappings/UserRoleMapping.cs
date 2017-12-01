namespace Cilesta.Security.Katarina.Mappings
{
    using Data.Interfaces;
    using Entities;
    using FluentNHibernate.Mapping;

    public class UserRoleMapping : ClassMap<UserRole>, IMapping
    {
        public UserRoleMapping()
        {
            Table("userrole");
            Id(x => x.Id);
            Map(x => x.DateCreated);
            References(x => x.User).Cascade.All();
            HasManyToMany(x => x.Roles).Cascade.All().Inverse();
        }
    }
}