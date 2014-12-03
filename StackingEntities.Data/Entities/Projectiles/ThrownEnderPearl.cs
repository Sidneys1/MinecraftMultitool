﻿using StackingEntities.Model.Entities.Projectiles.BaseClasses;

namespace StackingEntities.Model.Entities.Projectiles
{
	public class ThrownEnderPearl : OwnedProjectileBase
	{
		public ThrownEnderPearl()
		{
			Type = EntityTypes.ThrownEnderpearl;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Projectiles/ThrownEnderPearl.png";
	}
}
