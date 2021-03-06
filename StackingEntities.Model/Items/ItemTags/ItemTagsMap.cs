﻿using System;
using System.Text;
using StackingEntities.Model.Interface;
using StackingEntities.Model.Metadata;
using MapDecorationList = System.Collections.ObjectModel.ObservableCollection<StackingEntities.Model.Objects.MapDecoration>;

namespace StackingEntities.Model.Items.ItemTags
{
	[Serializable]
	public class ItemTagsMap : IJsonAble
	{
		[EntityDescriptor("Map", "Map is Scaled")]
		public bool MapScaling { get; set; } = false;

		[EntityDescriptor("Map","Markers")]
		public MapDecorationList Decor { get; } = new MapDecorationList();

		public string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder();
			if (MapScaling) b.Append("map_is_scaling:1b,");

			if (Decor.Count == 0) return b.ToString();

			b.Append("Decorations:[");

			for (var index = 0; index < Decor.Count; index++)
			{
				var decoration = Decor[index];
				b.AppendFormat("{0}:{{{1}}},", index, decoration.GenerateJson(false));
			}

			b.Remove(b.Length - 1, 1);
			b.Append("],");

			return b.ToString();
		}
	}
}
