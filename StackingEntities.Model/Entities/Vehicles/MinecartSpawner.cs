﻿using System;
using StackingEntities.Model.Enums;

namespace StackingEntities.Model.Entities.Vehicles
{
	[Serializable]
	public class MinecartSpawner : Minecart
	{
		// TODO Spawner

		public MinecartSpawner()
		{
			Type = EntityType.MinecartSpawner;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Vehicles/MinecartSpawner.png";
	}
}
