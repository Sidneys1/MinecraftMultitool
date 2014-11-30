using System.Text;

namespace StackingEntities.Entities.DynamicTiles
{
	internal class PrimedTNT : EntityBase
	{
		public PrimedTNT() { Type = EntityTypes.PrimedTnt; }

		int _fuse = 80;
		[Property("Primed TNT Settings", "Fuse Length (Ticks)")]
		public int Fuse
		{
			get { return _fuse; }
			set
			{
				_fuse = value;
				PropChanged();
				PropChanged("Display");
			}
		}

		public override string Display => string.Format("Primed TNT\r\n{0} Fuse", (Fuse >= 20) ? (Fuse / 20f).ToString("0.##") + " Second" : Fuse + " Tick");

		public override string DisplayImage => "Images/DynamicTiles/PrimedTNT.png";

		public override string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJSON(topLevel));

			if (Fuse != 80)
				b.Append(string.Format("Fuse:{0},", Fuse));

			return b.ToString();
		}
	}
}