namespace DevHorizons.DAL.WebApi.Models
{
    using Interfaces;
    public class Event : IEvent
    {
        public EventAction Action { get; set; }

        public DateTime ActionDate { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool Active { get; set; }

        public string DbUser { get; set; }

        public int AdminUserId { get; set; }
    }
}
