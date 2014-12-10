using System;
using System.Text;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Projectiles.BaseClasses
{
	[Serializable]
	public abstract class ShakingProjectileBase : ProjectileBase
	{
		[EntityDescriptor("Projectile Options", "Arrow Shake"), MinMax(byte.MinValue, byte.MaxValue)]
		public int Shake { get; set; }

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (Shake != 0)
				b.AppendFormat("shake:{0}b,", Shake);

			return b.ToString();
		}
	}
}
