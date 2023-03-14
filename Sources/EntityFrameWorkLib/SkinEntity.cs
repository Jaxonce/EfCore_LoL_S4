using System;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameWorkLib
{
	public class SkinEntity
	{
        [Key]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

		public string Icon { get; set; }

        [Required]
		public float Price { get; set; }
	}
}

