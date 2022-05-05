using JobOpeningsAPI.Helper;
using JobsOpening.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOpeningsAPI.Manager
{
    public interface IJobManager
    {
        Task<List<Job>> GetJobList(PaginationFilter filter);
        
    }
}
