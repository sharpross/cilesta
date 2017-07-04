namespace Cilesta.Security.Models
{
    using Cilesta.Data.Models;

    public interface IRole : IEntity
    {
        string Name { get; set; }
    }
}
