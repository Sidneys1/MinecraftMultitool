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

		public override string DisplayImage => "/Images/Mobs/CaveSpider/CaveSpider.png";

		public override string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJSON(topLevel));

			if (Health != 12)
				b.AppendFormat("HealF:{0:00}f,", Health);

			return b.ToString();
		}
	}
}