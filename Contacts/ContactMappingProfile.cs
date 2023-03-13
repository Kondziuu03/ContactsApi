using AutoMapper;
using Contacts.Entities;
using Contacts.Models;

namespace Contacts
{
    public class ContactMappingProfile : Profile
    {
        public ContactMappingProfile()
        {
            CreateMap<Contact, ContactDto>()
                .ForMember(x => x.CategoryName, y => y.MapFrom(z => z.Category.Name))
                .ForMember(x => x.CompanyName, y => y.MapFrom(z => z.Company.Name));

            CreateMap<Company, CompanyDto>()
                .ForMember(x => x.City, y => y.MapFrom(z => z.Address.City))
                .ForMember(x => x.Street, y => y.MapFrom(z => z.Address.Street))
                .ForMember(x => x.PostalCode, y => y.MapFrom(z => z.Address.PostalCode));

            CreateMap<CreateCompanyDto, Company>()
                .ForMember(x => x.Address,
                    y => y.MapFrom(dto => new Address()
                    {
                        City = dto.City,
                        Street = dto.Street,
                        PostalCode = dto.PostalCode
                    }));

            CreateMap<CreateContactDto, Contact>();

        }
    }
}
