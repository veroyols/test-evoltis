

using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICommandContact
    {
        public Task<int> InsertContact(ContactBody body);
        public Task<int> DeleteContactById(int id);
        public Task<int> UpdateContact(int id, ContactDto body);

    }
}
