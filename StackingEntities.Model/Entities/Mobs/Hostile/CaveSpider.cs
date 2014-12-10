using System;

namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	[Serializable]
	public class CaveSpider :MobBase
	{
		public CaveSpider() : base(12)
		{
			Type = EntityTypes.CaveSpider;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Mobs/CaveSpider/CaveSpider.png";
	}
}