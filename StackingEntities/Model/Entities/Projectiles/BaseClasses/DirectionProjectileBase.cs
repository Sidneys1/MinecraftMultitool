using System;
using System.Text;

namespace StackingEntities.Model.Entities.Projectiles.BaseClasses
{
	public abstract class DirectionProjectileBase : ProjectileBase
	{
		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			double Dx = Velocity[0].Value, Dy = Velocity[1].Value, Dz = Velocity[2].Value;
			if (Math.Abs(Dx) > 0 || Math.Abs(Dy) > 0 || Math.Abs(Dz) > 0)
				b.Append(string.Format("direction:[{0:0.0},{1:0.0},{2:0.0}],", Dx, Dy, Dz));

			return b.ToString();
		}
	}
}
