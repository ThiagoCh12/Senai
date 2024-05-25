using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Senai.Models;

namespace Senai.Data
{
    public class SenaiContext : DbContext
    {
        public SenaiContext (DbContextOptions<SenaiContext> options)
            : base(options)
        {
        }

        public DbSet<Senai.Models.Turmas> Turmas { get; set; } = default!;

        public DbSet<Senai.Models.Professor> Professor { get; set; }

        public DbSet<Senai.Models.Atividades>? Atividades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atividades>()
                .HasOne(a => a.Turma)
                .WithMany(t => t.Atividades)
                .HasForeignKey(a => a.id_turma);
        }
    }


}
