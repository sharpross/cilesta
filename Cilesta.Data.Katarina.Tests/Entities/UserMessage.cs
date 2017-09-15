namespace Cilesta.Data.Katarina.Tests.Entities
{
    using System;
    using Cilesta.Data.Katarina.Models;

    public class UserMessage : Entity
    {
        public string Login { get; set; }

        public string Message { get; set; }

        public DateTime Name { get; set; }
    }
}
