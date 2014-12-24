using System.ComponentModel;

namespace StackingEntities.Model.Enums
{
	public enum SignRotation
	{
		Inherit=-1,
		South,
		[Description("South South-West")]
		SouthSouthWest,
		[Description("South-West")]
		SouthWest,
		[Description("West South-West")]
		WestSouthWest,
		West,
		[Description("West North-West")]
		WestNorthWest,
		[Description("North-West")]
		NorthWest,
		[Description("North North-West")]
		NorthNorthWest,
		North,
		[Description("North North-East")]
		NorthNorthEast,
		[Description("North-East")]
		NorthEast,
		[Description("East North-East")]
		EastNorthEast,
		East,
		[Description("East South-East")]
		EastSouthEast,
		[Description("South-East")]
		SouthEast,
		[Description("South South-East")]
		SouthSouthEast

	}
}