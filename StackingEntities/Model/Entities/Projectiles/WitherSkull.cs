using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackingEntities.Model.Entities.Projectiles
{
	public class WitherSkull : BaseClasses.DirectionProjectileBase
	{
		public WitherSkull()
		{
			Type = EntityTypes.WitherSkull;
		}

		public override string DisplayImage => "/StackingEntities;component/Images/Projectiles/WitherSkull.png";
	}
}
