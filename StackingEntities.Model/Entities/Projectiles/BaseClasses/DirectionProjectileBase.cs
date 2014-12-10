using System;
using System.Collections.ObjectModel;
using System.Text;
using StackingEntities.Model.Metadata;
using StackingEntities.Model.SimpleTypes;

namespace StackingEntities.Model.Entities.Projectiles.BaseClasses
{
	[Serializable]
	public abstract class DirectionProjectileBase : ProjectileBase
	{
		[EntityDescriptor("Projectile Options", "Direction", fixedSize: true, dgRowPath: "Name")]
		public new ObservableCollection<SimpleDouble> Velocity
		{ get; }
		= new ObservableCollection<SimpleDouble>
		{
			new SimpleDouble("X"),
			new SimpleDouble("Y"),
			new SimpleDouble("Z")
		};

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
