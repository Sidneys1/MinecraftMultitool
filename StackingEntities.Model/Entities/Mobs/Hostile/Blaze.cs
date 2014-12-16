using System;
using StackingEntities.Model.Enums;

namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	[Serializable]
	public class Blaze : MobBase
	{
		public Blaze() : base(20)
		{
			Type = EntityType.Blaze;
		}


		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Mobs/Blaze/Blaze.png";
	}
}
