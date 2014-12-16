using System;
using System.Text;
using StackingEntities.Model.Entities.ItemEntities.BaseClasses;
using StackingEntities.Model.Enums;
using StackingEntities.Model.Items;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.ItemEntities
{
	[Serializable]
	internal class DroppedItem : ItemEntityBase
	{
		public DroppedItem()
		{
			Type= EntityType.Item;
		}

		[EntityDescriptor("Item Options","Item")]
		public Item Item { get; set; } = new Item {SlotTitle = "Item"};

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Other/Item.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			b.Append("Item:{");
			b.Append(Item.GenerateJson(false));
			if (b[b.Length - 1] == ',')
				b.Remove(b.Length - 1, 1);
			b.Append("},");

			return b.ToString();
		}
	}
}