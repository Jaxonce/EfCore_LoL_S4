using System;
using Model;

namespace WebApiLol.Converter
{
	public static class SkinConverter
	{
        public static SkinDTO toDTO(this Skin skin) => new SkinDTO()
        {
            Name = skin.Name,
            Description = skin.Description,
            Icon = skin.Icon,
            Price = skin.Price
        };

        public static Skin toModel(this SkinDTO skin) => new Skin(skin.Name, skin.Description);

    }
}

