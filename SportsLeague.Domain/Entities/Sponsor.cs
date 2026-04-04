using SportsLeague.Domain.Enums;

namespace SportsLeague.Domain.Entities
{
    public class Sponsor
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string ContactEmail { get; private set; }
        public string? Phone { get; private set; }
        public string? WebsiteUrl { get; private set; }
        public SponsorCategory Category { get; private set; }

        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; private set; }

        public Sponsor(string name, string contactEmail, SponsorCategory category, string? phone = null, string? websiteUrl = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("El nombre del patrocinador no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(contactEmail))
                throw new ArgumentException("El email de contacto no puede estar vacío.");

            Name = name;
            ContactEmail = contactEmail;
            Category = category;
            Phone = phone;
            WebsiteUrl = websiteUrl;
        }

        public void UpdateContact(string? phone, string? websiteUrl)
        {
            Phone = phone;
            WebsiteUrl = websiteUrl;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}