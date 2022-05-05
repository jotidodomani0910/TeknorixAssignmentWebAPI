using JobsOpening.Domain.Interfaces;
using JobsOpening.Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobsOpening.Repository
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        public LocationRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
            
        }
    }
}
