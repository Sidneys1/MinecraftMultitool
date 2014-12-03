using StackingEntities.Model.Entities.Projectiles.BaseClasses;

namespace StackingEntities.Model.Entities.Projectiles
{
	public class Snowball : OwnedProjectileBase
	{
		public Snowball()
		{
			Type = EntityTypes.Snowball;
		}

		public override string DisplayImage => "/StackingEntities;component/Images/Projectiles/Snowball.png";
	}
}
