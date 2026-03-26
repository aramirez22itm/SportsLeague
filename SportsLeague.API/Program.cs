using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Registro del DbContext para que la API sepa usar SQL Server
builder.Services.AddDbContext<SportsLeague.DataAccess.ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro del Repositorio Genérico
builder.Services.AddScoped(typeof(SportsLeague.Domain.Interfaces.IGenericRepository<>), typeof(SportsLeague.DataAccess.Repositories.GenericRepository<>));

builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
