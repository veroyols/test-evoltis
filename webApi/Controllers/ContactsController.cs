using Application.Interface;
using Application.UseCase.GetAll;
using Microsoft.AspNetCore.Http;
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
        public IActionResult createÁllContact() 
        {
            var result = _serviceContact.GetAll();
            return new JsonResult(result);
        }
    }
}
