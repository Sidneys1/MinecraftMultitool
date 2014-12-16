﻿using System;
using StackingEntities.Model.Entities.Projectiles.BaseClasses;
using StackingEntities.Model.Enums;

namespace StackingEntities.Model.Entities.Projectiles
{
	[Serializable]
	public class ThrownEnderPearl : OwnedProjectileBase
	{
		public ThrownEnderPearl()
		{
			Type = EntityType.ThrownEnderpearl;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Projectiles/ThrownEnderPearl.png";
	}
}
