using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessProcesses.Server.Domain.Models;
using BusinessProcesses.Server.Domain.ViewModels;
using BusinessProcesses.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace BusinessProcesses.Web.Controllers
{
    public class JobApiController : Controller
    {
        public readonly JobService _service;
        public readonly IMapper _mapper;

        public JobApiController(JobService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<ListJobItem>> GetJobsList(int page = 1, int perPage = 10)
        {
            var list = await _service.GetJobsList(page, perPage);
            var result = _mapper.Map<List<Job>, List<ListJobItem>>(list);

            return result;
        }

        [HttpGet]
        public async Task<Job> GetJobById(int id)
        {
            var list = await _service.GetJobById(id);
            return list;
        }
    }
}