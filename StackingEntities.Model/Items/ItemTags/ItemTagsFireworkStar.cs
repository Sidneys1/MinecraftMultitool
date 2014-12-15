using System;
using System.Text;
using StackingEntities.Model.Interface;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Items.ItemTags
{
	[Serializable]

	public class ItemTagsFireworkStar : IJsonAble 
	{
		[EntityDescriptor("Firework", "Flicker")]
		public bool Flicker { get; set; } = false;

		[EntityDescriptor("Firework", "Trail")]
		public bool Trail { get; set; } = false;

		[EntityDescriptor("Firework", "Type")]
		public FireworkShape Type { get; set; }

		[EntityDescriptor("Firework", "Flight Length"), MinMax(-128, 127)]
		public int Flight { get; set; }

		[EntityDescriptor("Firework", "Firework Star", isEnabledPath: "IsStarEnabled")]
		public bool IsStar { get; set; } = true;

		public bool IsStarEnabled { get; set; } = true;

		public string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder();

			b.Append(IsStar ? "Explosion:{" : "Fireworks:{");

			if (!IsStar)
				b.AppendFormat("Flight:{0}b,Explosions:[0:{{", Flight);

			if (Flicker)
				b.Append("Flicker:1b,");

			if (Trail)
				b.Append("Trail:1b,");

			if (Type != FireworkShape.SmallBall)
				b.AppendFormat("Type:{0:D}b,", Type);

			if(b[b.Length - 1] == ',')
			b.Remove(b.Length - 1, 1);

			if (!IsStar)
				b.Append("}]");

			b.Append("},");

			return b.Length > 13 ? b.ToString() : string.Empty;
		}
	}
}
