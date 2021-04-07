using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class EntityDbContext : DbContext
    {
        private const string conectionString = @"Password=987509cx;Persist Security Info=True;User ID=LuluDB;Initial Catalog=DB01;Data Source=LULUZERASHOW-PC\DBLULU";

        public EntityDbContext()
        {

        }

        public EntityDbContext(DbContextOptions<EntityDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured){
                optionsBuilder.UseSqlServer(conectionString);
            }
            
        }



        #region DbSets
        public DbSet<Perfil> Perfildbset { get; set; }
        public DbSet<Usuario> Usuariodbset { get; set; }
        #endregion



    }
}