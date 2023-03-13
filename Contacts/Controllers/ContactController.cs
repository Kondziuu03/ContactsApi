using Contacts.Interfaces;
using Contacts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Contacts.Controllers
{
    [Route("api/company/{companyId}/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<ContactDto>> GetAll([FromRoute]int companyId)
        {
            var result = _contactService.GetAll(companyId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<ContactDto> GetById([FromRoute] int companyId, [FromRoute]int id)
        {
            var contact = _contactService.GetById(companyId,id);

            return Ok(contact);
        }

        [HttpPost]
        public ActionResult CreateContact([FromRoute]int companyId, [FromBody]CreateContactDto dto)
        {
            var id = _contactService.Create(companyId,dto);
            return Created($"/api/company/{companyId}/contact/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]int companyId, [FromRoute] int id)
        {
            _contactService.Delete(companyId, id);
            return NoContent();
        }

    }
}
