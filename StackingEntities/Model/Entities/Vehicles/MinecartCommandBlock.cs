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

		public override string DisplayImage => "/StackingEntities;component/Images/Vehicles/MinecartCommandBlock.png";

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