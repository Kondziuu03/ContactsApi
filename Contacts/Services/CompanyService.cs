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
    public class CompanyService : ICompanyService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CompanyService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Create(CreateCompanyDto dto)
        {
            var company = _mapper.Map<Company>(dto);
            _context.Companies.Add(company);
            _context.SaveChanges();

            return company.Id;
        }

        public void Delete(int id)
        {
            var company = _context.Companies.FirstOrDefault(x => x.Id == id);
            if (company == null)
                throw new NotFoundException("Company not found");
            _context.Companies.Remove(company);
            _context.SaveChanges();
        }

        public IEnumerable<CompanyDto> GetAll()
        {
            var companies = _context.Companies
                .Include(x => x.Contacts)
                .ThenInclude(x => x.Category)
                .Include(x => x.Address)
                .ToList();

            if (!companies.Any())
                throw new NotFoundException("Companies not found");

            var result = _mapper.Map<List<CompanyDto>>(companies);

            return result;
        }

        public CompanyDto GetById(int id)
        {
            var company = _context.Companies
                .Include(x => x.Contacts)
                .ThenInclude(x => x.Category)
                .Include(x => x.Address)
                .FirstOrDefault(x => x.Id == id);

            if(company == null)
                throw new NotFoundException("Company not found");

            var result = _mapper.Map<CompanyDto>(company);

            return result;
        }
    }
}
