using Application.Interface;

namespace Application.UseCase.GetAll
{
    public class ServiceContact : IServiceContact
    {
        public object GetAll()
        {
            return new { name = "Contacto 2" };
        }
    }
}
