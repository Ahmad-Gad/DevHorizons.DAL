namespace DevHorizons.DAL.WebApi.Models
{
    using Attributes;
    using Shared;

    public class User
    {
        [DataField(DataDirection = DataDirection.Inbound)]
        public int UserId { get; set; }

        public string Email { get; set; }

        [DataField(Name = "UserName", Encrypted = true)]
        public string LoginName { get; set; }

        public string FirstName { get; set; }

        [DataField(CanBeNull = true)]
        public string? MiddleName { get; set; }
        
        public string LastName { get; set; }
        
        public string DisplayName { get; set; }
        
        [DataField(Encrypted = true, SpecialType = SpecialType.Json)]
        public Profile Profile { get; set; }

        public bool Active { get; set; }

        [DataField(DataDirection = DataDirection.Inbound)]
        public bool Locked { get; set; }

        [DataField(Hashed = true)]
        public string Password { get; set; }

        [DataField(SpecialType = SpecialType.Json, DataDirection = DataDirection.Inbound)]
        public List<UserEvent> Events { get; set; }
    }
}
