using System;
using EntityFrameWorkLib;
using Model;

namespace DbDatamanager
{
	public static class ChampionChanger
	{

		public static Champion ToPoco(this ChampionEntity champion)
		{
			return new Champion(champion.Name, champion.Bio);
		}

		public static ChampionEntity ToEntity(this Champion champion)
		{
			return new ChampionEntity
			{
				Name = champion.Name,
				Bio= champion.Bio
			};
		}
	}
}

