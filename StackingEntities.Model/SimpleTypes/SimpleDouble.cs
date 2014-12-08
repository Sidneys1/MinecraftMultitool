using System.ComponentModel;

namespace StackingEntities.Model.SimpleTypes
{
	public class SimpleDouble
	{
		public SimpleDouble(string name = null)
		{
			Name = name;
		}

		[DisplayName("Value")]
		public double Value { get; set; }

		public string Name { get; set; }
	}
}