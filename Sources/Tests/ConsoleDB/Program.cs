// See https://aka.ms/new-console-template for more information

using EntityFrameWorkLib;
using Microsoft.EntityFrameworkCore;

ChampionEntity jax = new ChampionEntity
{
    Name = "jax",
    Icon = "icon jax",
    Bio = "test bio jax"
};
ChampionEntity darius = new ChampionEntity
{
    Name = "darius",
    Icon = "icon darius",
    Bio = "test bio darius"
};
ChampionEntity champions = new ChampionEntity
{
    Name = "toto",
    Icon = "icon",
    Bio = "test bio champion"
};
using (var context= new SQLiteLolContext())
{
    Console.WriteLine("Create and Insert new Champion");
    context.Add(champions);
    context.Add(darius);
    context.Add(jax);
    await context.SaveChangesAsync();
}

public class SQLiteLolContext : LolContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
        {
            options.UseSqlite($"Data Source=projet.Champions.db");
        }   
    }
}

