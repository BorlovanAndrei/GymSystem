using AutoMapper;
using GymBE.Core.Context;
using GymBE.Core.Dtos.Membership;
using GymBE.Core.Dtos.Staff;
using GymBE.Core.Dtos.User;
using GymBE.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ApplicationDbContext _context { get; }
        private IMapper _mapper { get; }

        public UserController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto dto)
        {
            User newUser = _mapper.Map<User>(dto);
            await _context.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return Ok("User created succesfully");
        }

        // Read
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<UserGetDto>>> GetUser()
        {
            var user = await _context.Users.Include(u => u.Membership).ToListAsync();
            var convertedUser = _mapper.Map<IEnumerable<UserGetDto>>(user);

            return Ok(convertedUser);
        }

        //Read by id
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<UserGetDto>> GetUserById([FromRoute] long id)
        {
            var user = await _context.Users.Include(u => u.Membership).FirstOrDefaultAsync(q => q.ID == id);

            if (user is null)
            {
                return NotFound("Equipment not found");

            }
            var convertedUser = _mapper.Map<UserGetDto>(user);


            return Ok(convertedUser);
        }


        // Update 
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] long id, [FromBody] UserUpdateDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(q => q.ID == id);
            if (user is null)
            {
                return NotFound("User not found");
            }

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;
            user.Password = dto.Password;
            user.MembershipId = dto.MembershipId;

            await _context.SaveChangesAsync();

            return Ok("User updated successfully");

        }


        //Delete
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] long id)
        {

            var user = await _context.Users.FirstOrDefaultAsync(q => q.ID == id);
            if (user is null)
            {
                return NotFound("User not found");
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok("User deleted succesfully");

        }



    }
}
