using AutoMapper;
using GymBE.Core.Context;
using GymBE.Core.Dtos.Equipment;
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
    public class EquipmentController : ControllerBase
    {
        private ApplicationDbContext _context { get; }
        private IMapper _mapper { get; }

        public EquipmentController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateEquipment([FromBody] EquipmentCreateDto dto)
        {
            Equipment newEquipment = _mapper.Map<Equipment>(dto);
            await _context.Equipments.AddAsync(newEquipment);
            await _context.SaveChangesAsync();

            return Ok("Equipment created succesfully");
        }

        //Read
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<EquipmentGetDto>>> getEquipment()
        {
            var equipment = await _context.Equipments.ToListAsync();
            var convertedEquipment = _mapper.Map<IEnumerable<EquipmentGetDto>>(equipment);

            return Ok(convertedEquipment);
        }

        //Read by id
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Equipment>> GetEquipmentById([FromRoute] long id)
        {
            var equipment = await _context.Equipments.FirstOrDefaultAsync(q => q.ID == id);

            if (equipment is null)
            {
                return NotFound("Equipment not found");

            }

            var convertedEquipment = _mapper.Map<EquipmentGetDto>(equipment);

            return Ok(convertedEquipment);
        }


        //Update
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEquipment([FromRoute] long id, [FromBody] EquipmentUpdateDto dto)
        {
            var equipment = await _context.Equipments.FirstOrDefaultAsync(q => q.ID == id);
            if (equipment is null)
            {
                return NotFound("Equipment not found");
            }

            equipment.Name = dto.Name;
            equipment.Type = dto.Type;
            equipment.Quantity = dto.Quantity;
            equipment.Price = dto.Price;

            await _context.SaveChangesAsync();

            return Ok("Equipment updated successfully");
        }


        //Delete
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEquipment([FromRoute] long id)
        {
            var equipment = await _context.Equipments.FirstOrDefaultAsync(q => q.ID == id);
            if (equipment is null)
            {
                return NotFound("Equipment not found");
            }
            _context.Equipments.Remove(equipment);
            await _context.SaveChangesAsync();
            return Ok("Equipment deleted succesfully");
        }

    }
}
