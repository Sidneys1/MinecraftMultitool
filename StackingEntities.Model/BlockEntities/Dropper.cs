using System;
using System.Linq;
using System.Text;
using StackingEntities.Model.BlockEntities.BaseClasses;
using StackingEntities.Model.Items;
using StackingEntities.Model.Metadata;
using ItemList = System.Collections.ObjectModel.ObservableCollection<StackingEntities.Model.Items.Item>;

namespace StackingEntities.Model.BlockEntities
{
	[Serializable]
	public class Dropper : LockedContainerBase
	{
		#region Properties

		[EntityDescriptor("Dropper/Dispenser Options", "Items", fixedSize: true), MinMax(3, 3)]
		public ItemList Items { get; }

		#endregion

		public Dropper()
		{
			Items = new ItemList(Enumerable.Range(0, 9).Select(o => new Item { Slot = o, SlotTagEnabled = false }).ToList());
		}

		#region Inherited

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(false));

			var items = new string[Items.Count];
			string s;

			for (var i = 0; i < Items.Count; i++)
			{
				s = Items[i].GenerateJson(false);
				if (!string.IsNullOrWhiteSpace(s))
					items[i] = s;
			}

			if (items.All(string.IsNullOrWhiteSpace)) return b.ToString();

			b.Append("Items:[");
			for (var i = 0; i < Items.Count; i++)
			{
				s = items[i];
				if (string.IsNullOrWhiteSpace(s)) continue;
				if (s.EndsWith(","))
					s = s.Remove(s.Length - 1, 1);
				b.AppendFormat("{0}:{{{1}}},", i, s);
			}
			b.Remove(b.Length - 1, 1);
			b.Append("]");

			return b.ToString();
		}

		#endregion
	}
}
