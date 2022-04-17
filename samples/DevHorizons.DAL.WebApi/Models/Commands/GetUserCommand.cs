namespace DevHorizons.DAL.WebApi.Models.Commands
{
    using Shared;

    [Attributes.CommandBody("[dbo].[GetUserByUserId]")]
    public class GetUserCommand : CommandBody
    {
        public int UserId { get; set; }
    }
}
