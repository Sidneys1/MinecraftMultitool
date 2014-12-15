using System;
using System.Text;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.ItemEntities.BaseClasses
{
	[Serializable]
	internal abstract class ItemEntityBase : EntityBase
	{
		[EntityDescriptor("Item Entity Options", "Age")]
		public int Age { get; set; }

		[EntityDescriptor("Item Entity Options", "Health"), MinMax(0, 255)]
		public int Health { get; set; }

		protected ItemEntityBase()
		{
			Health = 5;
		}

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (Age != 0)
				b.AppendFormat("Age:{0},", Age);

			if (Health != 5)
				b.Append(string.Format("Health:{0},", Health));

			return b.ToString();
		}
	}
}