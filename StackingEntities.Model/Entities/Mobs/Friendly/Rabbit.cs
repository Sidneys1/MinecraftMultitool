using System;
using System.Text;
using StackingEntities.Model.Enums;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Mobs.Friendly
{
	[Serializable]
	public class Rabbit :BreedableMobBase
	{
		private RabbitTypes _rabbitType = RabbitTypes.DontCare;
		[EntityDescriptor("Rabbit Options", "Rabbit Type")]
		public RabbitTypes RabbitType
		{
			get { return _rabbitType; }
			set { _rabbitType = value; PropChanged("Display"); }
		}

		public Rabbit() : base(10)
		{
			Type = EntityType.Rabbit;
		}

		public override string Display => base.Display + RabbitType.Description() + " Rabbit";

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Mobs/Rabbit/Rabbit.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (RabbitType != RabbitTypes.DontCare)
				b.AppendFormat("RabbitType:{0:D},", RabbitType);

			return b.ToString();
		}
	}
}
