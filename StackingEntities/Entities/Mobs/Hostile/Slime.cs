using System.Text;

namespace StackingEntities.Entities.Mobs.Hostile
{
	public class Slime : MobBase
	{
		[Property("Slime Options", "Size"), MinMax(0, int.MaxValue)]
		public int Size { get; set; }

		public Slime()
		{
			Type = EntityTypes.Slime;
			Health = 1;
		}

		public override string DisplayImage => "/Images/Mobs/Slime/Slime.png";

		public override string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJSON(topLevel));

			var properHealth = 1;

			if (Size == 1)
				properHealth = 4;

			if (Size == 2)
				properHealth = 16;

			if (Health != properHealth)
				b.AppendFormat("HealF:{0}f,", Health);

			b.AppendFormat("Size:{0},", Size);

			return b.ToString();
		}
	}
}
