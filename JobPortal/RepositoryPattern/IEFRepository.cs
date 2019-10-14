using System.Collections.Generic;
using Models;

namespace JobPortal.RepositoryPattern
{
    public interface IEFRepository
    {
        void Add(object entity);
        Job GetJobById(int id);
        IList<Job> GetJobs();
        void Remove(object entity);
        bool SaveChanges();
        void Update(object entity);
    }
}