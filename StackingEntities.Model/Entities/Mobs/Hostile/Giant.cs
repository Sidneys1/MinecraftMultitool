using System;

namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	[Serializable]
	public class Giant : MobBase
	{
		public Giant() : base(100)
		{
			Type = EntityTypes.Giant;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Mobs/Zombie/Zombie.png";
	}
}
