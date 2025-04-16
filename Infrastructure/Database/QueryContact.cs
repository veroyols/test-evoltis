using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class QueryContact : IQueryContact
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public QueryContact(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<List<ContactDto>> GetAllContacts()
        {
            var contacts = await _appDbContext.Contact.ToListAsync();
            return _mapper.Map<List<ContactDto>>(contacts);
        }

        public async Task<ContactDto> GetContactById(int id)
        {
            var contact = await _appDbContext.Contact.FindAsync(id);

            if (contact == null)
                return null;

            return _mapper.Map<ContactDto>(contact);
        }
    }
}
