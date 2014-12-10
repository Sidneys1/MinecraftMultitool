using System;
using System.Text;
using StackingEntities.Model.Items;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Other.WallEntities
{
	[Serializable]
	internal class ItemFrame : WallEntityBase
	{
		public ItemFrame() { Type = EntityTypes.ItemFrame; ItemDropChance = 1f; }

		[EntityDescriptor("Item Frame Options", "Item Drop Chance")]
		public double ItemDropChance { get; set; }

		[EntityDescriptor("Wall Entity Options", "Rotation")]
		public int ItemRotation { get; set; }

		public Item Item { get; }= new Item {Count = 1, CountTagEnabled = false, SlotTitle = "Item"};

		#region UI

		public override string Display => "Item Frame";

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Other/ItemFrame.png";

		#endregion

		#region Process

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (Math.Abs(ItemDropChance - 1) > 0)
				b.Append(string.Format("ItemDropChance:{0:0.##},", ItemDropChance));

			if (ItemRotation != 0)
				b.Append(string.Format("ItemRotation:{0},", ItemRotation));

			if (Item.HasId)
				b.AppendFormat("Item:{{{0}}},", Item.GenerateJson(false));

			return b.ToString();
		}

		#endregion
	}
}