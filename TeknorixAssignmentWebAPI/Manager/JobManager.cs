using JobOpeningsAPI.Helper;
using JobsOpening.Domain.Interfaces;
using JobsOpening.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOpeningsAPI.Manager
{
    public class JobManager : IJobManager
    {

        private readonly IUnitOfWork _unitOfWork;
        public JobManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Job>> GetJobList(PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await _unitOfWork.JobRepository.GetAll(filter.SubString);
            var responsed = pagedData.Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize);

            return responsed.ToList();
        }

       
    }
}
