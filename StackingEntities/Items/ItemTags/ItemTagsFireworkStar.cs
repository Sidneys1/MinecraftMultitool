using System.ComponentModel;
using System.Text;

namespace StackingEntities.Items.ItemTags
{
	public enum FireworkShape
	{
		[Description("Small Ball")]
		SmallBall,
		[Description("Large Ball")]
		LargeBall,
		Star,
		Creeper,
		Burst
	}


	public class ItemTagsFireworkStar : IJsonAble 
	{
		[Property("Firework", "Flicker")]
		public bool Flicker { get; set; } = false;

		[Property("Firework", "Trail")]
		public bool Trail { get; set; } = false;

		[Property("Firework", "Type")]
		public FireworkShape Type { get; set; }

		[Property("Firework", "Flight Length"), MinMax(-128, 127)]
		public int Flight { get; set; }

		[Property("Firework", "Firework Star")]
		public bool IsStar { get; set; } = true;

		public string GenerateJSON(bool topLevel)
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

			b.Remove(b.Length - 1, 1);

			if (!IsStar)
				b.Append("}]");

			b.Append("},");

			return b.Length > 13 ? b.ToString() : string.Empty;
		}
	}
}
