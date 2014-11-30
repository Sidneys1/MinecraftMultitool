using System.Text;

namespace StackingEntities.Entities.Other.WallEntities
{
	internal abstract class WallEntityBase : EntityBase
	{
		[Property("Wall Entity Options", "Tile X")]
		public int TileX { get; set; }

		[Property("Wall Entity Options", "Tile Y")]
		public int TileY { get; set; }

		[Property("Wall Entity Options", "Tile Z")]
		public int TileZ { get; set; }

		[Property("Wall Entity Options", "Direction")]
		public Direction Direction { get; set; }

		public override string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJSON(topLevel));

			b.Append(string.Format("TileX:{0},", TileX));
			b.Append(string.Format("TileY:{0},", TileY));
			b.Append(string.Format("TileZ:{0},", TileZ));

			if(Direction != Direction.South)
				b.Append(string.Format("Direction:{0},", (int)Direction));

			return b.ToString();
		}

	}
}