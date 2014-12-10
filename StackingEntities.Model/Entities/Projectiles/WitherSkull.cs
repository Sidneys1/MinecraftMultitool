using System;
using StackingEntities.Model.Entities.Projectiles.BaseClasses;

namespace StackingEntities.Model.Entities.Projectiles
{
	[Serializable]
	public class WitherSkull : DirectionProjectileBase
	{
		public WitherSkull()
		{
			Type = EntityTypes.WitherSkull;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Projectiles/WitherSkull.png";
	}
}
