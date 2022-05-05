using JobsOpening.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobsOpening.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        public IJobRepository JobRepository { get; private set; }
        public ILocationRepository LocationRepository { get; private set; }
        public IDepartmentRepository DepartmentRepository { get; private set; }


        public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            JobRepository = new JobRespository(context, _logger);
            LocationRepository = new LocationRepository(context, _logger);
            DepartmentRepository = new DepartmentRepository(context, _logger);
        }



        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

