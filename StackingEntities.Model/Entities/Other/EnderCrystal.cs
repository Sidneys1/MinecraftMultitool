using System;

namespace StackingEntities.Model.Entities.Other
{
	[Serializable]
	public class EnderCrystal : EntityBase
	{
		public EnderCrystal()
		{ Type = EntityTypes.EnderCrystal;}
		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Other/EnderCrystal.png";
	}
}
