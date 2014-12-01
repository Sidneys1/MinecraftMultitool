using System.ComponentModel;

namespace StackingEntities.Items.ItemTags
{
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