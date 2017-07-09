namespace Cilesta.Data.Katarina.Models
{
    using System;
    using Cilesta.Data.Models;

    public class Entity : IEntity
    {
        public virtual int Id { get; set; }

        public virtual DateTime DateCreated { get; set; }
    }
}
