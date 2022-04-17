namespace DevHorizons.DAL.WebApi.Models.Commands
{
    using System.ComponentModel.DataAnnotations;
    using Models;
    using Newtonsoft.Json;
    using Shared;
    using Sql.Attributes;

    [Attributes.CommandBody("[dbo].[AddUser]")]
    public class AddUserCommand : CommandBody
    {
        [Required]
        [SqlParameter(Name = "UserName", Encrypted = true)]
        public string LoginName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string? MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string DisplayName { get; set; }

        [Required]
        [SqlParameter(Encrypted = true, SpecialType = SpecialType.Json)]
        public Profile Profile { get; set; }

        public bool Active { get; set; }

        public int AdminUserId { get; set; }

        [SqlParameter(Direction = Direction.Output)]
        public int? UserId { get; set; }

        [Required]
        [SqlParameter(Hashed = true)]
        public string Password { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        [SqlParameter(Type = Sql.SqlDbType.Json, Direction = Direction.Output)]
        public List<UserEvent>? Events { get; set; }
    }
}
