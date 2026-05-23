using SportsLeague.DataAccess.Context;
using EnumPosition = SportsLeague.Domain.Enums.PlayerPosition;
using Microsoft.EntityFrameworkCore;
using SportsLeague.Domain.Enums;


namespace SportsLeague.DataAccess.Seeders;

public static class DataSeeder
{
    public static async Task SeedAsync(LeagueDbContext context)
    {
        // 1. Condición: Solo puebla si las tablas están vacías 
        if (await context.Teams.AnyAsync()) return;

        // 2. EQUIPOS
        var teams = new List<Team>
        {
            new() { Name="Atlético Nacional", City="Medellín", Stadium="Atanasio Girardot" },
            new() { Name="Independiente Medellín", City="Medellín", Stadium="Atanasio Girardot" },
            new() { Name="América de Cali", City="Cali", Stadium="Pascual Guerrero" },
            new() { Name="Deportivo Cali", City="Cali", Stadium="Deportivo Cali" },
            new() { Name="Junior FC", City="Barranquilla", Stadium="Metropolitano" },
            new() { Name="Millonarios FC", City="Bogotá", Stadium="El Campín" },
            new() { Name="Independiente Santa Fe", City="Bogotá", Stadium="El Campín" },
            new() { Name="Deportes Tolima", City="Ibagué", Stadium="Manuel Murillo Toro" },
            new() { Name="Atlético Bucaramanga", City="Bucaramanga", Stadium="Alfonso López" },
            new() { Name="Once Caldas", City="Manizales", Stadium="Palogrande" },
            new() { Name="Deportivo Pasto", City="Pasto", Stadium="Departamental Libertad" },
            new() { Name="Deportivo Pereira", City="Pereira", Stadium="Hernán Ramírez Villegas" },
            new() { Name="Águilas Doradas", City="Rionegro", Stadium="Alberto Grisales" },
            new() { Name="Boyacá Chicó FC", City="Tunja", Stadium="La Independencia" },
            new() { Name="Jaguares de Córdoba", City="Montería", Stadium="Jaraguay" },
            new() { Name="Alianza Valledupar FC", City="Valledupar", Stadium="Armando Maestre" },
            new() { Name="Fortaleza FC", City="Bogotá", Stadium="Metropolitano de Techo" },
            new() { Name="Llaneros FC", City="Villavicencio", Stadium="Bello Horizonte" },
            new() { Name="Cúcuta Deportivo", City="Cúcuta", Stadium="General Santander" },
            new() { Name="Internacional de Bogotá", City="Bogotá", Stadium="Metropolitano de Techo" }
        };
        context.Teams.AddRange(teams);
        await context.SaveChangesAsync();

        // 3. JUGADORES (Ejemplo con 20 equipos) 
        var players = new List<Player>();
        foreach (var team in teams)
        {
         //   players.Add(new Player { FirstName = "Jugador1", LastName = "Test", Number = 10, Position = (SportsLeague.Domain.Enums.PlayerPosition)0, TeamId = team.Id, BirthDate = new DateTime(2000, 1, 1) });
         //   players.Add(new Player { FirstName = "Jugador2", LastName = "Test", Number = 11, Position = (SportsLeague.Domain.Enums.PlayerPosition)1, TeamId = team.Id, BirthDate = new DateTime(2000, 1, 1) });
        }
        context.Players.AddRange(players);

        // 4. ÁRBITROS
        var referees = new List<Referee>
        {
            new() { FirstName="Wilmar", LastName="Roldán", Nationality="Colombia" },
            new() { FirstName="Andrés", LastName="Rojas", Nationality="Colombia" },
            new() { FirstName="Carlos", LastName="Betancur", Nationality="Colombia" },
            new() { FirstName="Jhon", LastName="Hinestroza", Nationality="Colombia" }
        };
        context.Referees.AddRange(referees);

        // 5. TORNEO
        var tournament = new Tournament { Name = "Liga BetPlay 2026-I", Season = "2026-I", StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(6), Status = TournamentStatus.InProgress };
        context.Tournaments.Add(tournament);
        await context.SaveChangesAsync();

        foreach (var team in teams)
        {
            context.TournamentTeams.Add(new TournamentTeam { TournamentId = tournament.Id, TeamId = team.Id, RegisteredAt = DateTime.UtcNow });
        }
        await context.SaveChangesAsync();
    }
}