﻿namespace Cilesta.Security.Katarina.Entities
{
    using Cilesta.Data.Katarina.Models;
    using Cilesta.Security.Models;

    public class Role : Entity, IRole
    {
        public virtual string Name { get; set; }
    }
}
