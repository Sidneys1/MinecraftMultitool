using System;
using System.Text;
using StackingEntities.Model.Entities.ItemEntities.BaseClasses;
using StackingEntities.Model.Items;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.ItemEntities
{
	[Serializable]
	internal class DroppedItem : ItemEntityBase
	{
		public DroppedItem()
		{
			Type= EntityTypes.Item;
		}

		[EntityDescriptor("Item Options","Item")]
		public Item Item { get; set; } = new Item {SlotTitle = "Item"};

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Other/Item.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			b.Append("Item:{");
			b.Append(Item.GenerateJson(false));
			b.Append("},");

			return b.ToString();
		}
	}
}