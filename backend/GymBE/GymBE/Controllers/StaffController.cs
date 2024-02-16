using AutoMapper;
using GymBE.Core.Context;
using GymBE.Core.Dtos.Membership;
using GymBE.Core.Dtos.Staff;
using GymBE.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private ApplicationDbContext _context { get; }
        private IMapper _mapper { get; }

        public StaffController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateStaff([FromBody] StaffCreateDto dto)
        {
            Staff newStaff = _mapper.Map<Staff>(dto);
            await _context.Staffs.AddAsync(newStaff);
            await _context.SaveChangesAsync();

            return Ok("Staff created succesfully");
        }

        //Read
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<StaffGetDto>>> GetStaff()
        {
            var staffs = await _context.Staffs.ToListAsync();
            var convertedStaff = _mapper.Map<IEnumerable<StaffGetDto>>(staffs);

            return Ok(convertedStaff);
        }


        //Read by id
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<StaffGetDto>> GetStaffById([FromRoute] long id)
        {
            var staff = await _context.Staffs.FirstOrDefaultAsync(q => q.ID == id);

            if (staff is null)
            {
                return NotFound("Staff not found");

            }

            var convertedStaff = _mapper.Map<StaffGetDto>(staff);


            return Ok(convertedStaff);
        }


        //Update
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateStaff([FromRoute] long id, [FromBody] StaffUpdateDto dto)
        {
            var staff = await _context.Staffs.FirstOrDefaultAsync(q => q.ID == id);
            if (staff is null)
            {
                return NotFound("Staff not found");
            }

            staff.FirstName = dto.FirstName;
            staff.LastName = dto.LastName;
            staff.Email = dto.Email;
            staff.Password = dto.Password;

            await _context.SaveChangesAsync();

            return Ok("Staff updated successfully");
        }




        //Delete
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteStaff([FromRoute] long id)
        {
            var staff = await _context.Staffs.FirstOrDefaultAsync(q => q.ID == id);
            if (staff is null)
            {
                return NotFound("Staff not found");
            }
            _context.Staffs.Remove(staff);
            await _context.SaveChangesAsync();
            return Ok("Staff deleted succesfully");
        }
    }
}
