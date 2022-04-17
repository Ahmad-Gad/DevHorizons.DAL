namespace DevHorizons.DAL.WebApi.Models
{
    public class Profile
    {
        public string Country { get; set; }

        public string City { get; set; }

        public string PostCode { get; set; }

        public string Address { get; set; }

        [Attributes.DataField(Encrypted = true)]
        public string Mobile { get; set; }

        public string? Phone { get; set; }

        [Attributes.DataField()]
        public SocialMedia SocialMedia { get; set; }
    }
}
