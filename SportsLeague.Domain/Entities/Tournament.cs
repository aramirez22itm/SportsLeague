namespace SportsLeague.Domain.Entities
{
    public class Tournament
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Season { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public Tournament(string name, string season, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("El nombre del torneo no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(season))
                throw new ArgumentException("La temporada no puede estar vacía.");

            if (endDate < startDate)
                throw new ArgumentException("La fecha de fin no puede ser anterior a la fecha de inicio.");

            Name = name;
            Season = season;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void UpdateDates(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
                throw new ArgumentException("La fecha de fin no puede ser anterior a la fecha de inicio.");

            StartDate = startDate;
            EndDate = endDate;
        }
    }
}