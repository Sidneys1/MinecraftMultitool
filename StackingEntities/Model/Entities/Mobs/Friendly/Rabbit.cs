using System.ComponentModel;
using System.Text;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Mobs.Friendly
{
	public class Rabbit :BreedableMobBase
	{
		private RabbitTypes _rabbitType = RabbitTypes.DontCare;
		[EntityDescriptor("Rabbit Options", "Rabbit Type")]
		public RabbitTypes RabbitType
		{
			get { return _rabbitType; }
			set { _rabbitType = value; PropChanged("Display"); }
		}

		public Rabbit()
		{
			Type = EntityTypes.Rabbit;
			Health = 10;
		}

		public override string Display => base.Display + RabbitType.Description() + " Rabbit";

		public override string DisplayImage => "/StackingEntities;component/Images/Mobs/Rabbit/Rabbit.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (RabbitType != RabbitTypes.DontCare)
				b.AppendFormat("RabbitType:{0:D},", RabbitType);

			return b.ToString();
		}
	}

	public enum RabbitTypes
	{
		[Description("Any")]
		DontCare = -1,
		Brown,
		White,
		Black,
		[Description("Black & White")]
		BlackWhite,
		Gold,
		[Description("Salt & Pepper")]
		SaltPepper,
		[Description("Killer Bunny")]
		KillerBunny = 99
	}

}
