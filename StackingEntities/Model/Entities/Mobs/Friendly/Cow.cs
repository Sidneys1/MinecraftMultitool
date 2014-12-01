using System.Text;

namespace StackingEntities.Model.Entities.Mobs.Friendly
{
	public class Cow :BreedableMobBase
	{
		public Cow()
		{
			Type = EntityTypes.Cow;
			Health = 10;
		}
		public override string DisplayImage => (Age < 0) ? "/StackingEntities;component/Images/Mobs/Cow/BabyCow.png" : "/StackingEntities;component/Images/Mobs/Cow/Cow.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (Health != 10)
				b.AppendFormat("HealF:{0:00}f,", Health);

			return b.ToString();
		}
	}
}
