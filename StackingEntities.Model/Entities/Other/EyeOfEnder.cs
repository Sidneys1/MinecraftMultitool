using System;

namespace StackingEntities.Model.Entities.Other
{
	[Serializable]
	public class EyeOfEnder : EntityBase
	{
		public EyeOfEnder()
		{
			Type = EntityTypes.EyeOfEnderSignal;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Other/EyeOfEnder.png";
	}
}
