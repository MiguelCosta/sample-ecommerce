﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mpc.Ecommerce.BackOffice.Application.Dto;
using Mpc.Ecommerce.BackOffice.Application.Services.Users;

namespace Mpc.Ecommerce.BackOffice.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAsync()
        {
            var users = await _userService.GetAllAsync().ConfigureAwait(false);

            return users;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
