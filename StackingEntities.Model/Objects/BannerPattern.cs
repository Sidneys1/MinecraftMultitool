using System;
using System.Text;
using StackingEntities.Model.Enums;
using StackingEntities.Model.Interface;

namespace StackingEntities.Model.Objects
{
	[Serializable]
	public class BannerPattern : IJsonAble
	{
		public Dyes Color { get; set; }
		public BannerPatternId Pattern { get; set; }

		public string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder("{");

			if (Color != default(Dyes))
				b.AppendFormat("Base:{0:D},", Color);

			b.AppendFormat("Pattern:\"{0}\"}}", Pattern);

			return b.ToString();
		}
	}
}