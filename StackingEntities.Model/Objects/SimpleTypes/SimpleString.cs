using System;
using System.ComponentModel;

namespace StackingEntities.Model.Objects.SimpleTypes
{
	[Serializable]
	public class SimpleString
	{
		public SimpleString()
		{
			Name = "Value";
		}

		public SimpleString(string name = "Value")
		{
			Name = name;
		}

		[DisplayName("Value")]
		public string Value { get; set; }

		public string Name { get; set; }
	}
}