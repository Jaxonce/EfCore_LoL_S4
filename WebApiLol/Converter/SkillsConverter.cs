using System;
using Model;

namespace WebApiLol.Converter
{
	public static class SkillsConverter
	{
        public static SkillDTO toDTO(this Skill skill) => new SkillDTO()
        {
            Name = skill.Name,
            Description = skill.Description,
        };

        public static Skill toModel(this SkillDTO skill) => new Skill(skill.Name, skill.Description);
    }
}

