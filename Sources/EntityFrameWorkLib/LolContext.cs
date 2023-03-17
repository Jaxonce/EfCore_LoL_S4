using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkLib
{
	public class LolContext : DbContext
	{
        public DbSet<ChampionEntity> Champions { get; set; }
        public DbSet<SkillEntity> Skill { get; set; }
        public DbSet<LargeImageEntity> LargeImage { get; set; }

        public LolContext() { }
        public LolContext(DbContextOptions<LolContext> options)
            : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                base.OnConfiguring(options.UseSqlite($"DataSource=projet.Champions.db"));
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Définition de la clé primaire de ChampionEntity
            modelBuilder.Entity<ChampionEntity>().HasKey(n => n.UniqueId);
            //Définition du mode de generation de la clé : génération à l'insertion
            modelBuilder.Entity<ChampionEntity>().Property(n => n.UniqueId).ValueGeneratedOnAdd();

            modelBuilder.Entity<ChampionEntity>()
                .HasOne(c => c.LargeImageEntity)
                .WithOne(li => li.champion)
                .HasForeignKey<LargeImageEntity>(li => li.championId);

            base.OnModelCreating(modelBuilder);

        }

    }
}

