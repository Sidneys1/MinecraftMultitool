using System;
using System.Text;
using StackingEntities.Model.Enums;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	[Serializable]
	public class Guardian : MobBase
	{
		[EntityDescriptor("Guardian Options", "Is Elder")]
		public bool Elder { get; set; } = false;

		public Guardian() : base(30)
		{
			Type = EntityType.Guardian;
		}

		public override string DisplayImage => Elder ? "/StackingEntities.Resources;component/Images/Mobs/Guardian/ElderGuardian.png" : "/StackingEntities.Resources;component/Images/Mobs/Guardian/Guardian.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (Elder)
				b.Append("Elder:1b,");

			return b.ToString();
		}
	}
}
