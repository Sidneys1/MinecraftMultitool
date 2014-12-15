using System.Text;
using StackingEntities.Model.Enums;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Interface;

namespace StackingEntities.Model.Objects
{
	public class AttributeModifier :IJsonAble
	{
		public string Name { get; set; } = string.Empty;

		public double Amount { get; set; }

		public AttributeModifierOperation Operation { get; set; }

		public string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder("");

			if (!string.IsNullOrWhiteSpace(Name))
				b.AppendFormat("Name:\"{0}\",", Name.EscapeJsonString());

			b.AppendFormat("Amount:{0:0.0#},", Amount);

			b.AppendFormat("Operation:{0:D}", Operation);

			return b.ToString();
		}
	}
}