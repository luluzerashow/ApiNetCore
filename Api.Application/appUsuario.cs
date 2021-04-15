using Api.Domain.ViewModels;
using Api.Repository.Services;
using System.Threading.Tasks;

namespace Api.Application
{
    public class appUsuario
    {
        public async Task<string> GetAllAsync()
        {
            var service = new ServiceUsuario();
            var jsonstring = await service.GetAllAsync();

            if (jsonstring == "[]")
            {
                return "Null";
            }
            else
            {
                return jsonstring;
            }
        }


        public async Task<string> GetByIdAsync(int id)
        {
            //Fazer validações se o user esta no padrão certo;
            var service = new ServiceUsuario();

            var jsonstring = await service.GetByIdAsync(id);

            if (jsonstring == "[]")
            {
                return "Null";
            }
            else
            {
                return jsonstring;
            }
        }

        public async Task<bool> DeleteAsyncById(int id)
        {
            //Fazer validações se o user esta no padrão certo;
            var service = new ServiceUsuario();

            bool result = await service.DeleteAsyncById(id);

            return result;
        }


        public async Task<bool> CreateAsync(UsuarioView dados)
        {
            //Fazer validações se o user esta no padrão certo;
            var service = new ServiceUsuario();

            bool result = await service.CreateAsync(dados);

            return result;
        }

        public async Task<bool> EditAsync(UsuarioView dados)
        {
            //Fazer validações se o user esta no padrão certo;
            var service = new ServiceUsuario();

            bool result = await service.EditAsync(dados);

            return result;
        }

        
    }
}
