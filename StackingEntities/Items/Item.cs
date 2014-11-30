using System.Collections.Generic;
using System.Text;
using StackingEntities.Items.ItemTags;

namespace StackingEntities.Items
{
	public class Item: IJsonAble
	{
		[Property("Item", "Count"), MinMax(byte.MinValue, byte.MaxValue)]
		public int Count { get; set; } = 1;

		[Property("Item", "Slot"), MinMax(byte.MinValue, byte.MaxValue)]
		public int? Slot { get; set; } = null;

		public bool HasSlotTag => Slot.HasValue;

		[Property("Item", "Damage/Data Value"), MinMax(short.MinValue, short.MaxValue)]
		public int Damage { get; set; } = 0;

		[Property("Item", "id")]
		public string Id { get; set; } = "minecraft:stone";

		public List<IJsonAble> Tag = new List<IJsonAble>();

		public bool HasTags => Tag.Count > 0;

		public Item()
		{
			Tag.Add(new ItemTagsBlock());
			Tag.Add(new ItemTagsGeneral());
            Tag.Add(new ItemTagsEnchantments());
			Tag.Add(new ItemTagsDisplay());
			Tag.Add(new ItemTagsBook());
			Tag.Add(new ItemTagsFireworkStar());
			Tag.Add(new ItemTagsMap());
		}

		public string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder();

			if (string.IsNullOrWhiteSpace(Id)) return b.ToString();

			if (Count != 1)
				b.AppendFormat("Count:{0}b,", Count);
			if (Slot.HasValue)
				b.AppendFormat("Slot:{0}b,", Slot);
			if (Damage != 0)
				b.AppendFormat("Damage:{0}s,", Damage);
			b.AppendFormat("id:\"{0}\",", JsonTools.EscapeStringValue(Id));

			if (Tag.Count == 0) return b.ToString();

			var b2 = new StringBuilder("tag:{");

			foreach (var jsonAble in Tag)
			{
				b2.Append(jsonAble.GenerateJSON(true));
			}
			b2.Remove(b2.Length - 1, 1);
			b2.Append("},");

			if (b2.Length > 7)
				b.Append(b2);
			return b.ToString();
		}
	}
}
