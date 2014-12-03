using System.Text;

namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	public class CaveSpider :MobBase
	{
		public CaveSpider()
		{
			Type = EntityTypes.CaveSpider;
			Health = 12;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Mobs/CaveSpider/CaveSpider.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (Health != 12)
				b.AppendFormat("HealF:{0:00}f,", Health);

			return b.ToString();
		}
	}
}