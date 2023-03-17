using System;
using Shared;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameWorkLib
{
	public class SkillEntity
	{
        [Key]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public SkillType SkillType { get; set; }
    }
}

