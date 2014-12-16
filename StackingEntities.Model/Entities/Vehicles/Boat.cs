using System;
using StackingEntities.Model.Enums;

namespace StackingEntities.Model.Entities.Vehicles
{
	[Serializable]
	public class Boat : EntityBase
	{
		public Boat()
		{
			Type = EntityType.Boat; //Health
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Vehicles/Boat.png";
	}
}
