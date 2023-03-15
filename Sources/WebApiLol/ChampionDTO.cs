﻿using System;
namespace WebApiLol
{
	public class ChampionDTO
	{
        public ChampionDTO(string name, string bio, string icon, string championClassDTO)
        {
            Name = name;
            Bio = bio;
            Icon = icon;
            Class = championClassDTO;
        }

        public int UniqueId { get; set; }

        public string Name { get; set; }

        public string Bio { get; set; }

        public string Icon { get; set; }

        public string Class { get; set; }

        public bool equals(ChampionDTO other)
        {
            return other.Name == this.Name && other.Bio == this.Bio && other.Icon == this.Icon;
        }

        public string toString()
        {
            return Name + Bio + Icon;
        }
    }
}

