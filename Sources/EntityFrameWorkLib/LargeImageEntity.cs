using System;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameWorkLib
{
	public class LargeImageEntity
	{
        [Key]
        public Guid Id { get; set; }

        //[Required]
        public string? Base64 { get; set; }

        //[Required]
        public int championId { get; set; }

        //[Required]
        public ChampionEntity? champion { get; set; }
    }
}

