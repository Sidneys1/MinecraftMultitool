using System;

namespace StackingEntities.Model.SimpleTypes
{
	[Serializable]
	public class ValueDescription
	{
		public Enum Value { get; set; }
		public string Description { get; set; }
	}
}