using System.Text;

namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	public class Giant : MobBase
	{
		public Giant()
		{
			Type = EntityTypes.Giant;
			Health = 100;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Mobs/Zombie/Zombie.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (Health != 100)
				b.AppendFormat("HealF:{0:00}f,", Health);

			return b.ToString();
		}
	}
}
