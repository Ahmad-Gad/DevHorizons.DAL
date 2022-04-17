namespace DevHorizons.DAL.WebApi.Models.Commands
{
    using System.ComponentModel.DataAnnotations;
    using Models;
    using Newtonsoft.Json;
    using Shared;
    using Sql.Attributes;

    [Attributes.CommandBody("[dbo].[AddBulkUsers]")]
    public class AddBuklUsersCommand : CommandBody
    {
        [Required]
        [SqlParameter(Name = "usersList", SpecialType = SpecialType.Structured)]
        public List<User> Users { get; set; }
    }
}
