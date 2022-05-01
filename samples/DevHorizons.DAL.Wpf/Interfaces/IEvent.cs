namespace DevHorizons.DAL.Wpf.Interfaces
{
    using System;
    using Models;

    public interface IEvent
    {
        EventAction Action { get; set; }

        DateTime ActionDate { get; set; }

        string UserName { get; set; }

        string FirstName { get; set; }

        string MiddleName { get; set; }

        string LastName { get; set; }

        string DisplayName { get; set; }

        string Email { get; set; }

        string Password { get; set; }

        bool Active { get; set; }

        string DbUser { get; set; }

        int AdminUserId { get; set; }
    }
}
