namespace DevHorizons.DAL.WebApi.Models
{
    public class UserEvent : Event
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string DisplayName { get; set; }

        public string  Password { get; set; }
    }
}
