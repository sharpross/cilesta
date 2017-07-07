namespace Cilesta.Security.Katarina.Mappings
{
    using Cilesta.Data.Interfaces;
    using Cilesta.Security.Katarina.Entities;
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
