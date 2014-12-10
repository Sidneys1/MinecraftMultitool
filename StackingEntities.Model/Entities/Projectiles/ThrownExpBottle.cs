using System;
using StackingEntities.Model.Entities.Projectiles.BaseClasses;

namespace StackingEntities.Model.Entities.Projectiles
{
	[Serializable]
	public class ThrownExpBottle : OwnedProjectileBase
	{
		public ThrownExpBottle()
		{
			Type = EntityTypes.ThrownExpBottle;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Projectiles/ThrownExpBottle.png";
	}
}
