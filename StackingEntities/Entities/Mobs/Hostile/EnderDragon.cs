using System.Text;

namespace StackingEntities.Entities.Mobs.Hostile
{
	public class EnderDragon :MobBase
	{
		public EnderDragon()
		{
			Type = EntityTypes.EnderDragon;
			Health = 200;
		}

		public override string DisplayImage => "/Images/Mobs/EnderDragon/EnderDragon.png";

		public override string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJSON(topLevel));

			if (Health != 200)
				b.AppendFormat("HealF:{0:00}f,", Health);

			return b.ToString();
		}
	}
}
