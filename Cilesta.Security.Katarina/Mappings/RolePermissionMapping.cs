namespace Cilesta.Security.Katarina.Mappings
{
    using Cilesta.Data.Interfaces;
    using Cilesta.Security.Katarina.Entities;
    using FluentNHibernate.Mapping;

    public class RolePermissionMapping : ClassMap<RolePermission>, IMapping
    {
        public RolePermissionMapping()
        {
            Table("rolepermission");
            Id(x => x.Id);
            Map(x => x.DateCreated);
            References<Role>(x => x.Role);
            References<PermissionKey>(x => x.Permission);
            Map(x => x.Access);
        }
    }
}
