using System.Text;
using StackingEntities.ViewModel;

namespace StackingEntities.Model.Entities.Mobs.Friendly
{
	public class VillagerGolem : MobBase
	{
		[Property("Iron Golem Options", "Created by Player")]
		public bool PlayerCreated { get; set; } = false;

		public VillagerGolem()
		{
			Type = EntityTypes.VillagerGolem;
			Health = 100;
		}

		public override string DisplayImage => "/StackingEntities;component/Images/Mobs/VillagerGolem/VillagerGolem.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (Health != 100)
				b.AppendFormat("HealF:{0}f,", Health);

			if (PlayerCreated)
				b.Append("PlayerCreated:1b,");

			return b.ToString();
		}
	}
}
