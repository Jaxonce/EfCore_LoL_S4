using System;
using Microsoft.Extensions.Logging.Abstractions;
using StubLib;
using WebApiLol;
using WebApiLol.Controllers;

namespace TestUnitaireLOL
{
	public class TestAPI
	{
        [Theory]
        [InlineData("Beatrice", "sdfsdfd", "icon.png")]
        [InlineData("Maurice", "Ahri est un champion de League of Legends", "icon.png")]
        [InlineData("Loupiotte", "Akali est un champion de League of Legends", "icon.png")]
        public async Task TestPostChampion(string name, string bio, string icon)
        {
            // Arrange
            var data = new StubData();
            var logger = new NullLogger<ChampionController>();
            var controller = new ChampionController(data, logger);
            var champDTO = new ChampionDTO()
            {
                Name = name,
                Bio = bio,
                Icon = icon
            };

            // Act
            var nbInListBefore = data.ChampionsMgr.GetNbItems().Result;
            var result = await controller.AddChampion(champDTO);
            var nbInListAfter = data.ChampionsMgr.GetNbItems().Result;

            // Assert
            // IS the champion added to the list, number of champions in the list + 1
            Assert.Equal(nbInListBefore + 1, nbInListAfter);
            // Test le code de retour
        }
    }
}

