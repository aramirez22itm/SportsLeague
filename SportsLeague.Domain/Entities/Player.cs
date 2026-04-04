using SportsLeague.Domain.Entities;
using System.Text.Json.Serialization;
public class Player
{
    public int Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public int Number { get; private set; }
    public int TeamId { get; private set; }

    [JsonIgnore]
    public Team? Team { get; private set; }

    public Player(string firstName, string lastName, int number, int teamId)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("El nombre no puede estar vacío");

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("El apellido no puede estar vacío");

        FirstName = firstName;
        LastName = lastName;
        Number = number;
        TeamId = teamId;
    }
}