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
        public DbSet<RuneEntity> Runes { get; set; }
        public DbSet<RunePageEntity> RunesPage { get; set; }
        public DbSet<SkinEntity> Skins { get; set; }

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
            base.OnModelCreating(modelBuilder);
            //Définition de la clé primaire de ChampionEntity
            modelBuilder.Entity<ChampionEntity>().HasKey(n => n.UniqueId);
            //Définition du mode de generation de la clé : génération à l'insertion
            modelBuilder.Entity<ChampionEntity>().Property(n => n.UniqueId).ValueGeneratedOnAdd();

            modelBuilder.Entity<ChampionEntity>()
                .HasOne(c => c.LargeImage)
                .WithOne(li => li.champion)
                .HasForeignKey<LargeImageEntity>(li => li.championId);

            modelBuilder.Entity<SkinEntity>()
                .Property(s => s.Name)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<RunePageEntity>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<RuneEntity>()
                .Property(s => s.Name)
                .ValueGeneratedOnAdd();
        }

    }
}

