using AutoMapper;
using Contacts.Entities;
using Contacts.Exceptions;
using Contacts.Interfaces;
using Contacts.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Contacts.Services
{
    public class ContactService : IContactService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ContactService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Create(int companyId,CreateContactDto dto)
        {
            var company = GetCompanyById(companyId);
            var contact = _mapper.Map<Contact>(dto);
            contact.CompanyId = companyId;

            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return contact.Id;
        }

        public void Delete(int companyId, int id)
        {
            var company = GetCompanyById(companyId);
            var contact = _context.Contacts.FirstOrDefault(x => x.Id == id);
            if (contact == null)
                throw new NotFoundException("Contact not found");
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
        }

        public IEnumerable<ContactDto> GetAll(int companyId)
        {
            var company = GetCompanyById(companyId);
            var contactsDtos = _mapper.Map<List<ContactDto>>(company.Contacts);

            return contactsDtos;
        }

        public ContactDto GetById(int companyId, int id)
        {
            var company = GetCompanyById(companyId);
            var contact = _context.Contacts
                .Include(x => x.Category)
                .Include(x => x.Company)
                .FirstOrDefault(x => x.Id == id);

            if (contact == null || contact.CompanyId != companyId)
                throw new NotFoundException("Contact not found");

            var result = _mapper.Map<ContactDto>(contact);
            return result;
        }

        private Company GetCompanyById(int companyId)
        {
            var company = _context.Companies
                .Include(x => x.Contacts)
                .ThenInclude(x => x.Category)
                .FirstOrDefault(x => x.Id == companyId);
            if (company == null)
                throw new NotFoundException("Company not found");

            return company;
        }
    }
}
