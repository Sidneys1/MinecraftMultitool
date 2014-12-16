using System;
using StackingEntities.Model.Enums;

namespace StackingEntities.Model.Entities.Other
{
	[Serializable]
	public class LeashKnot : EntityBase
	{
		public LeashKnot ()
		{
			Type = EntityType.LeashKnot;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Other/Lead.png";
	}
}
