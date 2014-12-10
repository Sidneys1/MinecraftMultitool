using System;

namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	[Serializable]
	public class Witch : MobBase
	{
		public Witch() : base(26)
		{
			Type = EntityTypes.Witch;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Mobs/Witch/Witch.png";
	}
}
