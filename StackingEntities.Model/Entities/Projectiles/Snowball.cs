using System;
using StackingEntities.Model.Entities.Projectiles.BaseClasses;
using StackingEntities.Model.Enums;

namespace StackingEntities.Model.Entities.Projectiles
{
	[Serializable]
	public class Snowball : OwnedProjectileBase
	{
		public Snowball()
		{
			Type = EntityType.Snowball;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Projectiles/Snowball.png";
	}
}
