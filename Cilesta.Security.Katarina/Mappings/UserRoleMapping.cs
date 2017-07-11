﻿namespace Cilesta.Security.Katarina.Mappings
{
    using Cilesta.Data.Interfaces;
    using Cilesta.Security.Katarina.Entities;
    using FluentNHibernate.Mapping;

    public class UserRoleMapping : ClassMap<UserRole>, IMapping
    {
        public UserRoleMapping()
        {
            Table("userrole");
            Id(x => x.Id);
            Map(x => x.DateCreated);
            References<User>(x => x.User).Cascade.All();
            HasManyToMany<Role>(x => x.Roles).Cascade.All();
        }
    }
}