using System;
using System.Text;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Projectiles.BaseClasses
{
	[Serializable]
	public abstract class ProjectileBase : EntityBase
	{
		[EntityDescriptor("Projectile Options", "X Coordinate in Chunk"), MinMax(0, ushort.MaxValue)]
		public int XTile { get; set; }

		[EntityDescriptor("Projectile Options", "Y Coordinate in Chunk"), MinMax(0, ushort.MaxValue)]
		public int YTile { get; set; }

		[EntityDescriptor("Projectile Options", "Z Coordinate in Chunk"), MinMax(0, ushort.MaxValue)]
		public int ZTile { get; set; }

		[EntityDescriptor("Projectile Options", "ID Of Block Landed On")]
		public string InTile { get; set; }

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (XTile != 0)
				b.AppendFormat("xTile:{0}s,", XTile);

			if (YTile != 0)
				b.AppendFormat("yTile:{0}s,", YTile);

			if (ZTile != 0)
				b.AppendFormat("zTile:{0}s,", ZTile);

			if (!string.IsNullOrWhiteSpace(InTile))
				b.AppendFormat("inTile:\"{0}\",", InTile.EscapeJsonString());

			return b.ToString();
		}
	}
}