using System;
using System.ComponentModel;

namespace StackingEntities.Model.Enums
{
	[Serializable]
	public enum BannerPatternId
	{
		// Resharper disable InconsistentNaming
		[Description("Creeper")]
		cre,
		[Description("Skull")]
		sku,
		[Description("Flower")]
		flo,
		[Description("Brick")]
		bri,
		[Description("Middle Circle")]
		mc,
		[Description("Top Right Corner")]
		tr,
		[Description("Top Left Corner")]
		tl,
		[Description("Bottom Left Corner")]
		bl,
		[Description("Bottom Right Corner")]
		br,
		[Description("Top Triangle")]
		tt,
		[Description("Bottom Triangle")]
		bt,
		[Description("Down Left Stripe")]
		dls,
		[Description("Down Right Stripe")]
		drs,
		[Description("Cross")]
		cr,
		[Description("Top Triangle Saw")]
		tts,
		[Description("Bottom Triangle Saw")]
		bts,
		[Description("Middle Stripe (Horizontal)")]
		ms,
		[Description("Center Stripe (Verticle)")]
		cs,
		[Description("Middle Rhombus")]
		mr,
		[Description("Top Stripe")]
		ts,
		[Description("Horizontal (Top) Half")]
		hh,
		[Description("Bottom Stripe")]
		bs,
		[Description("Small (Vertical) Stripes")]
		ss,
		[Description("Left Stripe")]
		ls,
		[Description("Vertical (Left) Half")]
		vh,
		[Description("Right Stripe")]
		rs,
		[Description("Left (Top) Diagonal")]
		ld,
		[Description("Right (Top) Diagonal")]
		rd,
		[Description("Gradient")]
		gra,
		[Description("Mojang Logo")]
		moj
		// Resharper enable InconsistentNaming
	}
}