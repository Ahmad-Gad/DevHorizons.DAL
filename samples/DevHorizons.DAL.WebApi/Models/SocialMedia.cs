namespace DevHorizons.DAL.WebApi.Models
{
    using Attributes;

    public class SocialMedia
    {
        [DataField(Encrypted = true)]
        public string LinkedIn { get; set; }

        public string? FaceBook { get; set; }

        public string? Twitter { get; set; }
    }
}
