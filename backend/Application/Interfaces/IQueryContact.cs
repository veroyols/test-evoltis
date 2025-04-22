using Application.DTO;

namespace Application.Interfaces
{
    public interface IQueryContact
    {
        public Task<List<ContactDto>> GetAllContacts();
        public Task<ContactDto> GetContactById(int id);

    }
}
