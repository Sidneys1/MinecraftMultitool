using System.Text;
using StackingEntities.ViewModel;

namespace StackingEntities.Model.Entities.Vehicles
{
	internal class MinecartCommandBlock : Minecart
	{
		public MinecartCommandBlock() { Type = EntityTypes.MinecartCommandBlock; }

		[Property("Minecart Command Block Options", "Command")]
		public string Command { get; set; }

		#region UI

		public override string DisplayImage => "/Images/Vehicles/MinecartCommandBlock.png";

		#endregion

		#region Process

		public override string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJSON(topLevel));

			if (!string.IsNullOrWhiteSpace(Command))
				b.Append(string.Format("Command:\"{0}\",", Command));

			return b.ToString();
		}

		#endregion
	}
}