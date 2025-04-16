using Application.DTO;

namespace Application.Interfaces
{
    public interface IServiceContact
    {
        public Task<int> InsertContact(ContactBody body); 
        public Task<List<ContactDto>> GetAllContacts();
        public Task<ContactDto> GetContactById(int id);
        public Task<int> DeleteContactById(int id);

    }
}
