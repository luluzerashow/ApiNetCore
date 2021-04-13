using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Api.Repository.Services
{
    public class ServiceLogin
    {

        public async Task<bool> GetUserLogin(string user)
        {
            using (var context = new EntityDbContext())
            {
                try
                {
                    var result = await context.Usuariodbset.Where(x => x.User == user).FirstOrDefaultAsync();
                    //verifica se trouxe o usuario
                    if(result is null){
                        return false;
                    }else{
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        public async Task<string> GetUserCookie(string user)
        {

            using (var context = new EntityDbContext())
            {

                //Coletar dados para criar o cookie
               var result = await (from usuarios in context.Usuariodbset.Where(x => x.User == user)
                            join perfis in context.Perfildbset on usuarios.PerfilId equals perfis.id
                            select new
                            {
                            id = usuarios.id,
                            User = usuarios.User,
                            Nome = usuarios.Nome,
                            PerfilId = usuarios.PerfilId,
                            PerfilNome = perfis.Nome,
                        }).ToListAsync();

                var json = JsonSerializer.Serialize(result);

                return json;
            }
        }

        public async Task<string> GetPerfisCombo()
        {

            using (var context = new EntityDbContext())
            {

                //Coletar dados para criar o cookie
               var result = await (from perfis in context.Perfildbset
                            select new
                            {
                            Value = perfis.id,
                            ViewValue = perfis.Nome
                        }).ToListAsync();

                var json = JsonSerializer.Serialize(result);

                return json;
            }
        }
    }
}