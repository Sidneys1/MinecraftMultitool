using System;
using System.Text;
using StackingEntities.Model.Entities.Projectiles.BaseClasses;
using StackingEntities.Model.Enums;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Projectiles
{
	[Serializable]
	public class Fireball : DirectionProjectileBase
	{
		private int _explosionPower = 1;

		[EntityDescriptor("Fireball Options", "Explosion Power"), MinMax(0, int.MaxValue)]
		public int ExplosionPower
		{
			get { return _explosionPower; }
			set { _explosionPower = value; PropChanged("Display"); }
		}

		public Fireball()
		{
			Type = EntityType.Fireball;
		}

		public override string Display => base.Display + string.Format("Explosion Power {0}", ExplosionPower);

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Projectiles/Fireball.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (ExplosionPower != 1)
				b.AppendFormat("ExplosionPower:{0},", ExplosionPower);

			return b.ToString();
		}
	}
}
