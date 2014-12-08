using StackingEntities.Model.Entities.Projectiles.BaseClasses;

namespace StackingEntities.Model.Entities.Projectiles
{
	public class SmallFireball : DirectionProjectileBase
	{
		public SmallFireball()
		{
			Type = EntityTypes.SmallFireball;
		}
		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Projectiles/Fireball.png";
	}
}
