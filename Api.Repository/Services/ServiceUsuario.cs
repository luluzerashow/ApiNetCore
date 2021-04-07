using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Api.Repository.Services
{
    public class ServiceUsuario
    {

        public async Task<string> GetAllAsync()
        {

            using (var context = new EntityDbContext())
            {
              
                var result = await (from usuarios in context.Usuariodbset
                            join perfis in context.Perfildbset on usuarios.PerfilId equals perfis.id
                            select new
                            {
                            id = usuarios.id,
                            User = usuarios.User,
                            Nome = usuarios.Nome,
                            PerfilId = usuarios.PerfilId,
                            PerfilNome = perfis.Nome,
                            // DataCriacao = usuarios.DataCriacao,
                            // DataAtualizacao = usuarios.DataAtualizacao   
                        }).Take(50).ToListAsync();

                var json = JsonSerializer.Serialize(result);

                return json;

            }
        }

        public async Task<string> GetByIdAsync(int id)
        {

            using (var context = new EntityDbContext())
            {

                var lista = await context.Usuariodbset.Include(m => m.Perfil).Where(x => x.id == id).ToListAsync();

                var json = JsonSerializer.Serialize(lista);

                return json;
            }
        }

        public async Task<bool> DeleteAsyncById(int id)
        {

            using (var context = new EntityDbContext())
            {
                try
                {

                    var Usuario = await context.Usuariodbset.FindAsync(id);
                    context.Usuariodbset.Remove(Usuario);
                    await context.SaveChangesAsync();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}