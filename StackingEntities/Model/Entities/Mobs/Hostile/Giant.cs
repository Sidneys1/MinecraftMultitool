﻿using System.Text;

namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	public class Giant : MobBase
	{
		public Giant()
		{
			Type = EntityTypes.Giant;
			Health = 100;
		}

		public override string DisplayImage => "/Images/Mobs/Zombie/Zombie.png";

		public override string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJSON(topLevel));

			if (Health != 100)
				b.AppendFormat("HealF:{0:00}f,", Health);

			return b.ToString();
		}
	}
}
