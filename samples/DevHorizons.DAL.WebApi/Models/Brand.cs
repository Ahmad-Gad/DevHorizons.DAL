namespace DevHorizons.DAL.WebApi.Models
{
    using DevHorizons.DAL.Attributes;
    using System.Collections.Generic;

    public class Brand
    {
        public int BrandId { get; set; }

        public string BrandName { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        [DataField(NotMapped = true)]
        public List<BrandEvent> Events { get; set; }
    }
}
