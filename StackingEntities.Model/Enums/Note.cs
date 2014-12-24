using System;
using System.ComponentModel;

namespace StackingEntities.Model.Enums
{
	[Serializable]
	public enum Note
	{
		// ReSharper disable InconsistentNaming
		Inherit=-1,

		[Description("F♯/G♭\t(Octave 1)")]
		FS1,
		[Description("G\t(Octave 1)")]
		G1,
		[Description("G♯/A♭\t(Octave 1)")]
		GS1,
		[Description("A\t(Octave 1)")]
		A1,
		[Description("A♯/B♭\t(Octave 1)")]
		AS1,
		[Description("B\t(Octave 1)")]
		B1,
		[Description("C\t(Octave 1)")]
		C1,
		[Description("C♯/D♭\t(Octave 1)")]
		CS1,
		[Description("D\t(Octave 1)")]
		D1,
		[Description("D♯/E♭\t(Octave 1)")]
		DS1,
		[Description("E\t(Octave 1)")]
		E1,
		[Description("F\t(Octave 1)")]
		F1,

		[Description("F♯/G♭\t(Mid-Octave)")]
		FS2,

		[Description("G\t(Octave 2)")]
		G2,
		[Description("G♯/A♭\t(Octave 2)")]
		GS2,
		[Description("A\t(Octave 2)")]
		A2,
		[Description("A♯/B♭\t(Octave 2)")]
		AS2,
		[Description("B\t(Octave 2)")]
		B2,
		[Description("C\t(Octave 2)")]
		C2,
		[Description("C♯/D♭\t(Octave 2)")]
		CS2,
		[Description("D\t(Octave 2)")]
		D2,
		[Description("D♯/E♭\t(Octave 2)")]
		DS2,
		[Description("E\t(Octave 2)")]
		E2,
		[Description("F\t(Octave 2)")]
		F2,
		[Description("F♯/G♭\t(Octave 2)")]
		FS3
		// ReSharper restore InconsistentNaming
	}
}