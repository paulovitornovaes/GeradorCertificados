using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeradorCertificados.Data.Configuration;
using GeradorCertificados.Models;
using Microsoft.EntityFrameworkCore;
using GeradorCertificados.Models;
namespace GeradorCertificados.Data
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext (DbContextOptions<BaseDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Evento> Evento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoConfiguration());
            modelBuilder.ApplyConfiguration(new EventoConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
