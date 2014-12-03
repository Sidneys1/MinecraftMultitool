using System.Text;

namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	public class Blaze : MobBase
	{
		public Blaze()
		{
			Type = EntityTypes.Blaze;
			Health = 20;
		}


		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Mobs/Blaze/Blaze.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (Health != 20)
				b.AppendFormat("HealF:{0:00}f,", Health);

			return b.ToString();
		}
	}
}
