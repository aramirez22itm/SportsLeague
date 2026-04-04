namespace SportsLeague.Domain.Entities
{
    public class Team
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string City { get; private set; }
        public string? Stadium { get; private set; }
        public string? LogoUrl { get; private set; }
        public DateTime FoundedDate { get; private set; }

        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; private set; }

        public Team(string name, string city, DateTime foundedDate, string? stadium = null, string? logoUrl = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("El nombre del equipo no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("La ciudad no puede estar vacía.");

            if (foundedDate > DateTime.UtcNow)
                throw new ArgumentException("La fecha de fundación no puede ser futura.");

            Name = name;
            City = city;
            FoundedDate = foundedDate;
            Stadium = stadium;
            LogoUrl = logoUrl;
        }

        public void Update(string? stadium, string? logoUrl)
        {
            Stadium = stadium;
            LogoUrl = logoUrl;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}