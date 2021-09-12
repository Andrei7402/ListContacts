using ListContacts.Data.Entities;
using ListContacts.DataTransferObjects;
using ListContacts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListContacts.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListContactsController : ControllerBase
    {
        private readonly IListContactsServices _listContactsServices;

        public ListContactsController(IListContactsServices listContactsServices)
        {
            _listContactsServices = listContactsServices;
        }

        [HttpGet("/api/contacts/{id}")]
        public async Task<IActionResult> GetId(Guid id)
        {
            var results = _listContactsServices.GetId(id);
            return new ObjectResult(results);
        }

        [HttpGet("/api/contacts")]
        public async Task<ActionResult<IQueryable<Contacts>>> AllContacts()
        {
            var contacts = _listContactsServices.Get();
            return Ok(contacts);
        }

        [HttpPost("/api/add")]
        public async Task<IActionResult> Add([FromBody] ContactsDto contactsDto)
        {
            await _listContactsServices.CreateContacts(contactsDto);
            return Ok(contactsDto);
        }

        [HttpDelete("/api/delete/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _listContactsServices.DeleteContacts(id);
            return Ok();
        }

        [HttpPut("/api/put")]
        public async Task<ActionResult<Contacts>> Put([FromBody] Contacts contacts)
        {
            var results = await _listContactsServices.UpdateContacts(contacts);
            return Ok(results);
        }
    }
}
