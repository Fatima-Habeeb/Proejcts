using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using webproject.Models; 

namespace webproject.Repositories
{
    public class LQRepository
    {
        private  TeamContext _dbContext;

        public LQRepository(TeamContext dbContext)
        {
            _dbContext = dbContext;
        }

        public LQRepository()
        {
        }

        public void Create(LahoreQalandars team)
        {
            _dbContext.LahoreQalandars.Add(team);
            _dbContext.SaveChanges();
        }

        public LahoreQalandars GetById(int id)
        {
            return _dbContext.LahoreQalandars.FirstOrDefault(t => t.Id == id);
        }

        public List<LahoreQalandars> GetAll()
        {
            return _dbContext.LahoreQalandars.ToList();
        }

        public void Update(LahoreQalandars team)
        {
            _dbContext.LahoreQalandars.Update(team);
            _dbContext.SaveChanges();
        }

        public void Delete(LahoreQalandars team)
        {
            _dbContext.LahoreQalandars.Remove(team);
            _dbContext.SaveChanges();
        }
    }
}
