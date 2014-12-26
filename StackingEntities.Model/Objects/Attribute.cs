using System;
using System.ComponentModel;
using System.Text;
using StackingEntities.Model.Enums;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Interface;
using AttributeModifierList = System.Collections.ObjectModel.ObservableCollection<StackingEntities.Model.Objects.AttributeModifier>;

namespace StackingEntities.Model.Objects
{
	[Serializable]
	public class Attribute : IJsonAble
	{
		[DisplayName(@"Name")]
		public AttributeType Name { get; set; }

		[DisplayName(@"Base Value")]
		public double Base { get; set; }

		public AttributeModifierList Modifiers { get; } = new AttributeModifierList();

		public string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder();

			b.AppendFormat("Name:\"{0}\",Base:{1:0.0}", Name.Description(), Base);

			if (Modifiers.Count <= 0) return b.ToString();

			b.Append("Modifiers:[");
			for (var i = 0; i < Modifiers.Count; i++)
			{
				b.AppendFormat("{0}:{{{1}}},", i, Modifiers[i].GenerateJson(false));
			}
			b.Remove(b.Length - 1, 1);
			b.Append("]");


			return b.ToString();
		}
	}
}