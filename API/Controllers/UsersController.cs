using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        // private readonly DataContext _context;
        private readonly IUserRepository _userRepository;
        public readonly IMapper _mapper;

        // public UsersController(DataContext context)
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        // Here we get all the users from localhost:5001/api/users
        [HttpGet]
        // public async Task<ActionResult<IEnumerable<AppUser>>>  GetUsers()
        public async Task<ActionResult<IEnumerable<MemberDto>>>  GetUsers()
        {
            var users = await _userRepository.GetMembersAsync();

            return Ok(users);
        }

        // Here we get the user by "username" from localhost:5001/api/users/username
        [HttpGet("{username}")]
        // public async Task<ActionResult<AppUser>>  GetUser(string username)
        public async Task<ActionResult<MemberDto>>  GetUser(string username)
        {
            return await _userRepository.GetMemberAsync(username);
        }
    }
}