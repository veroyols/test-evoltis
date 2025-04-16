using Application.DTO;
using Application.Interfaces;

namespace Application.UseCase
{
    public class ServiceContact : IServiceContact
    {
        private readonly ICommandContact _command;
        private readonly IQueryContact _query;
        public ServiceContact(ICommandContact command, IQueryContact query)
        {
            _command = command;
            _query = query;
        }
        public async Task<int> InsertContact(ContactBody body)
        {
            int result = await _command.InsertContact(body);
            return result;
        }

        public async Task<List<ContactDto>> GetAllContacts()
        {
            var result = await _query.GetAllContacts();
            return result;
        }
        public async Task<ContactDto> GetContactById(int id)
        {
            var dto = await _query.GetContactById(id);

            if (dto == null)
                return null;

            return dto;
        }

        public async Task<int> DeleteContactById(int id)
        {
            var dto = await _command.DeleteContactById(id);
            return dto;
        }
    }
}