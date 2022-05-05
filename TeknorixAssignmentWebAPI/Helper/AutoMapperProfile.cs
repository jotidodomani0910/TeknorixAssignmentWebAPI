using AutoMapper;
using JobOpeningsAPI.Model;
using JobsOpening.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOpeningsAPI.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<JobDTO, Job>();
            CreateMap<Job, JobDTO>();
        }
    }
}
