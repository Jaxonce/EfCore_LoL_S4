using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared;

namespace EntityFrameWorkLib
{
	public class ChampionEntity
	{

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UniqueId { get; set; }
        public string? Name { get; set; }

        //[Required]
        [MaxLength(256)]
        public string? Bio { get; set; }

        public string? Icon { get; set; }

        //[Required]
        public ChampionClass Class { get; set; }

        public Collection<SkinEntity>? Skins { get; set; }

        public LargeImageEntity? LargeImage { get; set; }

        public HashSet<SkillEntity> skills = new HashSet<SkillEntity>();

        public Collection<RunePageEntity>? ListRunePages { get; set; }
    }
}

