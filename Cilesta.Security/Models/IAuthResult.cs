﻿namespace Cilesta.Security.Models
{
    public interface IAuthResult
    {
        bool Success { get; set; }

        string Message { get; set; }

        string Login { get; set; }

        string UserID { get; set; }
    }
}
