using Microsoft.EntityFrameworkCore;
using SportsLeague.DataAccess.Context;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Interfaces.Repositories;


namespace SportsLeague.DataAccess.Repositories
{
    public class RefereeRepository : GenericRepository<Referee>, IRefereeRepository
    {
        private readonly LeagueDbContext _context;

        public RefereeRepository(LeagueDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Referee>> GetByNationalityAsync(string nationality)
        {
            return await _context.Referees
                .Where(r => r.Nationality.ToLower() == nationality.ToLower())
                .ToListAsync();
        }
    }
}
