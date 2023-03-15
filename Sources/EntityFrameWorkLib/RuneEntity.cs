using System;
using System.ComponentModel.DataAnnotations;

using Shared;

namespace EntityFrameWorkLib
{
    public class RuneEntity
    {
        [Key]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public RuneFamily RuneFamily { get; set; }
    }
}

