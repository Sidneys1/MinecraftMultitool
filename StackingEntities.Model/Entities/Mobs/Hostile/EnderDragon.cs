using System;
using StackingEntities.Model.Enums;

namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	[Serializable]
	public class EnderDragon :MobBase
	{
		public EnderDragon() : base(200)
		{
			Type = EntityType.EnderDragon;
			Health = 200;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Mobs/EnderDragon/EnderDragon.png";
	}
}
