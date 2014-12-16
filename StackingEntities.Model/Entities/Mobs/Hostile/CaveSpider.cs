using System;
using StackingEntities.Model.Enums;

namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	[Serializable]
	public class CaveSpider :MobBase
	{
		public CaveSpider() : base(12)
		{
			Type = EntityType.CaveSpider;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Mobs/CaveSpider/CaveSpider.png";
	}
}