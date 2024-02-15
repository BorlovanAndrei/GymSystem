using AutoMapper;
using GymBE.Core.Context;
using GymBE.Core.Dtos.Membership;
using GymBE.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipController : ControllerBase
    {
        private ApplicationDbContext _context { get; }
        private IMapper _mapper { get; }

        public MembershipController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //CRUD

        //Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateMembership([FromBody] MembershipCreateDto dto)
        {
            Membership newMembership = _mapper.Map<Membership>(dto);
            await _context.Memberships.AddAsync(newMembership);
            await _context.SaveChangesAsync();

            return Ok("Membership created succesfully");
        }

        //Read
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<MembershipGetDto>>> getMemberships()
        {
            var memberships = await _context.Memberships.ToListAsync();
            var convertedMemberships = _mapper.Map<IEnumerable<MembershipGetDto>>(memberships);

            return Ok(convertedMemberships);
        }

        //Update
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateMembership([FromRoute]long id, [FromBody] MembershipUpdateDto dto)
        {
            var membership = await _context.Memberships.FirstOrDefaultAsync(q => q.ID == id);
            if (membership is null)
            {
                return NotFound("Membership not found");
            }

            membership.Name = dto.Name;
            membership.Price = dto.Price;
            membership.StartDate = dto.StartDate;
            membership.EndDate = dto.EndDate;

            await _context.SaveChangesAsync();

            return Ok("Membership updated successfully");
        }

        //Delete
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteMembership([FromRoute] long id)
        {
            var membership = await _context.Memberships.FirstOrDefaultAsync(q => q.ID == id);
            if (membership is null)
            {
                return NotFound("Membership not found");
            }
            _context.Memberships.Remove(membership);
            await _context.SaveChangesAsync();
            return Ok("Membership deleted succesfully");
        }

    }
}
