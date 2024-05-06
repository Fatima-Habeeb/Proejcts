using System;
using System.Collections.Generic;
using System.Linq;
using webproject.Models; // Assuming your model classes are in the "Models" folder

namespace webproject.Repositories
{
    public class MSRepository
    {
        private readonly TeamContext _dbContext; // Replace YourDbContext with your actual DbContext class

        public MSRepository(TeamContext dbContext)
        {
            _dbContext = dbContext;
        }

        public MSRepository()
        {
        }

        public void Create(MultanSultans team)
        {
            _dbContext.MultanSultans.Add(team);
            _dbContext.SaveChanges();
        }

        public MultanSultans GetById(int id)
        {
            return _dbContext.MultanSultans.FirstOrDefault(t => t.Id == id);
        }

        public List<MultanSultans> GetAll()
        {
            return _dbContext.MultanSultans.ToList();
        }

        public void Update(MultanSultans team)
        {
            _dbContext.MultanSultans.Update(team);
            _dbContext.SaveChanges();
        }

        public void Delete(MultanSultans team)
        {
            _dbContext.MultanSultans.Remove(team);
            _dbContext.SaveChanges();
        }
    }
}
