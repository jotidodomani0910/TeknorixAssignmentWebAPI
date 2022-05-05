using JobsOpening.Domain.Interfaces;
using JobsOpening.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsOpening.Repository
{
    public class JobRespository : GenericRepository<Job>, IJobRepository
    {

        public JobRespository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {

        }
        public async Task<IEnumerable<Job>> GetAll(string querystring)
        {
            try
            {
                var response = await context.Jobs.Include(x => x.Department).Include(y => y.Location).Where(x => EF.Functions.Like(x.Description, querystring)).ToListAsync<Job>();
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(JobRespository));
                return new List<Job>();
            }
        }
        public override async Task<bool> Update(int id, Job entity)
        {
            try
            {
                var existingJob = await dbSet.Where(x => x.Id == id)
                                                    .FirstOrDefaultAsync();

                if (existingJob == null)
                    return await Add(entity);

                existingJob.Title = entity.Title;
                existingJob.Description = entity.Description;
                existingJob.Department = entity.Department;
                existingJob.Location = entity.Location;
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(JobRespository));
                return false;
            }
        }
        public override async Task<bool> Delete(int id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.Id == id)
                                        .FirstOrDefaultAsync();

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(JobRespository));
                return false;
            }
        }

        public async Task<Job> GetJobById(int id)
        {
            var job = context.Jobs.Where(x => x.Id == id).Include(x => x.Department).Include(y => y.Location).FirstOrDefault();
            return job;
        }

        public async Task<int> GetJobCount()
        {
            return context.Jobs.Include(x => x.Department).Include(y => y.Location).Count();

        }
    }

}