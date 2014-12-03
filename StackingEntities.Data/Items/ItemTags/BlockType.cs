using System.ComponentModel;

namespace StackingEntities.Model.Items.ItemTags
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