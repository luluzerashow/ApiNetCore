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
    public class ServicePerfil
    {
        public async Task<string> GetAllAsync()
        {

            using (var context = new EntityDbContext())
            {
              
                var result = await (from perfis in context.Perfildbset
                            select new
                            {
                            id = perfis.id,
                            Nome = perfis.Nome,
                            Descricao = perfis.Descricao,
                            // DataCriacao = perfis.DataCriacao,
                            // DataAtualizacao = perfis.DataAtualizacao   
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

                var lista = await context.Perfildbset.Where(x => x.id == id).ToListAsync();

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

                    var Perfil = await context.Perfildbset.FindAsync(id);
                    context.Perfildbset.Remove(Perfil);
                    await context.SaveChangesAsync();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public async Task<bool> CreateAsync (PerfilView dados)
        {
            using (var context = new EntityDbContext())
            {
                try
                {
                    var perfilmodel = new Perfil();

                    perfilmodel.Nome = dados.Nome.ToString();
                    perfilmodel.Descricao = dados.Descricao.ToString();
                    perfilmodel.DataCriacao = DateTime.Now;
                    perfilmodel.DataAtualizacao = DateTime.Now;

                    await context.Perfildbset.AddAsync(perfilmodel);
                    await context.SaveChangesAsync();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public async Task<bool> EditAsync (PerfilView dados)
        {
            using (var context = new EntityDbContext())
            {
                try
                {
                    var Perfil = await context.Perfildbset.FindAsync(dados.id);

                    Perfil.Nome = dados.Nome.ToString();
                    Perfil.Descricao = dados.Descricao.ToString();
                    Perfil.DataAtualizacao = DateTime.Now;
                    
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