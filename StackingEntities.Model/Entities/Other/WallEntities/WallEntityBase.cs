using System;
using System.Text;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Other.WallEntities
{
	[Serializable]
	internal abstract class WallEntityBase : EntityBase
	{
		[EntityDescriptor("Wall Entity Options", "Tile X")]
		public int TileX { get; set; }

		[EntityDescriptor("Wall Entity Options", "Tile Y")]
		public int TileY { get; set; }

		[EntityDescriptor("Wall Entity Options", "Tile Z")]
		public int TileZ { get; set; }

		[EntityDescriptor("Wall Entity Options", "Direction")]
		public Direction Direction { get; set; }

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			b.Append(string.Format("TileX:{0},", TileX));
			b.Append(string.Format("TileY:{0},", TileY));
			b.Append(string.Format("TileZ:{0},", TileZ));

			if(Direction != Direction.South)
				b.Append(string.Format("Direction:{0},", (int)Direction));

			return b.ToString();
		}

	}
}