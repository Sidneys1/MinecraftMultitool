﻿using System.Text;

namespace StackingEntities.Entities.Mobs.Friendly
{
	public class Cow :BreedableMobBase
	{
		public Cow()
		{
			Type = EntityTypes.Cow;
			Health = 10;
		}
		public override string DisplayImage => (Age < 0) ? "/Images/Mobs/Cow/BabyCow.png": "/Images/Mobs/Cow/Cow.png";

		public override string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJSON(topLevel));

			if (Health != 10)
				b.AppendFormat("HealF:{0:00}f,", Health);

			return b.ToString();
		}
	}
}
