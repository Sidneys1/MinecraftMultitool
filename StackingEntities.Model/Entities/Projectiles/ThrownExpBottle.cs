using System;
using StackingEntities.Model.Entities.Projectiles.BaseClasses;
using StackingEntities.Model.Enums;

namespace StackingEntities.Model.Entities.Projectiles
{
	[Serializable]
	public class ThrownExpBottle : OwnedProjectileBase
	{
		public ThrownExpBottle()
		{
			Type = EntityType.ThrownExpBottle;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Projectiles/ThrownExpBottle.png";
	}
}
