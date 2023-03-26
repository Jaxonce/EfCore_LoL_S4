using System;
using EntityFrameWorkLib;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestUnitaireLOL
{
	public class UnitTestDbDataManager
	{
		
        public void Test_Data_AddItem(int expectedResult,
                                        IEnumerable<ChampionEntity> expectedChampions,
                                        IEnumerable<ChampionEntity> expectedChampionsAdded,
                                        params ChampionEntity[] championsToAdd)
        {
            var connexion = new SqliteConnection("DataSource=:memory:");
            connexion.Open();

            var options = new DbContextOptionsBuilder<LolContext>()
                .UseSqlite(connexion)
                .Options;

            using (var context = new LolContext())
            {

            }
        }
    }
}

