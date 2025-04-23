using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IServiceContact _serviceContact;

        public ContactsController(IServiceContact serviceContact) 
        {
            _serviceContact = serviceContact;
        }

        [HttpGet]
        public async Task<IActionResult> getAllContacts()
        {
            var result = await _serviceContact.GetAllContacts();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> createContact([FromBody] ContactBody body)
        {
            try 
            {
                if (body == null)
                    return BadRequest("Ingrese nombre y telefono.");

                int id = await _serviceContact.InsertContact(body);
                return Ok(id);

            } catch (Exception ex)
            {
                return StatusCode(500, $"No se pudo crear el contacto: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var result = await _serviceContact.GetContactById(id);

            if (result == null)
                return NotFound($"No se encontró el contacto de ID = {id}");

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactById(int id)
        {
            var result = await _serviceContact.DeleteContactById(id);

            if (result == 0)
                return NotFound($"No se encontró el contacto de ID = {id}");

            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContactById(int id, [FromBody] ContactDto body)
        {
            if (id != body.Id)
            {
                return BadRequest("No se encontro contacto con ese id.");
            }

            var result = await _serviceContact.UpdateContact(id, body);

            if (result == null) // o result == 0, según tu implementación
            {
                return NotFound($"No se encontró el contacto de ID = {id}");
            }

            return Ok(result);
        }

    }
}
