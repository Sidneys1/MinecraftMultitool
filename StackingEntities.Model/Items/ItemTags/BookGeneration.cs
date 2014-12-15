using System.ComponentModel;

namespace StackingEntities.Model.Items.ItemTags
{
	public enum BookGeneration
	{
		Original,
		Copy,
		[Description("Copy of a Copy")]
		CopyOfCopy,
		Tattered
	}
}