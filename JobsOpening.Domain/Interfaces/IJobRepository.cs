using JobsOpening.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsOpening.Domain.Interfaces
{
    public interface IJobRepository : IGenericRepository<Job>
    {
        Task<Job> GetJobById(int id);
        Task<IEnumerable<Job>> GetAll(string querystring);
        Task<int> GetJobCount();
    }
}
