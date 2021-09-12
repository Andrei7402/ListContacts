using ListContacts.Data;
using ListContacts.Data.Entities;
using ListContacts.DataTransferObjects;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ListContacts.Services
{
    public class ListContactServices : IListContactsServices
    {
        private readonly ListContactsContext _context;

        public ListContactServices(ListContactsContext context)
        {
            _context = context;
        }

        public IQueryable<Contacts> Get()
        {
            return _context.Contacts;
        }

        public async Task<Contacts> AddContacts(ContactsDto contactsDto)
        {
            var contacts = new Contacts()
            {
                Name = contactsDto.Name,
                MobilePhone = contactsDto.MobilePhone,
                JobTitle = contactsDto.JobTitle,
                BirthDate = contactsDto.BirthDate
            };

            await _context.AddAsync(contacts);

            return contacts;
        }

        public async Task<Contacts> CreateContacts(ContactsDto contacts)
        {
            var contactsDto = await AddContacts(contacts);
            await _context.SaveChangesAsync();
            return contactsDto;
        }

        public void DeleteContacts(Guid id)
        {
            var contactsId = _context.Contacts.Find(id);
            if (contactsId != null)
            {
                var contacts = _context.Contacts.FirstOrDefault(x => x.Id == id); ;
                _context.Contacts.Remove(contacts);
                _context.SaveChanges();
            }
        }

        public async Task<Contacts> UpdateContacts(Contacts contacts)
        {
            if (!_context.Contacts.Any(x => x.Id == contacts.Id))
            {
                var newContacts = new Contacts()
                {
                    Id = contacts.Id,
                    Name = contacts.Name,
                    MobilePhone = contacts.MobilePhone,
                    JobTitle = contacts.JobTitle,
                    BirthDate = contacts.BirthDate
                };
                await _context.AddAsync(newContacts);
                await _context.SaveChangesAsync();
                return newContacts;
            }

            _context.Update(contacts);
            await _context.SaveChangesAsync();
            return contacts ?? null;
        }

        public ContactsDto GetId(Guid id)
        {
            if (_context.Contacts.Find(id) != null)
            {
                var contact = _context.Contacts.FirstOrDefault(x => x.Id == id);
                var contactsDto = new ContactsDto()
                {
                    Name = contact.Name,
                    MobilePhone = contact.MobilePhone,
                    JobTitle = contact.JobTitle,
                    BirthDate = contact.BirthDate
                };
                return contactsDto;
            }

            return new ContactsDto();
        }
    }
}
