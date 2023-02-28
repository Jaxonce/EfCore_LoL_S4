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
        public string Bio { get; set; }
        public string Icon { get; set; }
        public ChampionClassEntity championClass { get; set; }
	}
}

