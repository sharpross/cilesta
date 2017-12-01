namespace Cilesta.Security.Katarina.Mappings
{
    using Data.Interfaces;
    using Entities;
    using FluentNHibernate.Mapping;

    public class RolePermissionMapping : ClassMap<RolePermission>, IMapping
    {
        public RolePermissionMapping()
        {
            Table("rolepermission");
            Id(x => x.Id);
            Map(x => x.DateCreated);
            HasOne(x => x.Role);
            References(x => x.Permission).Cascade.All();
            HasMany(x => x.Accesses)
                .Cascade.All()
                .Table("permissions")
                .Element("accesses");
        }
    }
}