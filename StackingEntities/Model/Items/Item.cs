using System.Collections.Generic;
using System.Text;
using StackingEntities.ViewModel;

namespace StackingEntities.Model.Items
{
	public class Item: IJsonAble
	{
		[Property("Item", "Count"), MinMax(byte.MinValue, byte.MaxValue)]
		public int Count { get; set; } = 1;

		public bool CountTagEnabled { get; set; } = true;

		[Property("Item", "Slot"), MinMax(byte.MinValue, byte.MaxValue)]
		public int? Slot { get; set; } = null;

		public bool HasSlotTag => Slot.HasValue;

		public bool SlotTagEnabled { get; set; } = true;

		[Property("Item", "Damage/Data Value"), MinMax(short.MinValue, short.MaxValue)]
		public int Damage { get; set; } = 0;

		public bool DamageTagEnabled { get; set; } = true;

		[Property("Item", "id")]
		public string Id { get; set; }

		public bool IdTagEnabled { get; set; } = true;

		public List<IJsonAble> Tag = new List<IJsonAble>();

		public bool HasTags => Tag.Count > 0;

		public string GenerateJson(bool topLevel)
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
				b2.Append(jsonAble.GenerateJson(true));
			}
			b2.Remove(b2.Length - 1, 1);
			b2.Append("},");

			if (b2.Length > 7)
				b.Append(b2);
			return b.ToString();
		}
	}
}
