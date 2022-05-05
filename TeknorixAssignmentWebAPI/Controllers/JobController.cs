using AutoMapper;
using JobOpeningsAPI.Helper;
using JobOpeningsAPI.Manager;
using JobOpeningsAPI.Model;
using JobsOpening.Domain.Interfaces;
using JobsOpening.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobOpeningsAPI.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IJobManager _jobManager;
        public JobController(IUnitOfWork unitOfWork, IMapper mapper, IJobManager jobManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jobManager = jobManager;
        }

        [HttpPost("list")]
        [ProducesResponseType(typeof(PagedResponse<List<Job>>), 200)]
        public async Task<IActionResult> GetallJobs([FromBody] PaginationFilter filter)
        {
            List<Job> data = await _jobManager.GetJobList(filter);
            var response = new PagedResponse<List<Job>>(data, filter.PageNumber, filter.PageSize);
            response.TotalRecords = await _unitOfWork.JobRepository.GetJobCount();
            return Ok(response);

        }

        // GET api/<JobsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var jobOpening = _unitOfWork.JobRepository.GetJobById(id).Result;
            if (jobOpening == null)
                return NotFound();
            return Ok(new Response<Job>(jobOpening));
        }

        // POST api/<JobsController>
        [HttpPost]
        public async Task<IActionResult> Create(JobDTO job)
        {
            if (ModelState.IsValid)
            {

                await _unitOfWork.JobRepository.Add(_mapper.Map<Job>(job));

                await _unitOfWork.CompleteAsync();

                return CreatedAtAction("Create", new { job.Title }, job);
            }

            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        // PUT api/<JobsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, JobDTO job)
        {
            await _unitOfWork.JobRepository.Update(id, _mapper.Map<Job>(job));
            await _unitOfWork.CompleteAsync();
            return Ok("Job Updated successfully");
        }

    }
}
