

using Application.DTO;

namespace Application.Interfaces
{
    public interface ICommandContact
    {
        public Task<int> InsertContact(ContactBody body);
        public Task<int> DeleteContactById(int id);

    }
}
