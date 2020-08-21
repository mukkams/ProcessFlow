
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserStoreAPI.Data.UserStore;
using UserStoreAPI.DTOs;

namespace UserStoreAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserStoreRepository _repo;
        private readonly IMapper _mapper;

        public UsersController(IUserStoreRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsersAsync();
            return Ok(_mapper.Map<IEnumerable<UserForListDTO>>(users));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        //[AllowAnonymous]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUserAsync(id);

            return Ok(_mapper.Map<UserForDetailedDTO>(user));
        }

    }
}