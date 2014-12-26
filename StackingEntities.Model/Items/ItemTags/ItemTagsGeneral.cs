using System;
using System.Text;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Interface;
using StackingEntities.Model.Metadata;
using BlockTypeList = System.Collections.ObjectModel.ObservableCollection<StackingEntities.Model.Objects.BlockType>;

namespace StackingEntities.Model.Items.ItemTags
{
	[Serializable]
	public class ItemTagsGeneral : IJsonAble
	{
		[EntityDescriptor("General", "Unbreakable")]
		public bool Unbreakable { get; set; }

		[EntityDescriptor("General", "Can Destroy")]
		public BlockTypeList CanDestroy { get; set; } = new BlockTypeList();

		public string GenerateJson(bool topLevel = true)
		{
			var b = new StringBuilder();

			if (Unbreakable)
				b.Append("Unbreakable:1b,");

			if (CanDestroy.Count == 0) return b.ToString();

			b.Append("CanDestroy:[");
			foreach (var item in CanDestroy)
			{
				b.AppendFormat("\"{0}\",", item.ToString().EscapeJsonString());
			}
			b.Remove(b.Length - 1, 1);
			b.Append("],");

			return b.ToString();
		}
	}
}