using API.Domain;
using API.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infrastructure
{
    public class ApiContext : DbContext
    {
        public DbSet<User> Usuarios { get; set; }
        public DbSet<Arquivo> Arquivos { get; set; }

        private readonly string ConectionString = "Server=34.72.148.185;Port=5432;Database=pep;User Id=postgres;Password=password;";

        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
        public ApiContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql(ConectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ArquivoConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
