using System;
using System.ComponentModel;
using System.Text;
using StackingEntities.Model.BlockEntities.BaseClasses;
using StackingEntities.Model.Items;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.BlockEntities
{
	[Serializable]
	public class RecordPlayer : BlockEntityBase
	{
		#region Properties

		[EntityDescriptor("Jukebox Options", "Record")]
		public Record Record { get; set; } = Record.Inherit;

		[EntityDescriptor("Jukebox Options", "Record Item", wide:true)]
		public Item RecordItem { get; } = new Item {SlotTitle = "Record Item"};

		#endregion

		#region Inherited

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(false));

			if (Record != Record.Inherit)
				b.AppendFormat("Record:{0:D},", Record);

			var s = RecordItem.GenerateJson(false);

			if (string.IsNullOrWhiteSpace(s)) return b.ToString();

			if (s.EndsWith(","))
				s = s.Remove(s.Length - 1, 1);
			b.AppendFormat("RecordItem:{{{0}}},", s);

			return b.ToString();
		}

		#endregion
	}

	public enum Record
	{
		Inherit = -1,
		[Description("13")]
		Thirteen = 2256,
		Cat,
		Blocks,
		Chirp,
		Far,
		Mall,
		Mellohi,
		Stal,
		Strad,
		Ward,
		[Description("11")]
		Eleven,
		Wait
	}
}
