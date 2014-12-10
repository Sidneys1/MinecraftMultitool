using System;
using System.ComponentModel;

namespace StackingEntities.Model.Items.ItemTags
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