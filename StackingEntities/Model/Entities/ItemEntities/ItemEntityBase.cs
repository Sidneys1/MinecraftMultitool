using System.Text;
using StackingEntities.ViewModel;

namespace StackingEntities.Model.Entities.ItemEntities
{
	internal abstract class ItemEntityBase : EntityBase
	{
		[Property("Item Entity Options", "Age")]
		public int Age { get; set; }

		[Property("Item Entity Options", "Health"), MinMax(0, 255)]
		public int Health { get; set; }

		protected ItemEntityBase()
		{
			Health = 5;
		}

		public override string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJSON(topLevel));

			if (Age != 0)
				b.AppendFormat("Age:{0},", Age);

			if (Health != 5)
				b.Append(string.Format("Health:{0},", Health));

			return b.ToString();
		}
	}
}