using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GeradorCertificados2.Models;

namespace GeradorCertificados2.Data
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext (DbContextOptions<BaseDbContext> options)
            : base(options)
        {
        }

        public DbSet<Aluno> Aluno { get; set; }
    }
}
