using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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

        public async Task<int> InsertContact(ContactBody body)
        {
            var contact = _mapper.Map<Contact>(body);
            await _appDbContext.Contact.AddAsync(contact);
            await _appDbContext.SaveChangesAsync();
            return contact.Id;
        }
        public async Task<int> DeleteContactById(int id)
        {
            var contact = await _appDbContext.Contact.FindAsync(id);
            if (contact == null) return 0;
            
            _appDbContext.Contact.Remove(contact);
            await _appDbContext.SaveChangesAsync();
            return id;
        }

        public async Task<int> UpdateContact(int id, ContactDto body)
        {
            var existing = await _appDbContext.Contact.FindAsync(id);

            if (existing == null)
                return 0;

            existing.Name = body.Name;
            existing.Phone = body.Phone;

            return await _appDbContext.SaveChangesAsync();
        }

    }
}
