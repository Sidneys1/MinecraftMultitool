using System.Text;
using StackingEntities.ViewModel;

namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	internal class Endermite : MobBase 
	{
		public Endermite() { Type = EntityTypes.Endermite; Health = 8; Lifetime = 0; }

		[Property("Endermite Options", "Lifetime")]
		[MinMax(0, 2400)]
		public int Lifetime { get; set; }

		[Property("Endermite Options", "Spawned by Player")]
		public bool PlayerSpawned { get; set; } = false;

		public override string DisplayImage => "/StackingEntities;component/Images/Mobs/Endermite/Endermite.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (Lifetime != 0)
				b.Append(string.Format("Lifetime:{0},", Lifetime));

			if (Health != 8)
				b.Append(string.Format("HealF:{0},", Health));

			if (PlayerSpawned)
				b.Append("PlayerSpawned:1b,");

			return b.ToString();
		}
	}
}