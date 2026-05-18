using Microsoft.EntityFrameworkCore;
using SportsLeague.API.Services;
using SportsLeague.DataAccess;
using SportsLeague.DataAccess.Repositories;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Interfaces;
using SportsLeague.Domain.Interfaces.Repositories;
using SportsLeague.Domain.Interfaces.Services;
using System.ComponentModel.Design;

var builder = WebApplication.CreateBuilder(args);

// --- CONFIGURACIÓN DE BASE DE DATOS ---
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// --- REPOSITORIOS ---
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<IRefereeRepository, RefereeRepository>();
builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();
builder.Services.AddScoped<ISponsorRepository, SponsorRepository>();
builder.Services.AddScoped<IMatchRepository, MatchRepository>();

// builder.Services.AddScoped<ITournamentSponsorRepository, GenericRepository<TournamentSponsor>>();

// GENÉRICO
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// --- SERVICIOS ---
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IRefereeService, RefereeService>();
builder.Services.AddScoped<ITournamentService, TournamentService>();
builder.Services.AddScoped<ISponsorService, SponsorService>();
builder.Services.AddScoped<IMatchService, MatchService>();
// builder.Services.AddScoped<ITournamentSponsorService, TournamentSponsorService>();


// --- CONFIGURACIONES ---
builder.Services.AddAutoMapper(cfg => { }, AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();

// --- SWAGGER ---
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
