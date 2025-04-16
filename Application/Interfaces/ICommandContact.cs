

using Application.DTO;

namespace Application.Interfaces
{
    public interface ICommandContact
    {
        public Task<int> InsertContact(ContactDto body);
    }
}
