using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackingEntities.Entities.Other
{
	public class EyeOfEnder : EntityBase
	{
		public EyeOfEnder()
		{
			Type = EntityTypes.EyeOfEnderSignal;
		}

		public override string DisplayImage => "/Images/Other/EyeOfEnder.png";
	}
}
