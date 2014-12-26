using System;
using System.ComponentModel;

namespace StackingEntities.Model.Objects.SimpleTypes
{
	[Serializable]
	public class SimpleInt
	{
		public SimpleInt(string name = null)
		{
			Name = name;
		}

		[DisplayName("Value")]
		public int Value { get; set; }

		public string Name { get; set; }
	}
}
