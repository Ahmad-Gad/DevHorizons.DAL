namespace DevHorizons.DAL.Test.Models
{
    using System;
    public class Product
    {
        public int? ProductId { get; set; }

        public Guid? ProductGuid { get; set; }

        public DateTime? Modified { get; set; }

        public decimal? Price { get; set; }

        public float? Discount { get; set; }

        public double? PriceTotal { get; set; }

        public char? DiscountCode { get; set; }

        public bool? Active   { get; set; }

        public string ProductName { get; set; }
    }
}
