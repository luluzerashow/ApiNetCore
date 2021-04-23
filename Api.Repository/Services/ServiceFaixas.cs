using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Api.Domain.Models;
using Api.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository.Services
{
    public class ServiceFaixas
    {
        public async Task<string> GetAllAsync()
        {
            using (var context = new EntityDbContext())
            {
                var result = await (from faixas in context.Faixasbset
                                    select new
                                    {
                                        id = faixas.id,
                                        Nome = faixas.Cor,
                                        Aulas_Meta = faixas.Aulas_Meta,
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
                var lista = await context.Faixasbset.Where(x => x.id == id).ToListAsync();
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
                    var Faixa = await context.Faixasbset.FindAsync(id);
                    context.Faixasbset.Remove(Faixa);
                    await context.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public async Task<bool> CreateAsync(Faixas dados)
        {
            using (var context = new EntityDbContext())
            {
                try
                {
                    var Faixamodel = new Faixas();

                    Faixamodel.Cor = dados.Cor.ToString();
                    Faixamodel.Aulas_Meta = dados.Aulas_Meta;
                    Faixamodel.DataCriacao = DateTime.Now;
                    Faixamodel.DataAtualizacao = DateTime.Now;

                    await context.Faixasbset.AddAsync(Faixamodel);
                    await context.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public async Task<bool> EditAsync (Faixas dados)
        {
            using (var context = new EntityDbContext())
            {
                try
                {
                    var Faixa = await context.Faixasbset.FindAsync(dados.id);

                    Faixa.Cor = dados.Cor.ToString();
                    Faixa.Aulas_Meta = dados.Aulas_Meta;
                    Faixa.DataAtualizacao = DateTime.Now;
                    
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