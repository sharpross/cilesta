namespace Cilesta.Security.Katarina.Mappings
{
    using Data.Interfaces;
    using Entities;
    using FluentNHibernate.Mapping;

    public class RoleMapping : ClassMap<Role>, IMapping
    {
        public RoleMapping()
        {
            Table("roles");
            Id(x => x.Id);
            Map(x => x.Name)
                .Unique()
                .Not.Nullable();
            Map(x => x.DateCreated);
        }
    }
}