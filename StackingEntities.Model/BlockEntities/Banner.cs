using System;
using System.Text;
using StackingEntities.Model.BlockEntities.BaseClasses;
using StackingEntities.Model.Enums;
using StackingEntities.Model.Metadata;
using PatternList = System.Collections.ObjectModel.ObservableCollection<StackingEntities.Model.Objects.BannerPattern>;

namespace StackingEntities.Model.BlockEntities
{
	[Serializable]
	public class Banner : BlockEntityBase
	{
		#region Properties

		[EntityDescriptor("Banner Options", "Base Color")]
		public Dyes Base { get; set; }

		[EntityDescriptor("Banner Options", "Patterns")]
		public PatternList Patterns { get; } = new PatternList();

		#endregion

		//public Banner() : base("Banner") { }

		#region Inherited

		public override string GenerateJson(bool topLevel)
		{
			if (Base == default(Dyes) && Patterns.Count == 0) return base.GenerateJson(false);
			var b = new StringBuilder(base.GenerateJson(false));
			b.AppendFormat("Base:{0:D},", Base);

			if (Patterns.Count == 0) return b.ToString();

			b.Append("Patterns:[");
			foreach (var bannerPattern in Patterns)
			{
				b.AppendFormat("{0},", bannerPattern.GenerateJson(false));
			}
			b.Remove(b.Length - 1, 1);
			b.Append("]");
			return b.ToString();
		}

		#endregion
	}
}