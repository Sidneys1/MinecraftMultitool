using System.Collections.Generic;
using System.Text;
using StackingEntities.ViewModel;

namespace StackingEntities.Model.Items.ItemTags
{
	public class ItemTagsBlock : IJsonAble
	{
		[Property("Block", "Can Place On")]
		public List<BlockType> CanPlaceOn { get; set; } = new List<BlockType>();

		//[Property("Block", "Block Entity")]
		//public TileEntity BlockEntityTag{get;}

		public string GenerateJSON(bool topLevel = true)
		{
			var b = new StringBuilder();


			if (CanPlaceOn.Count == 0) return b.ToString();

			b.Append("CanPlaceOn:[");
			foreach (var item in CanPlaceOn)
			{
				b.AppendFormat("\"{0}\",", JsonTools.EscapeStringValue(item.ToString()));
			}
			b.Remove(b.Length - 1, 1);
			b.Append(']');

			return b.ToString();
		}
	}
}