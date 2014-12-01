using System.Text;

namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	public class EnderDragon :MobBase
	{
		public EnderDragon()
		{
			Type = EntityTypes.EnderDragon;
			Health = 200;
		}

		public override string DisplayImage => "/StackingEntities;component/Images/Mobs/EnderDragon/EnderDragon.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (Health != 200)
				b.AppendFormat("HealF:{0:00}f,", Health);

			return b.ToString();
		}
	}
}
