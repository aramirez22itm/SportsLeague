namespace SportsLeague.Domain.Entities
{
    public class Referee
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Nationality { get; private set; }

        public Referee(string firstName, string lastName, string nationality)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("El nombre no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("El apellido no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(nationality))
                throw new ArgumentException("La nacionalidad no puede estar vacía.");

            FirstName = firstName;
            LastName = lastName;
            Nationality = nationality;
        }
    }
}