namespace Cilesta.Security.Katarina.Mappings
{
    using Cilesta.Data.Interfaces;
    using Cilesta.Security.Katarina.Entities;
    using FluentNHibernate.Mapping;

    public class RolePermissionMapping : ClassMap<RolePermissionMap>, IMapping
    {
        public RolePermissionMapping()
        {
            Table("rolepermission");
            Id(x => x.Id);
            HasOne(x => x.Role);
            HasManyToMany<PEr>(x => x.Permission);
        }
    }
}
