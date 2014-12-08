using System.Text;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Vehicles
{
	internal class MinecartTNT : Minecart
	{
		public MinecartTNT() { Type = EntityTypes.MinecartTNT; }

		int _tntFuse = -1;
		[EntityDescriptor("Minecart TNT Options", "Fuse Ticks (-1 = Inactive)"), MinMax(-1, null)]
		// ReSharper disable once InconsistentNaming
		public int TNTFuse
		{
			get { return _tntFuse; }

			set
			{
				_tntFuse = value;
				PropChanged();
				PropChanged("Display");
			}
		}

		public override string Display => string.Format("Minecart TNT\r\n{0}", (_tntFuse == -1 ? "Inactive" : (_tntFuse >= 20 ? (_tntFuse / 20f) + " Seconds of Fuse" : _tntFuse + " Ticks of Fuse")));

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Vehicles/MinecartTNT.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (TNTFuse != -1)
				b.Append(string.Format("TNTFuse:{0},", TNTFuse));

			return b.ToString();
		}
	}
}