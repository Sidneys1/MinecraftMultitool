using System;
using System.Text;
using StackingEntities.Model.Entities.Projectiles.BaseClasses;
using StackingEntities.Model.Enums;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Projectiles
{
	[Serializable]
	public class Arrow : ShakingProjectileBase
	{
		[EntityDescriptor("Arrow Options", "DV Of Block Landed On"), MinMax(byte.MinValue, byte.MaxValue)]
		public int InData { get; set; }

		[EntityDescriptor("Arrow Options", "Age (In Ticks)", "Arrow despawns when this reaches 1200."), MinMax(0, short.MaxValue)]
		public int Life { get; set; }

		[EntityDescriptor("Arrow Options", "Damage"), MinMax(0, double.MaxValue)]
		public double Damage { get; set; }

		[EntityDescriptor("Arrow Options", "In Ground", "Arrow cannot be picked up in flight.")]
		public bool InGround { get; set; }

		[EntityDescriptor("Arrow Options", "Pick Up Mode")]
		public ArrowPickup Pickup { get; set; } = ArrowPickup.SurvivalCreative;

		public Arrow()
		{
			Type = EntityTypes.Arrow;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Projectiles/Arrow.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (InData != 0)
				b.AppendFormat("inData:{0}b,", InData);

			if (Life != 0)
				b.AppendFormat("life:{0}s,", Life);

			if (Damage > 0.0)
				b.AppendFormat("damage:{0:0.0},", Damage);

			if (InGround)
				b.Append("inGround:1b,");

			if (Pickup != ArrowPickup.SurvivalCreative)
				b.AppendFormat("pickup:{0:D}b,", Pickup);

			return b.ToString();
		}
	}
}
