using System;
using StackingEntities.Model.Enums;

namespace StackingEntities.Model.Entities.Other
{
	[Serializable]
	public class EyeOfEnder : EntityBase
	{
		public EyeOfEnder()
		{
			Type = EntityType.EyeOfEnderSignal;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Other/EyeOfEnder.png";
	}
}
