using JobPortal.Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.RepositoryPattern
{
    public class EFRepository : IEFRepository
    {
        private readonly ApplicationDbContext _context;

        public EFRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(object entity)
        {
            _context.Add(entity);
        }

        public void Update(object entity)
        {
            _context.Update(entity);
        }

        public void Remove(object entity)
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }


        public IEnumerable<Job> GetJobs()
        {
            return _context.Job;
        }

        public Job GetJobById(int id)
        {
            return _context.Job.FirstOrDefault(x => x.JobId == id);
        }
    }
}
