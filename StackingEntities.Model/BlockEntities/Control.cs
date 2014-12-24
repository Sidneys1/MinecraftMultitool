using System;
using System.Text;
using StackingEntities.Model.BlockEntities.BaseClasses;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.BlockEntities
{
	[Serializable]
	public class Control : NamedContainerBase
	{
		#region Properties

		[EntityDescriptor("Command Block Options", "Command")]
		public string Command { get; set; }
		[EntityDescriptor("Command Block Options", "Track Output")]
		public bool? TrackOutput { get; set; }
		[EntityDescriptor("Command Block Options", "Last Output")]
		public string LastOutput { get; set; }
		

		#endregion

		#region Inherited

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(false));

			if (!string.IsNullOrWhiteSpace(Command))
				b.AppendFormat("Command:\"{0}\",", Command.EscapeJsonString());

			if (!string.IsNullOrWhiteSpace(LastOutput))
				b.AppendFormat("LastOutput:\"{0}\",", LastOutput.EscapeJsonString());

			if (TrackOutput.HasValue)
				b.AppendFormat("TrackOutput:{0}b,", TrackOutput.Value ? 1 : 0);

			return b.ToString();

		}

		#endregion

	}
}
