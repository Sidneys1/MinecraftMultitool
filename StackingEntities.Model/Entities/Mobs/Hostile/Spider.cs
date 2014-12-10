using System;

namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	[Serializable]
	public class Spider :MobBase
	{
		public Spider() : base(16)
		{
			Type = EntityTypes.Spider;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Mobs/Spider/Spider.png";
	}
}
