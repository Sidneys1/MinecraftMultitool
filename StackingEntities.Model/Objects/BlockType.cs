using System;
using System.ComponentModel;

namespace StackingEntities.Model.Objects
{
	[Serializable]
	public class BlockType
	{
		[DisplayName(@"Block ID")]
		public string Id { get; set; }

		public override string ToString()
		{
			return Id;
		}
	}
}