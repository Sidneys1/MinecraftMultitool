using System;

namespace StackingEntities.Model.Entities.Mobs.Friendly
{
	[Serializable]
	public class Squid : MobBase
	{
		public Squid() : base(10)
		{
			Type = EntityTypes.Squid;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Mobs/Squid/Squid.png";
	}
}
