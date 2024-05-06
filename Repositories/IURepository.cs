using System;
using System.Collections.Generic;
using System.Linq;
using webproject.Models; // Assuming your model classes are in the "Models" folder

namespace WebProject.Repositories
{
    /*public class IURepository
    {
        private readonly TeamContext _dbContext; // Replace YourDbContext with your actual DbContext class

        public IURepository(TeamContext dbContext) => _dbContext = dbContext;

        public IURepository()
        {
        }

        public void Create(IslamabadUnited team)
        {
            _dbContext.IslamabadUnited.Add(team);
            _dbContext.SaveChanges();
        }

        public IslamabadUnited GetById(int id)
        {
            return _dbContext.IslamabadUnited.FirstOrDefault(t => t.Id == id);
        }

        public List<IslamabadUnited> GetAll()
        {
            return _dbContext.IslamabadUnited.ToList();
        }

        public void Update(IslamabadUnited team)
        {
            _dbContext.IslamabadUnited.Update(team);
            _dbContext.SaveChanges();
        }

        public void Delete(IslamabadUnited team)
        {
            _dbContext.IslamabadUnited.Remove(team);
            _dbContext.SaveChanges();
        }
    }*/
}
