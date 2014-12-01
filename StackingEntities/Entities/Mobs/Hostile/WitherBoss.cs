using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackingEntities.Entities.Mobs.Hostile
{
	public class WitherBoss :MobBase
	{
		[Property("Wither Options", "Invulnerable For <x> Ticks")]
		public int Invul { get; set; }

		public WitherBoss()
		{
			Type = EntityTypes.WitherBoss;
			Health = 300;
		}

		public override string DisplayImage => "/Images/Mobs/WitherBoss/WitherBoss.png";

		public override string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJSON(topLevel));

			if (Health != 300)
				b.AppendFormat("HealF:{0}f,", Health);

			if (Invul != 0)
				b.AppendFormat("Invul:{0},", Invul);

			return b.ToString();
		}
	}
}
