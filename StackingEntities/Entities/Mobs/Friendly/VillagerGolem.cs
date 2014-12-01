using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackingEntities.Entities.Mobs.Friendly
{
	public class VillagerGolem : MobBase
	{
		[Property("Iron Golem Options", "Created by Player")]
		public bool PlayerCreated { get; set; } = false;

		public VillagerGolem()
		{
			Type = EntityTypes.VillagerGolem;
			Health = 100;
		}

		public override string DisplayImage => "/Images/Mobs/VillagerGolem/VillagerGolem.png";

		public override string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJSON(topLevel));

			if (Health != 100)
				b.AppendFormat("HealF:{0}f,", Health);

			if (PlayerCreated)
				b.Append("PlayerCreated:1b,");

			return b.ToString();
		}
	}
}
