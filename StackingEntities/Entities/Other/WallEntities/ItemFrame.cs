using System;
using System.Text;

namespace StackingEntities.Entities.Other.WallEntities
{
	internal class ItemFrame : WallEntityBase
	{
		public ItemFrame() { Type = EntityTypes.ItemFrame; ItemDropChance = 1f; }

		[Property("Item Frame Options", "Item Drop Chance")]
		public double ItemDropChance { get; set; }

		[Property("Wall Entity Options", "Rotation")]
		public int ItemRotation { get; set; }

		#region UI

		public override string Display => "Item Frame";

		public override string DisplayImage => "Images/Other/ItemFrame.png";

		#endregion

		#region Process

		public override string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJSON(topLevel));

			if (Math.Abs(ItemDropChance - 1) > 0)
				b.Append(string.Format("ItemDropChance:{0:0.##},", ItemDropChance));

			if (ItemRotation != 0)
				b.Append(string.Format("ItemRotation:{0},", ItemRotation));

			return b.ToString();
		}

		#endregion
	}
}