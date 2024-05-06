using System;
using System.Collections.Generic;
using System.Linq;
using webproject.Models; 
namespace webproject.Repositories
{
    public class QGRepository
    {
        private readonly TeamContext _dbContext; 

        public QGRepository(TeamContext dbContext) => _dbContext = dbContext;

        public QGRepository()
        {
        }

        public void Create(QuettaGladiators team)
        {
            _dbContext.QuettaGladiators.Add(team);
            _dbContext.SaveChanges();
        }

        public QuettaGladiators GetById(int id)
        {
            return _dbContext.QuettaGladiators.FirstOrDefault(t => t.Id == id);
        }

        public List<QuettaGladiators> GetAll()
        {
            return _dbContext.QuettaGladiators.ToList();
        }

        public void Update(QuettaGladiators team)
        {
            _dbContext.QuettaGladiators.Update(team);
            _dbContext.SaveChanges();
        }

        public void Delete(QuettaGladiators team)
        {
            _dbContext.QuettaGladiators.Remove(team);
            _dbContext.SaveChanges();
        }
    }
}
