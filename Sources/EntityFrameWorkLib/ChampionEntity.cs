using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameWorkLib
{
	public class ChampionEntity
	{

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UniqueId { get; set; }
		public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        public string Bio { get; set; }

        public string Icon { get; set; }

        [Required]
        public ChampionClass Class { get; set; }

        public LargeImageEntity? LargeImageEntity { get; set; }
	}
}

