using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTecWebAspNetCore.Models
{
    public class AppContextModel : DbContext
    {
        public AppContextModel(DbContextOptions<AppContextModel> options) : base(options) { }

        public DbSet<ContaModel> Contas { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<GastosModel> Gastos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContaModel>().ToTable("Conta");
            modelBuilder.Entity<GastosModel>().ToTable("Gasto");
            modelBuilder.Entity<UsuarioModel>().ToTable("Usuario");
        }
    }
}
