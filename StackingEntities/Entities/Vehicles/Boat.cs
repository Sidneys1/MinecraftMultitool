using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackingEntities.Entities.Vehicles
{
	public class Boat : EntityBase
	{
		public Boat()
		{
			Type = EntityTypes.Boat; //Health
		}

		public override string DisplayImage => "/Images/Vehicles/Boat.png";
	}
}
