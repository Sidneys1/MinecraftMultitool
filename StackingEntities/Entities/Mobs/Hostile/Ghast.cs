using System.Text;

namespace StackingEntities.Entities.Mobs.Hostile
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

		public override string DisplayImage => "/Images/Mobs/Ghast/Ghast.png";

		public override string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJSON(topLevel));

			if (Health != 10)
				b.AppendFormat("HealF:{0:00}f,", Health);

			if (ExplosionPower != 1)
				b.AppendFormat("ExplosionPower:{0},", ExplosionPower);

			return b.ToString();
		}
	}
}
