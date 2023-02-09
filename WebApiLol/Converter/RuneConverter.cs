using System;
using Model;

namespace WebApiLol.Converter
{
	public static class RuneConverter
	{
        public static RuneDTO toDTO(this Rune rune) => new RuneDTO()
        {
            Name = rune.Name,
            Description = rune.Description,
        };

        public static Rune toModel(this RuneDTO rune) => new Rune(rune.Name, rune.Description);
    }
}

