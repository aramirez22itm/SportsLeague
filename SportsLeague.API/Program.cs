using Microsoft.EntityFrameworkCore;
using SportsLeague.Domain.Services;
using SportsLeague.Domain.Interfaces.Services;
using SportsLeague.DataAccess.Context;
using SportsLeague.DataAccess.Repositories;
using SportsLeague.Domain.Interfaces.Repositories;
using SportsLeague.DataAccess.Seeders;


var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<LeagueDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IRefereeRepository, RefereeRepository>();
builder.Services.AddScoped<IMatchRepository, MatchRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<IGoalRepository, GoalRepository>();
builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<IMatchResultRepository, MatchResultRepository>();
builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();
builder.Services.AddScoped<ITournamentSponsorRepository, TournamentSponsorRepository>();

// Services
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IRefereeService, RefereeService>();
builder.Services.AddScoped<IMatchService, MatchService>();
builder.Services.AddScoped<IMatchEventService, MatchEventService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<ISponsorService, SponsorService>();
builder.Services.AddScoped<ITournamentService, TournamentService>();
builder.Services.AddScoped<ITournamentSponsorService, TournamentSponsorService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<LeagueDbContext>();
    //await context.Database.MigrateAsync(); // Aplica las migraciones automáticamente
    //await DataSeeder.SeedAsync(context);    // Ejecuta tu Seeder
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
