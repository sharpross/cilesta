namespace Cilesta.DataAnnotation.Katarina
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Core;
    using Interfaces;
    using Validators;

    public class Module : IModule
    {
        public string Code => "Cilesta.DataAnnotation.Katarina";

        public string[] Depends => new string[1];

        public void InitComponents(IWindsorContainer container)
        {
            container.Register(Component.For<IFieldValidator>().ImplementedBy<PasswordValidator>()
                .Named(PasswordValidator.Code));
            container.Register(Component.For<IFieldValidator>().ImplementedBy<StringValidator>()
                .Named(StringValidator.Code));
            container.Register(Component.For<IFieldValidator>().ImplementedBy<EmailValidator>()
                .Named(EmailValidator.Code));
        }

        public void Validate()
        {
        }
    }
}