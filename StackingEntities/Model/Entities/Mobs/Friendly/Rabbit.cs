﻿using System.ComponentModel;
using System.Text;
using StackingEntities.ViewModel;

namespace StackingEntities.Model.Entities.Mobs.Friendly
{
	public class Rabbit :BreedableMobBase
	{
		private RabbitTypes _rabbitType = RabbitTypes.DontCare;
		[Property("Rabbit Options", "Rabbit Type")]
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

		public override string DisplayImage => "/Images/Mobs/Rabbit/Rabbit.png";

		public override string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJSON(topLevel));

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
