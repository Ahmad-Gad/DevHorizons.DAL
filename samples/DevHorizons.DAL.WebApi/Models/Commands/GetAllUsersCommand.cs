namespace DevHorizons.DAL.WebApi.Models.Commands
{
    using Shared;

    [Attributes.CommandBody("[dbo].[GetAllUsers]")]
    public class GetAllUsersCommand : CommandBody
    {
    }
}
