namespace Cilesta.Security.Katarina.Mappings
{
    using Data.Interfaces;
    using Entities;
    using FluentNHibernate.Mapping;

    public class PermissionKeyMapping : ClassMap<PermissionKey>, IMapping
    {
        public PermissionKeyMapping()
        {
            Table("permissionkey");
            Id(x => x.Id);
            Map(x => x.DateCreated);
            Map(x => x.Name);
            Map(x => x.Description);
        }
    }
}