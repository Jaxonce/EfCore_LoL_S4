using System;
namespace WebApiLol
{
	public class ChampionPageDTO
	{
        public IEnumerable<ChampionDTO> Data { get; set; }

        public int Index { get; set; }

        public int Count { get; set; }

        public int TotalCount { get; set; }
    }
}

