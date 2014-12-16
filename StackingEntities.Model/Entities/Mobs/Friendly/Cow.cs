using System;
using System.Text;
using StackingEntities.Model.Enums;

namespace StackingEntities.Model.Entities.Mobs.Friendly
{
	[Serializable]
	public class Cow :BreedableMobBase
	{
		public Cow() :base(10)
		{
			Type = EntityType.Cow;
			Health = 10;
		}
		public override string DisplayImage => (Age < 0) ? "/StackingEntities.Resources;component/Images/Mobs/Cow/BabyCow.png" : "/StackingEntities.Resources;component/Images/Mobs/Cow/Cow.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			return b.ToString();
		}
	}
}
