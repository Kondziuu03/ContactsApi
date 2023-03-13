using Contacts.Models;
using System.Collections.Generic;

namespace Contacts.Interfaces
{
    public interface IContactService
    {
        IEnumerable<ContactDto> GetAll(int companyId);
        ContactDto GetById(int companyId, int id);
        int Create(int companyId,CreateContactDto dto);
        void Delete(int companyId, int id);
    }
}
