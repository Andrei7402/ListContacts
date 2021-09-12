using ListContacts.Data.Entities;
using ListContacts.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListContacts.Services
{
    public interface IListContactsServices
    {
        IQueryable<Contacts> Get();

        Task<Contacts> AddContacts(ContactsDto contacts);

        Task<Contacts> CreateContacts(ContactsDto contacts);

        void DeleteContacts(Guid id);

        Task<Contacts> UpdateContacts(Contacts contacts);

        ContactsDto GetId(Guid id);
    }
}
