using System;
using System.Text;
using StackingEntities.Model.Enums;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.DynamicTiles
{
	[Serializable]
	internal class PrimedTNT : EntityBase
	{
		public PrimedTNT() { Type = EntityType.PrimedTnt; }

		int _fuse = 80;
		[EntityDescriptor("Primed TNT Settings", "Fuse Length (Ticks)")]
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

		public override string Display => string.Format("{0}Primed TNT\r\n{1} Fuse", base.Display, JsonTools.TicksToTime(Fuse));

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/DynamicTiles/PrimedTNT.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (Fuse != 80)
				b.Append(string.Format("Fuse:{0},", Fuse));

			return b.ToString();
		}
	}
}