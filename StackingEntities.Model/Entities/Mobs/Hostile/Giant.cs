using System;
using StackingEntities.Model.Enums;

namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	[Serializable]
	public class Giant : MobBase
	{
		public Giant() : base(100)
		{
			Type = EntityType.Giant;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Mobs/Zombie/Zombie.png";
	}
}
