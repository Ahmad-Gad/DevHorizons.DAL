namespace DevHorizons.DAL.WebApi.Models
{
    using Attributes;
    using Sql;

    [DataRow(Name = "[dbo].[Product]", AllowedActions = CommandAction.Insert | CommandAction.Update)]
    public class Product : SqlDataTable
    {
        [DataField(NotMapped = true)]
        public long? ProductId
        {
            get
            {
                return this.Identity;
            }
        }

        [DataField(InsertedOutput = true)]
        public Guid ProductGuid { get; set; }

        public string ProductName { get; set; }

        public string ProductCategories { get; set; }

        public string ProductBrands { get; set; }

        public string DetailsStructure { get; set; }

        [DataField(InsertedOutput = true)]
        public bool? Active { get; set; }

        public string Events { get; set; }

        public string Description { get; set; }
    }
}
