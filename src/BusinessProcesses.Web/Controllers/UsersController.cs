using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessProcesses.Server.Domain.Models;
using BusinessProcesses.Server.Domain.ViewModels;
using BusinessProcesses.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace BusinessProcesses.Web.Controllers
{
    public class UsersController : Controller
    {
        public readonly UserService _service;
        public readonly IMapper _mapper;

        public UsersController(UserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<List<UserItem>> GetUsersList(int page = 1, int perPage = 10)
        {
            var list = await _service.GetUsersList(page, perPage);
            var result = _mapper.Map<List<User>, List<UserItem>>(list);

            return result;
        }
    }
}