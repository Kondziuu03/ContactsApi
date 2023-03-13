using Contacts.Models;
using System.Collections.Generic;

namespace Contacts.Interfaces
{
    public interface ICompanyService
    {
        IEnumerable<CompanyDto> GetAll();
        CompanyDto GetById(int id);
        int Create(CreateCompanyDto dto);
        void Delete(int id);
    }
}
