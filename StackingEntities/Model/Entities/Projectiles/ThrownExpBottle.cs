using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackingEntities.Model.Entities.Projectiles
{
	public class ThrownExpBottle : BaseClasses.OwnedProjectileBase
	{
		public ThrownExpBottle()
		{
			Type = EntityTypes.ThrownExpBottle;
		}

		public override string DisplayImage => "/StackingEntities;component/Images/Projectiles/ThrownExpBottle.png";
	}
}
