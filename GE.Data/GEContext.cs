using GE.Data.MyConfiguration;
using GE.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GE.Data
{
    public class GEContext :DbContext
    {
        public DbSet<Membre> Membres { get; set; }
        public DbSet<Contrat> Contrats { get; set; }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Trophee> Trohpees { get; set; }
        public DbSet<Joueur> Joueurs { get; set; }
        public DbSet<Entraineur> Entraineurs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog=FederationBD;
                                        Integrated Security=true;
                                        MultipleActiveResultSets=true");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contrat>()
               .HasKey(c => new { c.DateContrat, c.MembreFk, c.EquipeFk });
            
            modelBuilder.Entity<Membre>()
                .HasDiscriminator<String>("Type")
                .HasValue<Joueur>("J").HasValue<Entraineur>("E");
            
            new TropheeConfiguration().Configure(modelBuilder.Entity<Trophee>());
            
            foreach (var prop in
                modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties())
                .Where(p => p.ClrType == typeof(String)))
            {
                prop.IsNullable = false;
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
