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
    public class PeopleController : ControllerBase
    {
        private ILab3<Person> _Lab3;

        public PeopleController(ILab3<Person> lab3)
        {
            this._Lab3 = lab3;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPeople()
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
        public async Task<ActionResult<Person>> GetPerson(int id)
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

        [HttpGet("{search}/{name}")]
        public IActionResult Search(string name)
        {
            var searchResult = _Lab3.Search(name);
            if (searchResult.Any())
            {
                return Ok(searchResult);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Person>> CreateNewPerson(Person newPerson)
        {
            try
            {
                if (newPerson == null)
                {
                    return BadRequest();
                }

                var cretedPerson = await _Lab3.Add(newPerson);
                return CreatedAtAction(nameof(GetPerson), new { id = cretedPerson.PersonId }, cretedPerson);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create and send new object to the database");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> DeletePerson(int id)
        {
            try
            {
                var personToDelete = await _Lab3.GetSingle(id);
                if (personToDelete == null)
                {
                    return NotFound($"Product with ID {id} Not Found");
                }
                return await _Lab3.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete from the database");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Person>> UpdatePerson(int id, Person pers)
        {
            try
            {
                if (id != pers.PersonId)
                {
                    return BadRequest($"The person with ID {id} doesn't exist");
                }
                var personToUpdate = await _Lab3.GetSingle(id);
                if (personToUpdate == null)
                {
                    return NotFound();
                }
                return await _Lab3.Update(pers);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update data in the database");
            }
        }
    }
}
