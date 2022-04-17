namespace DevHorizons.DAL.WebApi.Interfaces
{
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
