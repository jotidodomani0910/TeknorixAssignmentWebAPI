using JobsOpening.Domain.Interfaces;
using JobsOpening.Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobsOpening.Repository
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}
