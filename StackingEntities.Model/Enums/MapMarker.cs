using System;
using System.ComponentModel;

namespace StackingEntities.Model.Enums
{
	[Serializable]
	public enum MapMarker
	{
		[Description("White Marker")]
		WhiteMarker,
		[Description("Green Marker")]
		GreenMarker,
		[Description("Red Marker")]
		RedMarker,
		[Description("Blue Marker")]
		BlueMarker,
		Cross,
		Arrow,
		Circle
	}
}