using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StackingEntities.Items.ItemTags
{
	public class ItemTagsMap : IJsonAble
	{
		[Property("Map", "Map is Scaled")]
		public bool MapScaling { get; set; } = false;

		[Property("Map","Markers")]
		public List<Decoration> Decor { get; set; } = new List<Decoration>();

		public string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder();
			if (MapScaling) b.Append("map_is_scaling:1b,");

			if (Decor.Count == 0) return b.ToString();

			b.Append("Decorations:[");

			for (var index = 0; index < Decor.Count; index++)
			{
				var decoration = Decor[index];
				b.AppendFormat("{0}:{{{1}}},", index, decoration.GenerateJSON(false));
			}

			b.Remove(b.Length - 1, 1);
			b.Append("],");

			return b.ToString();
		}
	}

	public class Decoration : IJsonAble
	{
		[DisplayName(@"ID")]
		public string Id { get; set; }
		[DisplayName(@"Marker Type")]
		public MapMarker MType { get; set; }

		[DisplayName(@"X")]
		public double X { get; set; }
		[DisplayName(@"Z")]
		public double Z { get; set;}
		[DisplayName(@"Rotation")]
		public double Rotation { get; set; }

		public string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder();

			if (!string.IsNullOrWhiteSpace(Id))
				b.AppendFormat("id:\"{0}\",", JsonTools.EscapeStringValue(Id));

			b.AppendFormat("type:{0:D}b,", MType);

			b.AppendFormat("x:{0:0.00},", X);
			b.AppendFormat("z:{0:0.00},", Z);
			b.AppendFormat("rot:{0:0.00}", Rotation);

			return b.ToString();
		}
	}

	public enum MapMarker
	{
		WhiteMarker,
		GreenMarker,
		RedMarker,
		BlueMarker,
		Cross,
		Arrow,
		Circle
	}

}
