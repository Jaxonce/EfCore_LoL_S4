using System;
using EntityFrameWorkLib;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Model;
using Shared;

namespace TestUnitaireLOL
{
	public class TestsData
	{
        public IEnumerable<object[]> Data_TestAddItem()
        {
            yield return new object[]
            {
                1,
                new ChampionEntity[]
                {
                    new ChampionEntity
                    {
                        Name = "jax",
                        Icon = "icon jax",
                        Bio = "test bio jax",
                        Class = ChampionClass.Fighter,
                        LargeImageEntity = new LargeImageEntity(){Base64 = "tevhdfvsdefefef"}
                    },
                    new ChampionEntity
                    {
                        Name = "jax2",
                        Icon = "icon jax2",
                        Bio = "test bio jax2",
                        Class = ChampionClass.Assassin,
                        LargeImageEntity = new LargeImageEntity(){Base64 = "tevhdfvsdfefefe"}
                    },
                    new ChampionEntity
                    {
                        Name = "jax3",
                        Icon = "icon jax3",
                        Bio = "test bio jax3",
                        Class = ChampionClass.Tank,
                        LargeImageEntity = new LargeImageEntity(){Base64 = "tevhdfvsdfkhefef"}
                    }
                },
                new ChampionEntity[]
                {
                    new ChampionEntity()
                    {
                        Name = "jax4",
                        Icon = "icon jax4",
                        Bio = "test bio jax4",
                        Class = ChampionClass.Marksman,
                        LargeImageEntity = new LargeImageEntity(){Base64 = "tevhdfvsdfkhvfdfdf"}
                    }
                }
            };

        }
    }
}

