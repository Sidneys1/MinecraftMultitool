using System.Text;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	public class Ghast : MobBase
	{
		[Property("Ghast Options", "Explosion Power"), MinMax(0, int.MaxValue)]
		public int ExplosionPower { get; set; } = 1;

		public Ghast()
		{
			Type = EntityTypes.Ghast;
			Health = 10;
		}

		public override string DisplayImage => "/StackingEntities;component/Images/Mobs/Ghast/Ghast.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (Health != 10)
				b.AppendFormat("HealF:{0:00}f,", Health);

			if (ExplosionPower != 1)
				b.AppendFormat("ExplosionPower:{0},", ExplosionPower);

			return b.ToString();
		}
	}
}
