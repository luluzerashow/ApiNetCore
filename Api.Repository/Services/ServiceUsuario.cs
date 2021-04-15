using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Api.Domain.ViewModels;
using Api.Domain.Models;
using System;

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
                        //  }).Take(50).ToListAsync();
                        }).ToListAsync();

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

        public async Task<bool> CreateAsync (UsuarioView dados)
        {
            using (var context = new EntityDbContext())
            {
                try
                {
                    var usuariomodel = new Usuario();

                    usuariomodel.User = dados.User.ToString();
                    usuariomodel.Senha = dados.Senha.ToString();
                    usuariomodel.Nome = dados.Nome.ToString();
                    usuariomodel.PerfilId = dados.PerfilId;
                    usuariomodel.DataCriacao = DateTime.Now;
                    usuariomodel.DataAtualizacao = DateTime.Now;

                    await context.Usuariodbset.AddAsync(usuariomodel);
                    await context.SaveChangesAsync();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public async Task<bool> EditAsync (UsuarioView dados)
        {
            using (var context = new EntityDbContext())
            {
                try
                {
                    var Usuario = await context.Usuariodbset.FindAsync(dados.id);

                    Usuario.User = dados.User.ToString();
                    //usuariomodel.Senha = dados.Senha.ToString();
                    Usuario.Nome = dados.Nome.ToString();
                    Usuario.PerfilId = dados.PerfilId;
                    //usuariomodel.DataCriacao = DateTime.Now;
                    Usuario.DataAtualizacao = DateTime.Now;
                    
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