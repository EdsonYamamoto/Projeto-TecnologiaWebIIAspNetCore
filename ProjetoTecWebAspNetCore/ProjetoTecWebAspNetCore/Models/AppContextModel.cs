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

        public DbSet<BalancoModel> Balancos { get; set; }
        public DbSet<ContaModel> Contas { get; set; }
        public DbSet<ConversaModel> Conversas { get; set; }
        public DbSet<EmprestimoModel> Emprestimos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContaModel>().ToTable("Conta");
            modelBuilder.Entity<BalancoModel>().ToTable("Balanco");
            modelBuilder.Entity<UsuarioModel>().ToTable("Usuario");
            modelBuilder.Entity<EmprestimoModel>().ToTable("Emprestimos");
            modelBuilder.Entity<ConversaModel>().ToTable("Conversas");
        }
    }
}
