using Lab_3_API.Model;
using Lab_3_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PIController : ControllerBase
    {
        private ILab3<PersonInterest> _Lab3;
        public PIController(ILab3<PersonInterest> pI)
        {
            _Lab3 = pI;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPIs()
        {
            try
            {
                return Ok(await _Lab3.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to retrive data from the database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonInterest>> GetPI(int id)
        {
            try
            {
                var result = await _Lab3.GetSingle(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to retrive data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<PersonInterest>> CreatePI(PersonInterest newPI)
        {
            try
            {
                if (newPI == null)
                {
                    return BadRequest();
                }
                var result = await _Lab3.Add(newPI);
                return CreatedAtAction(nameof(GetPI), new { id = newPI.InterestId }, newPI);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create and send new object to the database");
            }
        }
    }
}
