using EntityFrameWorkLib;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;
using Microsoft.Data.Sqlite;

namespace TestUnitaireLOL;

public class UnitTest1
{
    [Fact]
    public void Add_Test()
    {
        var connexion = new SqliteConnection("DataSource=:memory:");
        connexion.Open();

        var options = new DbContextOptionsBuilder<LolContext>()
            .UseSqlite(connexion)
            .Options;

        using(var context = new LolContext(options))
        {
            context.Database.EnsureCreated();

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

            context.Add(champions);
            context.Add(darius);
            context.Add(jax);
            context.SaveChanges();
        }

        //uses another instance of the context to do the tests
        using (var context = new LolContext(options))
        {
            context.Database.EnsureCreated();

            Assert.Equal(3, context.Champions.Count());
            Assert.Equal("toto", context.Champions.First().Name);
        }
    }

    [Fact]
    public void Modify_Test()
    {
        //connection must be opened to use In-memory database
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<LolContext>()
            .UseSqlite(connection)
            .Options;

        //prepares the database with one instance of the context
        using (var context = new LolContext(options))
        {
            //context.Database.OpenConnection();
            context.Database.EnsureCreated();

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

            context.Add(champions);
            context.Add(darius);
            context.Add(jax);
            context.SaveChanges();
        }

        //uses another instance of the context to do the tests
        using (var context = new LolContext(options))
        {
            context.Database.EnsureCreated();

            string nameToFind = "icon";
            Assert.Equal(3, context.Champions.Where(n => n.Icon.ToLower().Contains(nameToFind)).Count());
            nameToFind = "io";
            Assert.Equal(3, context.Champions.Where(n => n.Bio.ToLower().Contains(nameToFind)).Count());
            var champions = context.Champions.Where(n => n.Bio.ToLower().Contains(nameToFind)).First();
            champions.Bio = "Wicket";
            context.SaveChanges();
        }

        //uses another instance of the context to do the tests
        using (var context = new LolContext(options))
        {
            context.Database.EnsureCreated();

            string nameToFind = "io";
            Assert.Equal(2, context.Champions.Where(n => n.Bio.ToLower().Contains(nameToFind)).Count());
            nameToFind = "wick";
            Assert.Equal(1, context.Champions.Where(n => n.Bio.ToLower().Contains(nameToFind)).Count());
        }
    }
}

