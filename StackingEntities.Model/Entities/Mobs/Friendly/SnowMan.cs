using System;
using StackingEntities.Model.Enums;

namespace StackingEntities.Model.Entities.Mobs.Friendly
{
	[Serializable]
	public class SnowMan : MobBase
	{
		public SnowMan() : base(4)
		{
			Type = EntityType.SnowMan;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Mobs/SnowMan/SnowMan.png";
	}
}
