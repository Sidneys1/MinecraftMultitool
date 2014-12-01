using System.Collections.Generic;
using System.Text;
using StackingEntities.ViewModel;

namespace StackingEntities.Model.Items.ItemTags
{
	public class ItemTagsGeneral : IJsonAble
	{
		[Property("General", "Unbreakable")]
		public bool Unbreakable { get; set; }

		[Property("General", "Can Destroy")]
		public List<BlockType> CanDestroy { get; set; } = new List<BlockType>();

		public string GenerateJson(bool topLevel = true)
		{
			var b = new StringBuilder();

			if (Unbreakable)
				b.Append("Unbreakable:1b,");

			if (CanDestroy.Count == 0) return b.ToString();

			b.Append("CanPlaceOn:[");
			foreach (var item in CanDestroy)
			{
				b.AppendFormat("\"{0}\",", JsonTools.EscapeStringValue(item.ToString()));
			}
			b.Remove(b.Length - 1, 1);
			b.Append("],");

			return b.ToString();
		}
	}
}