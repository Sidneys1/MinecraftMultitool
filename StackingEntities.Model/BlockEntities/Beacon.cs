using System;
using System.Text;
using StackingEntities.Model.BlockEntities.BaseClasses;
using StackingEntities.Model.Enums;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.BlockEntities
{
	[Serializable]
	public class Beacon : LockedContainerBase
	{
		#region Properties

		[EntityDescriptor("Beacon Options", "Beacon Levels Available"), MinMax(0, 3)]
		public int Levels { get; set; }

		[EntityDescriptor("Beacon Options", "Primary Effect")]
		public PotionEffectId Primary { get; set; } = PotionEffectId.Inherit;

		[EntityDescriptor("Beacon Options", "Secondary Effect")]
		public PotionEffectId Secondary { get; set; } = PotionEffectId.Inherit;

		#endregion

		//public Beacon()// : base("Beacon")
		//{

		//}

		#region Inherited

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(false));

			b.AppendFormat("Levels:{0},", Levels);

			if (Primary != PotionEffectId.Inherit)
				b.AppendFormat("Primary:{0:D},", Primary);

			if (Secondary != PotionEffectId.Inherit)
				b.AppendFormat("Secondary:{0:D},", Secondary);

			return b.ToString();
		}

		#endregion

	}
}
