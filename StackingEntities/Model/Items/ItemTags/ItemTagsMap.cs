using System.Collections.Generic;
using System.Text;
using StackingEntities.Model.Interface;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Items.ItemTags
{
	public class ItemTagsMap : IJsonAble
	{
		[EntityDescriptor("Map", "Map is Scaled")]
		public bool MapScaling { get; set; } = false;

		[EntityDescriptor("Map","Markers")]
		public List<Decoration> Decor { get; set; } = new List<Decoration>();

		public string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder();
			if (MapScaling) b.Append("map_is_scaling:1b,");

			if (Decor.Count == 0) return b.ToString();

			b.Append("Decorations:[");

			for (var index = 0; index < Decor.Count; index++)
			{
				var decoration = Decor[index];
				b.AppendFormat("{0}:{{{1}}},", index, decoration.GenerateJson(false));
			}

			b.Remove(b.Length - 1, 1);
			b.Append("],");

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
