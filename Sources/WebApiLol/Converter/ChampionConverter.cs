using System;
using Model;
namespace WebApiLol.Converter
{
    public static class ChampionConverter
    {
        public static ChampionDTO toDTO(this Champion champion) => new ChampionDTO()
        {
            Name = champion.Name,
            Bio = champion.Bio,
        };

        public static Champion toModel(this ChampionDTO champion) => new Champion(champion.Name, champion.Bio);
    }
}

