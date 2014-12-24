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
	public class Hopper : LockedContainerBase
	{
		#region Properties

		[EntityDescriptor("Hopper Options", "Items", fixedSize: true), MinMax(5, 1)]
		public ItemList Items { get; }

		[EntityDescriptor("Hopper Options", "Override Cooldown", "Uncheck to Inherit")]
		public bool WriteTranCool { get; set; } = false;
		[EntityDescriptor("Hopper Options", "Ticks Until Next Transfer", isEnabledPath:"WriteTranCool"), MinMax(0, int.MaxValue)]
		public int TransferCooldown { get; set; }

		#endregion

		public Hopper()
		{
			Items = new ItemList(Enumerable.Range(0, 5).Select(o => new Item { Slot = o, SlotTagEnabled = false, SlotTitle = string.Format("Hopper Slot {0}", o + 1) }).ToList());
		}

		#region Inherited

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(false));

			if (WriteTranCool)
				b.AppendFormat("TransferCooldown:{0},", TransferCooldown);

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
