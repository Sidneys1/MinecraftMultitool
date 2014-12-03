using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackingEntities.Model.Entities.Projectiles
{
	public class ThrownEnderPearl : BaseClasses.OwnedProjectileBase
	{
		public ThrownEnderPearl()
		{
			Type = EntityTypes.ThrownEnderpearl;
		}

		public override string DisplayImage => "/StackingEntities;component/Images/Projectiles/ThrownEnderPearl.png";
	}
}
