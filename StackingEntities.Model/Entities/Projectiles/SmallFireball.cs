using System;
using StackingEntities.Model.Entities.Projectiles.BaseClasses;
using StackingEntities.Model.Enums;

namespace StackingEntities.Model.Entities.Projectiles
{
	[Serializable]
	public class SmallFireball : DirectionProjectileBase
	{
		public SmallFireball()
		{
			Type = EntityType.SmallFireball;
		}
		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Projectiles/Fireball.png";
	}
}
