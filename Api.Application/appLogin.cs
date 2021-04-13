using Api.Repository.Services;
using System.Threading.Tasks;

namespace Api.Application
{
    public class appLogin
    {
        public async Task<bool> GetUserLogin(string user)
        {
            var serviceLogin = new ServiceLogin();

            bool result = await serviceLogin.GetUserLogin(user);

            return result;
        }

        public async Task<string> GetUserCookie(string user)
        {
            var service = new ServiceLogin();

            var jsonstring = await service.GetUserCookie(user);

            if (jsonstring == "[]")
            {
                return "Null";
            }
            else
            {
                return jsonstring;
            }
        }

        public async Task<string> GetPerfisCombo()
        {
            var service = new ServiceLogin();

            var jsonstring = await service.GetPerfisCombo();

            if (jsonstring == "[]")
            {
                return "Null";
            }
            else
            {
                return jsonstring;
            }
        }
    }
}