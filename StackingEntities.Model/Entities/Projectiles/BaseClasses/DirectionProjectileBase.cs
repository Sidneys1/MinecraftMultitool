using System;
using System.Text;
using StackingEntities.Model.Metadata;
using StackingEntities.Model.Objects.SimpleTypes;
using DoubleList = System.Collections.ObjectModel.ObservableCollection<StackingEntities.Model.Objects.SimpleTypes.SimpleDouble>;

namespace StackingEntities.Model.Entities.Projectiles.BaseClasses
{
	[Serializable]
	public abstract class DirectionProjectileBase : ProjectileBase
	{
		[EntityDescriptor("Projectile Options", "Direction", fixedSize: true, dgRowPath: "Name")]
		public new DoubleList Velocity
		{ get; }
		= new DoubleList
		{
			new SimpleDouble("X"),
			new SimpleDouble("Y"),
			new SimpleDouble("Z")
		};

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			double dx = Velocity[0].Value, dy = Velocity[1].Value, dz = Velocity[2].Value;
			if (Math.Abs(dx) > 0 || Math.Abs(dy) > 0 || Math.Abs(dz) > 0)
				b.Append(string.Format("direction:[{0:0.0},{1:0.0},{2:0.0}],", dx, dy, dz));

			return b.ToString();
		}
	}
}
