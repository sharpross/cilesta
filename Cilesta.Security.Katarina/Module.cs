namespace Cilesta.Security.Katarina
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Cilesta.Core;
    using Cilesta.Data.Interfaces;
    using Cilesta.Domain.Katarina;
    using Cilesta.Security.Interfaces;
    using Cilesta.Security.Katarina.Entities;
    using Cilesta.Security.Katarina.Implimentation;
    using Cilesta.Security.Katarina.Interfaces;
    using Cilesta.Security.Katarina.Mappings;
    using Cilesta.Web.Interfaces;

    public class Module : IModule
    {
        public string Code => "Cilesta.Security.Katarina";

        public string[] Depends => new string[1];

        public void InitComponents(IWindsorContainer container)
        {
            container.RegisterDomainService<User>();
            container.RegisterDomainService<Role>();
            container.RegisterDomainService<UserRole>();
            container.RegisterDomainService<RolePermission>();
            container.RegisterDomainService<PermissionKey>();
            
            container.Register(Component.For<IFilterContainer>().ImplementedBy<FilterContainer>().LifeStyle.Transient);

            container.Register(Component.For<IUserManager>().ImplementedBy<UserManager>().LifeStyle.Transient);

            container.Register(Component.For<IAuthService>().ImplementedBy<AuthService>().LifeStyle.Transient);

            container.Register(Component.For<IUserService>().ImplementedBy<UserService>().LifeStyle.Transient);
            container.Register(Component.For<IRoleService>().ImplementedBy<RoleService>().LifeStyle.Transient);
            container.Register(Component.For<IUserRoleService>().ImplementedBy<UserRoleService>().LifeStyle.Transient);
            container.Register(Component.For<IPermissionService>().ImplementedBy<PermissionService>().LifeStyle.Transient);
            container.Register(Component.For<IRolePermissionService>().ImplementedBy<RolePermissionService>().LifeStyle.Transient);

            container.Register(Component.For<IMapping>().ImplementedBy<UserMapping>().LifeStyle.Transient);
            container.Register(Component.For<IMapping>().ImplementedBy<RoleMapping>().LifeStyle.Transient);
            container.Register(Component.For<IMapping>().ImplementedBy<UserRoleMapping>().LifeStyle.Transient);
            container.Register(Component.For<IMapping>().ImplementedBy<RolePermissionMapping>().LifeStyle.Transient);
            container.Register(Component.For<IMapping>().ImplementedBy<PermissionKeyMapping>().LifeStyle.Transient);

            container.Register(Component.For<IMigration>().ImplementedBy<UserMigration>().LifeStyle.Transient);
        }

        public void Validate()
        {
        }
    }
}
