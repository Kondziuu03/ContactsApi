using Contacts.Interfaces;
using Contacts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Contacts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<CompanyDto>> GetAll()
        {
            var result = _companyService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<ContactDto> GetById([FromRoute] int id)
        {
            var result = _companyService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreateCompany([FromBody]CreateCompanyDto dto)
        {
            var id = _companyService.Create(dto);
            return Created($"/api/company/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]int id)
        {
            _companyService.Delete(id);
            return NoContent();
        }
    }
}
