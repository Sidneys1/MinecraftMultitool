using System;
using System.Text;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	[Serializable]
	internal class Endermite : MobBase 
	{
		public Endermite() : base(8) { Type = EntityTypes.Endermite; }

		[EntityDescriptor("Endermite Options", "Lifetime")]
		[MinMax(0, 2400)]
		public int Lifetime { get; set; }

		[EntityDescriptor("Endermite Options", "Spawned by Player")]
		public bool PlayerSpawned { get; set; } = false;

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Mobs/Endermite/Endermite.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (Lifetime != 0)
				b.Append(string.Format("Lifetime:{0},", Lifetime));

			if (PlayerSpawned)
				b.Append("PlayerSpawned:1b,");

			return b.ToString();
		}
	}
}