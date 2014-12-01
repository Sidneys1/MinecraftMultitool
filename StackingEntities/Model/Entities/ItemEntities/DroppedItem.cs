using System.Text;
using StackingEntities.Model.Items;
using StackingEntities.ViewModel;

namespace StackingEntities.Model.Entities.ItemEntities
{
	internal class DroppedItem : ItemEntityBase
	{
		public DroppedItem()
		{
			Type= EntityTypes.Item;
			Item = new Item();
		}

		[Property("Item Options","Item")]
		public Item Item { get; set; }

		public override string DisplayImage => "Images/Other/Item.png";

		public override string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJSON(topLevel));

			b.Append("Item:{");
			b.Append(Item.GenerateJSON(false));
			b.Append("},");

			return b.ToString();
		}
	}
}