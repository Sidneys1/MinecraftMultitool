using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackingEntities.Entities.Mobs.Hostile
{
	public class Blaze : MobBase
	{
		public Blaze()
		{
			Type = EntityTypes.Blaze;
			Health = 20;
		}


		public override string DisplayImage => "/Images/Mobs/Blaze/Blaze.png";

		public override string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJSON(topLevel));

			if (Health != 20)
				b.AppendFormat("HealF:{0:00}f,", Health);

			return b.ToString();
		}
	}
}
