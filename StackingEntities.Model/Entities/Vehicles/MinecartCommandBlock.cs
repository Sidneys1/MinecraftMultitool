using System;
using System.Text;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Vehicles
{
	[Serializable]
	public class MinecartCommandBlock : Minecart
	{
		public MinecartCommandBlock() { Type = EntityTypes.MinecartCommandBlock; }

		[EntityDescriptor("Minecart Command Block Options", "Command")]
		public string Command { get; set; }

		#region UI

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Vehicles/MinecartCommandBlock.png";

		#endregion

		#region Process

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (!string.IsNullOrWhiteSpace(Command))
				b.Append(string.Format("Command:\"{0}\",", Command));

			return b.ToString();
		}

		#endregion
	}
}