using System;
using System.Text;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	[Serializable]
	public class WitherBoss :MobBase
	{
		[EntityDescriptor("Wither Options", "Invulnerable For <x> Ticks")]
		public int Invul { get; set; }

		public WitherBoss() : base(300)
		{
			Type = EntityTypes.WitherBoss;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Mobs/WitherBoss/WitherBoss.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (Invul != 0)
				b.AppendFormat("Invul:{0},", Invul);

			return b.ToString();
		}
	}
}
