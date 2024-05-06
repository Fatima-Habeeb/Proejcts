using System;
using System.Collections.Generic;
using System.Linq;
using webproject.Models; // Assuming your model classes are in the "Models" folder

namespace webproject.Repositories
{
    public class PZRepository
    {
        private readonly TeamContext _dbContext; // Replace YourDbContext with your actual DbContext class

        public PZRepository(TeamContext dbContext) => _dbContext = dbContext;

        public PZRepository()
        {
        }

        public void Create(PeshawarZalmi team)
        {
            _dbContext.PeshawarZalmi.Add(team);
            _dbContext.SaveChanges();
        }

        public PeshawarZalmi GetById(int id)
        {
            return _dbContext.PeshawarZalmi.FirstOrDefault(t => t.Id == id);
        }

        public List<PeshawarZalmi> GetAll()
        {
            return _dbContext.PeshawarZalmi.ToList();
        }

        public void Update(PeshawarZalmi team)
        {
            _dbContext.PeshawarZalmi.Update(team);
            _dbContext.SaveChanges();
        }

        public void Delete(PeshawarZalmi team)
        {
            _dbContext.PeshawarZalmi.Remove(team);
            _dbContext.SaveChanges();
        }
    }
}
