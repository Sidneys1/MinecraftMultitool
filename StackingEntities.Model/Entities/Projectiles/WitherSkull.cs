using System;
using StackingEntities.Model.Entities.Projectiles.BaseClasses;
using StackingEntities.Model.Enums;

namespace StackingEntities.Model.Entities.Projectiles
{
	[Serializable]
	public class WitherSkull : DirectionProjectileBase
	{
		public WitherSkull()
		{
			Type = EntityType.WitherSkull;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Projectiles/WitherSkull.png";
	}
}
