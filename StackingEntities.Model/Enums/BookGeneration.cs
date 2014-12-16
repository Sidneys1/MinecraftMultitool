using System.ComponentModel;

namespace StackingEntities.Model.Enums
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