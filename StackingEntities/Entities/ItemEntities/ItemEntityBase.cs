using System.Text;
using StackingEntities.Items;

namespace StackingEntities.Entities.ItemEntities
{
	internal abstract class ItemEntityBase : EntityBase
	{
		[Property("Item Entity Options", "Age")]
		public int Age { get; set; }

		[Property("Item Entity Options", "Health"), MinMax(0, 255)]
		public int Health { get; set; }

		protected ItemEntityBase()
		{
			Health = 5;
		}

		public override string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJSON(topLevel));

			if (Age != 0)
				b.AppendFormat("Age:{0},", Age);

			if (Health != 5)
				b.Append(string.Format("Health:{0},", Health));

			return b.ToString();
		}
	}

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