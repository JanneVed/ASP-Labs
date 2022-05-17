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
    public class InterestsController : ControllerBase
    {
        private ILab3<Interest> _Lab3;

        public InterestsController(ILab3<Interest> lab3)
        {
            this._Lab3 = lab3;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInterests()
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
        public async Task<ActionResult<Interest>> GetInterest(int id)
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
        public async Task<ActionResult<Interest>> CreateInterest(Interest newInterest)
        {
            try
            {
                if (newInterest == null)
                {
                    return BadRequest();
                }

                var createdInterest = await _Lab3.Add(newInterest);
                return CreatedAtAction(nameof(GetInterest), new { id = newInterest.InterestId }, createdInterest);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create and send new object to the database");
            }
        }
    }
}
