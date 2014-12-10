﻿using System;

namespace StackingEntities.Model.Entities.Vehicles
{
	[Serializable]
	public class Boat : EntityBase
	{
		public Boat()
		{
			Type = EntityTypes.Boat; //Health
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Vehicles/Boat.png";
	}
}
