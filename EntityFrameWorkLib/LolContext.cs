using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkLib
{
	public class LolContext : DbContext
	{
		public DbSet<ChampionEntity> Champions { get; set; }

		public LolContext() { }
		public LolContext(DbContextOptions<LolContext> options)
			:base(options)
		{ }
		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			if (!options.IsConfigured)
			{
                base.OnConfiguring(options.UseSqlite($"DataSource=projet.Champions.db"));
            }

        }
			 
	}
}

