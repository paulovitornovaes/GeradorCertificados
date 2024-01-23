using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeradorCertificados.Models;
using Microsoft.EntityFrameworkCore;

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
    }
}
