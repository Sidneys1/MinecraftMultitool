using System.Text;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	public class Ghast : MobBase
	{
		[EntityDescriptor("Ghast Options", "Explosion Power"), MinMax(0, int.MaxValue)]
		public int ExplosionPower { get; set; } = 1;

		public Ghast() : base(10)
		{
			Type = EntityTypes.Ghast;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Mobs/Ghast/Ghast.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (ExplosionPower != 1)
				b.AppendFormat("ExplosionPower:{0},", ExplosionPower);

			return b.ToString();
		}
	}
}
