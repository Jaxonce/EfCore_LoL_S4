using System;
using System.Collections.ObjectModel;
using EntityFrameWorkLib;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Model;
using Shared;

namespace TestUnitaireLOL
{
	public class TestEf
	{
        //[Theory]

        //[InlineData(0, "Zeus", "Dieu de la foudre", true)]
        //[InlineData(10, "Hades", "Dieu des enfers", true)]
        //[InlineData(1, "Aphrodite", "Déesse de l'amour", true)]
        ////[InlineData(10, "AresAresAresAresAresAresAresAresAresAres",
        ////    "Dieu de la guerreDieu de la guerreDieu de la guerreDieu de la guerreDieu de la guerreDieu de la guerreDieu de la guerreDieu de la guerreDieu de la guerreDieu de la guerre" +
        ////    "Dieu de la guerreDieu de la guerreDieu de la guerreDieu de la guerreDieu de la guerreDieu de la guerreDieu de la guerreDieu de la guerreDieu de la guerreDieu de la guerre" +
        ////    "Dieu de la guerreDieu de la guerreDieu de la guerreDieu de la guerreDieu de la guerreDieu de la guerreDieu de la guerreDieu de la guerreDieu de la guerreDieu de la guerre", false)]
        //public async Task TestAddChampionInMemory(int id, String name, String bio, bool expected)
        //{
        //    var connection = new SqliteConnection("DataSource=:memory:");
        //    connection.Open();

        //    var options = new DbContextOptionsBuilder<LolContext>()
        //        .UseSqlite(connection)
        //        .Options;

        //    using (var context = new LolContext(options))
        //    {
        //        await context.Database.EnsureCreatedAsync();
        //        SkinEntity black = new SkinEntity { Name = "Black", Description = "Black skin", Icon = "black.png", Price = 0.99f };
        //        SkinEntity white = new SkinEntity { Name = "White", Description = "White skin", Icon = "white.png", Price = 150.99f };
        //        SkinEntity green = new SkinEntity { Name = "Green", Description = "Green skin", Icon = "green.png", Price = 4.99f };

        //        RunePageEntity runePage1 = new RunePageEntity { Id = 1, Name = "runepage1" };

        //        var Dieu = new ChampionEntity
        //        {
        //            UniqueId = id,
        //            Name = name,
        //            Bio = bio,
        //            Skins = new Collection<SkinEntity>(new List<SkinEntity> { black, white, green }),
        //            ListRunePages = new Collection<RunePageEntity>(new List<RunePageEntity> { { runePage1 } })
        //        };

        //        ChampionEntity found = await context.Champions.SingleOrDefaultAsync(c => c.Name == "Zeus");
        //        Assert.Null(found);

        //        await context.Champions.AddAsync(Dieu);
        //        await context.SaveChangesAsync();

        //        found = await context.Champions.SingleOrDefaultAsync(c => c.Name == name);
        //        Assert.NotNull(found);

        //        Assert.Equal(1, await context.Champions.CountAsync());
        //        Assert.Equal(name, found.Name);
        //        Assert.Equal(3, found.Skins.Count);
        //        Assert.Equal(1, found.ListRunePages.Count);

        //        // Test if the max length of the name is respected (30) and the max length of the bio is respected (256)
        //        if (expected)
        //        {
        //            Assert.True(found.Name.Length <= 30);
        //            Assert.True(found.Bio.Length <= 256);
        //        }
        //        else
        //        {
        //            Assert.False(found.Name.Length <= 30);
        //            Assert.False(found.Bio.Length <= 256);
        //        }
        //    }
        //}

        [Fact]
        public void TestModifyChampionInMemory()
        {
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

                ChampionEntity chewie = new ChampionEntity { Name = "Chewbacca",Icon="Icon1", Bio = "Zeus is the king of the gods." };
                ChampionEntity yoda = new ChampionEntity { Name = "Yoda",Icon="Icon2", Bio = "Zeus is the king of the gods." };
                ChampionEntity ewok = new ChampionEntity { Name = "Ewok",Icon="Icon3", Bio = "Zeus is the king of the gods." };


                context.Champions.Add(chewie);
                context.Champions.Add(yoda);
                context.Champions.Add(ewok);
                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new LolContext(options))
            {
                context.Database.EnsureCreated();

                string nameToFind = "ew";
                Assert.Equal(2, context.Champions.Where(n => n.Name.ToLower().Contains(nameToFind)).Count());
                nameToFind = "wo";
                Assert.Equal(1, context.Champions.Where(n => n.Name.ToLower().Contains(nameToFind)).Count());
                var ewok = context.Champions.Where(n => n.Name.ToLower().Contains(nameToFind)).First();
                ewok.Name = "Wicket";
                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new LolContext(options))
            {
                context.Database.EnsureCreated();

                string nameToFind = "ew";
                Assert.Equal(1, context.Champions.Where(n => n.Name.ToLower().Contains(nameToFind)).Count());
                nameToFind = "wick";
                Assert.Equal(1, context.Champions.Where(n => n.Name.ToLower().Contains(nameToFind)).Count());
            }
        }

        //[Theory]

        //[InlineData(0, "black", "super Skin", "icon1.png", 190000000.2f, true)]
        //[InlineData(1, "White", "skin1", "icon1", 19, true)]
        //[InlineData(2, "Green", "skin", "icon1.jpg", -1, false)]
        //public async Task TestAddSkinToChampionInMemory(int id, String name, String description, String icon, float price, bool expected)
        //{
        //    var connection = new SqliteConnection("DataSource=:memory:");
        //    connection.Open();

        //    var options = new DbContextOptionsBuilder<LolContext>()
        //        .UseSqlite(connection)
        //        .Options;

        //    using (var context = new LolContext(options))
        //    {
        //        await context.Database.EnsureCreatedAsync();

        //        var Dieu = new ChampionEntity
        //        {
        //            UniqueId = 0,
        //            Name = "Zeus",
        //            Bio = "Dieu de la foudre",
        //            Skins = new Collection<SkinEntity>()
        //        };

        //        SkinEntity item = new SkinEntity
        //        {
        //            Name = name,
        //            Description = description,
        //            Icon = icon,
        //            Price = price
        //        };

        //        Dieu.Skins.Add(item);

        //        ChampionEntity found = await context.Champions.SingleOrDefaultAsync(c => c.Name == "Zeus");
        //        Assert.Null(found);

        //        await context.Champions.AddAsync(Dieu);
        //        await context.SaveChangesAsync();

        //        found = await context.Champions.SingleOrDefaultAsync(c => c.Name == name);
        //    }

        //}
    }
}

