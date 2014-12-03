using System.Text;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	public class Guardian : MobBase
	{
		[EntityDescriptor("Guardian Options", "Is Elder")]
		public bool Elder { get; set; } = false;

		public Guardian()
		{
			Type = EntityTypes.Guardian;
			Health = 30;
		}

		public override string DisplayImage => Elder ? "/StackingEntities;component/Images/Mobs/Guardian/ElderGuardian.png" : "/StackingEntities;component/Images/Mobs/Guardian/Guardian.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (Health != (Elder ? 80 : 30))
				b.AppendFormat("HealF:{0:00}f,", Health);

			if (Elder)
				b.Append("Elder:1b,");

			return b.ToString();
		}
	}
}
