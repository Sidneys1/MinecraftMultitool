using System;
using StackingEntities.Model.Enums;

namespace StackingEntities.Model.Entities.Other
{
	[Serializable]
	public class EnderCrystal : EntityBase
	{
		public EnderCrystal()
		{ Type = EntityType.EnderCrystal;}
		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Other/EnderCrystal.png";
	}
}
