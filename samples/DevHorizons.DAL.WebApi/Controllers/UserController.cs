namespace DevHorizons.DAL.WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Models.Commands;
    using Services;

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> logger;
        private readonly UserService userService;
        public UserController(ILogger<UserController> logger, UserService userService)
        {
            this.logger = logger;
            this.userService = userService;
        }

        /// <summary>
        ///    Add new user to the database.
        /// </summary>
        /// <param name="userCommand">The add user command information as an instance of the "<see cref="AddUserCommand" />".</param>
        /// <returns>
        ///    Reference of the post instance of the "<see cref="AddUserCommand" />" populated with all the returned data from the database.
        /// </returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>10/02/2022 09:49 PM</DateTime>
        /// </Created>
        [HttpPost("AddUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AddUserCommand>> AddUser([FromBody] AddUserCommand userCommand)
        {
            var result = await this.userService.AddUser(userCommand);
            if (result != null)
            {
                return this.Ok(result);
            }
            else
            {
                return new ObjectResult("Something went wrong. Please check the logs for further details!") { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        /// <summary>
        ///    Add a list/collection of new users to the database.
        /// </summary>
        /// <param name="userCommandList">The list of the add user command information as a list of "<see cref="AddUserCommand" />".</param>
        /// <returns>
        ///    Reference of the post instance of a list of the "<see cref="AddUserCommand" />" populated with all the returned data from the database.
        /// </returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>10/02/2022 09:49 PM</DateTime>
        /// </Created>
        [HttpPost("AddUserList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<AddUserCommand>>> AddUserList([FromBody] List<AddUserCommand> userCommandList)
        {
            var result = await this.userService.AddUserList(userCommandList);
            if (result != null)
            {
                return this.Ok(result);
            }
            else
            {
                return new ObjectResult("Something went wrong. Please check the logs for further details!") { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        /// <summary>
        ///    Add list/collection of new users to the database as bulk insert in one operation.
        /// </summary>
        /// <param name="userCommandList">The list of the add user command information as a list of "<see cref="AddUserCommand" />".</param>
        /// <returns>
        ///    Reference of the post instance of a list of the "<see cref="AddUserCommand" />" populated with all the returned data from the database.
        /// </returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>10/02/2022 09:49 PM</DateTime>
        /// </Created>
        [HttpPost("AddBuklUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> AddUserList([FromBody] AddBuklUsersCommand buklUsersCommand)
        {
            var result = await this.userService.AddUserBulkUsers(buklUsersCommand);
            if (result)
            {
                return this.Ok(result);
            }
            else
            {
                return new ObjectResult("Something went wrong. Please check the logs for further details!") { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        /// <summary>
        ///   Verifies login command information.
        /// </summary>
        /// <param name="verifyLoginCommand">The verify login command information as an instance of the "<see cref="AddUserCommand" />".</param>
        /// <returns>
        ///    Reference of the post instance of the "<see cref="VerifyLoginCommand" />" populated with all the returned data from the database.
        /// </returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>10/02/2022 09:49 PM</DateTime>
        /// </Created>
        [HttpPost("VerifyLogin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VerifyLoginCommand>> VerifyLogin([FromBody] VerifyLoginCommand verifyLoginCommand)
        {
            var result = await this.userService.VerifyLogin(verifyLoginCommand);
            if (result != null)
            {
                return this.Ok(result);
            }
            else
            {
                return new ObjectResult("Something went wrong. Please check the logs for further details!") { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        /// <summary>
        ///    Gets a list with all the existing users in the database.
        /// </summary>
        /// <param name="getAllUsersCommand">The get all users command information as an instance of the "<see cref="GetAllUsers" />".</param>
        /// <returns>
        ///    Reference of the post instance of the "<see cref="VerifyLoginCommand" />" populated with all the returned data from the database.
        /// </returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>10/02/2022 09:49 PM</DateTime>
        /// </Created>
        [HttpPost("GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<User>>> GetAllUsers([FromBody] GetAllUsersCommand getAllUsersCommand)
        {
            var result = await this.userService.GetAllUsers(getAllUsersCommand);
            if (result != null)
            {
                return this.Ok(result);
            }
            else
            {
                return new ObjectResult("Something went wrong. Please check the logs for further details!") { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        /// <summary>
        ///    Gets a list with all the existing users in the database.
        /// </summary>
        /// <param name="getAllUsersCommand">The get all users command information as an instance of the "<see cref="GetAllUsers" />".</param>
        /// <returns>
        ///    Reference of the post instance of the "<see cref="VerifyLoginCommand" />" populated with all the returned data from the database.
        /// </returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>10/02/2022 09:49 PM</DateTime>
        /// </Created>
        [HttpPost("GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> GetUser([FromBody] GetUserCommand getUserCommand)
        {
            var result = await this.userService.GetUser(getUserCommand);
            if (result != null)
            {
                return this.Ok(result.Count> 0? result[0]: default(User));
            }
            else
            {
                return new ObjectResult("Something went wrong. Please check the logs for further details!") { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }
    }
}