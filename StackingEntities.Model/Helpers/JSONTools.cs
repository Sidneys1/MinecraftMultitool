using System;
using System.Collections.Generic;
using System.Text;
using ItemList = System.Collections.ObjectModel.ObservableCollection<StackingEntities.Model.Items.Item>;

namespace StackingEntities.Model.Helpers
{
	public static class JsonTools
	{
		public static string EscapeJsonString(this string value)
		{
			const char backSlash = '\\';
			const char slash = '/';
			const char dblQuote = '"';

			const char ret = '\r';
			const char newl = '\n';

			if (string.IsNullOrWhiteSpace(value)) return string.Empty;

			var output = new StringBuilder(value.Length);
			for (var i = 0; i < value.Length; i++)
			{
				var c = value[i];
				switch (c)
				{
					case slash:
						output.AppendFormat("{0}{1}", backSlash, slash);
						break;

					case backSlash:
						if (value.Length < i + 1)
							if (value[i + 1] != 'n')
								output.AppendFormat("{0}{0}", backSlash);
							else
								output.Append(backSlash);
						break;

					case dblQuote:
						output.AppendFormat("{0}{1}", backSlash, dblQuote);
						break;

					case ret:
						break;

					case newl:
						output.Append("\\n");
						break;

					default:
						output.Append(c);
						break;
				}
			}

			return output.ToString();
		}

		public static string GenItems(ItemList items, string tagName = "Items")
		{
			var b = new StringBuilder();
			var usedSlots = new List<int>();

			var i = 0;
			foreach (var item in items)
			{
				if (item.Slot == null || usedSlots.Contains(item.Slot.Value)) continue;

				var s = item.GenerateJson(false);

				if (s == string.Empty) continue;

				if (item.Slot != null) usedSlots.Add(item.Slot.Value);
				if (s[s.Length - 1] == ',')
					s = s.Remove(s.Length - 1, 1);

				b.AppendFormat("{0}:{{{1}}},", i++, s);
			}

			if (b.Length == 0)
				return string.Empty;

			if (b[b.Length - 1] == ',')
				b.Remove(b.Length - 1, 1);


			b.Insert(0, string.Format("{0}:[", tagName));
			b.Append("],");

			usedSlots.Clear();

			return b.ToString();
		}

		public static string TicksToTime(int ticks)
		{
			if (ticks < 20)
				return string.Format("{0} Ticks", ticks);

			var t = TimeSpan.FromMilliseconds((ticks / 20.0) * 1000.0);

			var b = new StringBuilder();

			if (t.Days > 0)
				b.AppendFormat("{0}d, ", t.Days);

			if (t.Hours > 0)
				b.AppendFormat("{0}h, ", t.Hours);

			if (t.Minutes > 0)
				b.AppendFormat("{0}m, ", t.Minutes);


			b.AppendFormat("{0}s, ", t.Seconds);

			if (t.Milliseconds > 0)
				b.AppendFormat("{0}ms, ", t.Milliseconds);

			if (b.ToString().EndsWith(", "))
				b.Remove(b.Length - 2, 2);

			return b.ToString();
		}

	}
}
