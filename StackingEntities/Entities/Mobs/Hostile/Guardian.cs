using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackingEntities.Entities.Mobs.Hostile
{
	public class Guardian : MobBase
	{
		[Property("Guardian Options", "Is Elder")]
		public bool Elder { get; set; } = false;

		public Guardian()
		{
			Type = EntityTypes.Guardian;
			Health = 30;
		}

		public override string DisplayImage => Elder ? "/Images/Mobs/Guardian/ElderGuardian.png" : "/Images/Mobs/Guardian/Guardian.png";

		public override string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJSON(topLevel));

			if (Health != (Elder ? 80 : 30))
				b.AppendFormat("HealF:{0:00}f,", Health);

			if (Elder)
				b.Append("Elder:1b,");

			return b.ToString();
		}
	}
}
