namespace DevHorizons.DAL.WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Services;

    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> logger;
        private readonly ProductService productService;
        public ProductController(ILogger<ProductController> logger, ProductService productService)
        {
            this.logger = logger;
            this.productService = productService;
        }

        /// <summary>
        ///    Add new product to the database.
        /// </summary>
        /// <param name="product">The product details.</param>
        /// <returns>
        ///    Reference of the post instance of the "<see cref="Product" />" populated with all the returned data from the database.
        /// </returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>08/03/2022 02:22 AM</DateTime>
        /// </Created>
        [HttpPost("AddProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Product>> AddUser([FromBody] Product product)
        {
            var result = await this.productService.AddProduct(product);
            if (result != null)
            {
                return this.Ok(result);
            }
            else
            {
                return new ObjectResult("Something went wrong. Please check the logs for further details!") { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

    }
}
