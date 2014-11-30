using System.Text;

namespace StackingEntities.Entities.Mobs.Hostile
{
	internal class Endermite : MobBase 
	{
		public Endermite() { Type = EntityTypes.Endermite; Health = 8; Lifetime = 0; }

		[Property("Ender-mite Options", "Lifetime")]
		[MinMax(0, 2400)]
		public int Lifetime { get; set; }

		public override string DisplayImage => "/Images/Mobs/Endermite/Endermite.png";

		public override string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJSON(topLevel));

			if (Lifetime != 0)
				b.Append(string.Format("Lifetime:{0},", Lifetime));

			if (Health != 8)
				b.Append(string.Format("HealF:{0},", Health));

			return b.ToString();
		}
	}
}