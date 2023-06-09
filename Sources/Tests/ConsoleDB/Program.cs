﻿// See https://aka.ms/new-console-template for more information

using EntityFrameWorkLib;
using Microsoft.EntityFrameworkCore;
using Shared;

SkillEntity skill1 = new SkillEntity
{
    Name = "skill1",
    Description = "Cette description est celle du skill1",
    SkillType = SkillType.Basic,
};

LargeImageEntity largeImage = new LargeImageEntity
{
    Base64 = "data:image/png;base64,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"
};

ChampionEntity jax = new ChampionEntity
{
    Name = "jax",
    Icon = "icon jax",
    Bio = "test bio jax",
    Class = ChampionClass.Fighter,
    LargeImage = largeImage
};
ChampionEntity darius = new ChampionEntity
{
    Name = "darius",
    Icon = "icon darius",
    Bio = "test bio darius",
    Class = ChampionClass.Assassin,
};
ChampionEntity champions = new ChampionEntity
{
    Name = "toto",
    Icon = "icon",
    Bio = "test bio champion",
    Class = ChampionClass.Marksman,
};

using (var context = new LolContext())
{
    Console.WriteLine("Create and Insert new Champion");
    context.Skill.AddAsync(skill1);
    context.LargeImage.AddAsync(largeImage);
    context.Champions.AddAsync(champions);
    context.Champions.AddAsync(darius);
    context.Champions.AddAsync(jax);

    await context.SaveChangesAsync();
}