using System.ComponentModel;
using System.Text;

namespace StackingEntities.Model.Items.ItemTags
{
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
}