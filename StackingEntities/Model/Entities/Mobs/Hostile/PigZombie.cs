﻿using System.Text;
using StackingEntities.ViewModel;

namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	public class PigZombie : Zombie
	{
		[Property("Zombie Pigman Options", "Ticks Until Neutral"), MinMax(short.MinValue, short.MaxValue)]
		public int Anger { get; set; } = 0;

		public PigZombie()
		{
			Type = EntityTypes.PigZombie;
			Health = 20;
		}

		public override string Display => base.Display +" Pigman";
        public override string DisplayImage =>"/Images/Mobs/PigZombie/PigZombie.png";

		public override string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJSON(topLevel));

			if (Health != 20)
				b.AppendFormat("HealF:{0}f,", Health);

			if (Anger != 0)
				b.AppendFormat("Anger:{0},", Anger);

			return b.ToString();
		}
	}
}
