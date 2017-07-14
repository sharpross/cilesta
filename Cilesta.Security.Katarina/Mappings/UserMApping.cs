namespace Cilesta.Security.Katarina.Mappings
{
    using Cilesta.Data.Interfaces;
    using Cilesta.Security.Katarina.Entities;
    using FluentNHibernate.Mapping;

    public class UserMapping : ClassMap<User>, IMapping
    {
        public UserMapping()
        {
            Table("users");
            Id(x => x.Id);
            Map(x => x.DateCreated);
            Map(x => x.Login)
                .Unique()
                .Not.Nullable();
            Map(x => x.Password)
                .Not.Nullable();
            Map(x => x.Email)
                .Unique()
                .Not.Nullable();
            Map(x => x.Blocked).Default("false");
        }
    }
}
