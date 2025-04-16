using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Database
{
    public class CommandContact : ICommandContact
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public CommandContact(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        public async Task<int> InsertContact(ContactDto body)
        {
            var contact = _mapper.Map<Contact>(body);
            await _appDbContext.Contact.AddAsync(contact);
            await _appDbContext.SaveChangesAsync();
            return contact.Id;
        }

    }
}
