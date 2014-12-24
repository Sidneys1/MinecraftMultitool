using System;
using System.Text;
using StackingEntities.Model.BlockEntities.BaseClasses;
using StackingEntities.Model.Enums;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.BlockEntities
{
	[Serializable]
	public class Music : BlockEntityBase
	{
		#region Properties

		[EntityDescriptor("Note Block Options", "Note")]
		public Note Note { get; set; } = Note.Inherit;

		#endregion

		#region Inherited

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(false));

			if (Note != Note.Inherit)
				b.AppendFormat("note:{0:D}b,", Note);

			return b.ToString();

		}

		#endregion
	}
}
