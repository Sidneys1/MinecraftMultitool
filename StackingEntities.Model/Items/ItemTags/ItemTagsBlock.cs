using System;
using System.Text;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Interface;
using StackingEntities.Model.Metadata;
using BlockTypeList = System.Collections.ObjectModel.ObservableCollection<StackingEntities.Model.Objects.BlockType>;

namespace StackingEntities.Model.Items.ItemTags
{
	[Serializable]
	public class ItemTagsBlock : IJsonAble
	{
		[EntityDescriptor("Block", "Can Place On")]
		public BlockTypeList CanPlaceOn { get; set; } = new BlockTypeList();

		// TODO: Tile Entity Tags
		//[Property("Block", "Block Entity")]
		//public TileEntity BlockEntityTag{get;}

		public string GenerateJson(bool topLevel = true)
		{
			var b = new StringBuilder();


			if (CanPlaceOn.Count == 0) return b.ToString();

			b.Append("CanPlaceOn:[");
			foreach (var item in CanPlaceOn)
			{
				b.AppendFormat("\"{0}\",", item.ToString().EscapeJsonString());
			}
			b.Remove(b.Length - 1, 1);
			b.Append("],");

			return b.ToString();
		}
	}
}