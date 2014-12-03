using System.Text;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	public class Slime : MobBase
	{
		private int _size;

		[EntityDescriptor("Slime Options", "Size"), MinMax(0, int.MaxValue)]
		public int Size
		{
			get { return _size; }
			set
			{
				_size = value;
				var properHealth = 1;
				if (Size == 1)
					properHealth = 4;
				if (Size == 2)
					properHealth = 16;
				DefaultHealth = properHealth;
			}
		}

		public Slime() : base(1)
		{
			Type = EntityTypes.Slime;
			Health = 1;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Mobs/Slime/Slime.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			b.AppendFormat("Size:{0},", Size);

			return b.ToString();
		}
	}
}
