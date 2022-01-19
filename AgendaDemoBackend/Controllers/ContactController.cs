using AgendaDemoBackend.Models;
using AgendaDemoBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgendaDemoBackend.Controllers
{
    [ApiController]
    [Route("contacts")]
    public class ContactController : ControllerBase
    {
        private ContactService _service;

        public ContactController(ContactService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contact>> GetContacts() {
            return _service.GetAll().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Contact> GetContact(Guid id)
        {
            var contact = _service.GetById(id);

            if (contact == null)
                return NotFound();
            return contact;
        }

        [HttpPost]
        public ActionResult CreateContact(ContactDTO newContactDTO)
        {
            var newContact = new Contact
            {
                Id = Guid.NewGuid(),
                Name = newContactDTO.Name,
                Phone = newContactDTO.Phone,
                Email = newContactDTO.Email
            };
            
            var contact = _service.Create(newContact);
            return CreatedAtAction(nameof(CreateContact), new { id = contact!.Id}, contact);
        }

        [HttpPut]
        public ActionResult UpdateContact(Contact contactToUpdate)
        {
            var contact = _service.GetById(contactToUpdate.Id);
            if(contact is not null)
            {
                _service.Update(contactToUpdate);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteContact(Guid id)
        {
            var contact = _service.GetById(id);
            if(contact is not null)
            {
                _service.DeleteById(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
