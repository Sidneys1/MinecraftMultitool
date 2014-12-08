using System.Collections.ObjectModel;
using System.Text;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Interface;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Items.ItemTags
{
	public class ItemTagsGeneral : IJsonAble
	{
		[EntityDescriptor("General", "Unbreakable")]
		public bool Unbreakable { get; set; }

		[EntityDescriptor("General", "Can Destroy")]
		public ObservableCollection<BlockType> CanDestroy { get; set; } = new ObservableCollection<BlockType>();

		public string GenerateJson(bool topLevel = true)
		{
			var b = new StringBuilder();

			if (Unbreakable)
				b.Append("Unbreakable:1b,");

			if (CanDestroy.Count == 0) return b.ToString();

			b.Append("CanPlaceOn:[");
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