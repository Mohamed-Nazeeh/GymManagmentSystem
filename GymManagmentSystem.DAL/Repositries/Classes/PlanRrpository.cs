using GymManagmentSystem.DAL.DbContexts;
using GymManagmentSystem.DAL.Models;
using GymManagmentSystem.DAL.Repositries.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentSystem.DAL.Repositries.Classes
{

     
    public class PlanRepository : IPLanRepository
    {
        private readonly GymDbContext _dbcontext;

        public PlanRepository(GymDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> AddAsync(Plan plan)
        {
            _dbcontext.Plans.Add(plan);
            return await _dbcontext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Plan plan)
        {
            _dbcontext.Plans.Remove(plan);
            return await _dbcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Plan>> GetAllAsync(bool tracing = false, CancellationToken ct = default)
        {
            IQueryable<Plan> query = tracing ? _dbcontext.Plans : _dbcontext.Plans.AsNoTracking();
            return await query.ToListAsync();
        }

        public async Task<Plan?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _dbcontext.Plans.FindAsync(id, ct); 
        }

        public async Task<int> UpdateAsync(Plan plan)
        {
            _dbcontext.Plans.Update(plan);
            return await _dbcontext.SaveChangesAsync(); 
        }
    }
}
