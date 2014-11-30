using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackingEntities.Entities.Other
{
	public class EnderCrystal : EntityBase
	{
		public EnderCrystal()
		{ Type = EntityTypes.EnderCrystal;}
		public override string DisplayImage => "/Images/Other/EnderCrystal.png";
	}
}
