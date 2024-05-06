using System;
using System.Collections.Generic;
using System.Linq;
using webproject.Models; // Assuming your model classes are in the "Models" folder

namespace webproject.Repositories
{
    public class KKRepository
    {
        private readonly TeamContext _dbContext; 

        public KKRepository(TeamContext dbContext) => _dbContext = dbContext;

        public KKRepository()
        {
        }

        public void Create(KarachiKings team)
        {
            _dbContext.KarachiKings.Add(team);
            _dbContext.SaveChanges();
        }

        public KarachiKings GetById(int id)
        {
            return _dbContext.KarachiKings.FirstOrDefault(t => t.Id == id);
        }

        public List<KarachiKings> GetAll()
        {
            return _dbContext.KarachiKings.ToList();
        }

        public void Update(KarachiKings team)
        {
            _dbContext.KarachiKings.Update(team);
            _dbContext.SaveChanges();
        }

        public void Delete(KarachiKings team)
        {
            _dbContext.KarachiKings.Remove(team);
            _dbContext.SaveChanges();
        }
    }
}
