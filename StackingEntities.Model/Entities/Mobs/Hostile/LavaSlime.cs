using System;
using StackingEntities.Model.Enums;

namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	[Serializable]
	public class LavaSlime : Slime
	{
		public LavaSlime()
		{
			Type = EntityType.LavaSlime;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Mobs/Slime/LavaSlime.png";
	}
}