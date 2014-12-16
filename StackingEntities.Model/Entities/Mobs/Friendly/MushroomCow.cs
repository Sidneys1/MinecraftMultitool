﻿using System;
using StackingEntities.Model.Enums;

namespace StackingEntities.Model.Entities.Mobs.Friendly
{
	[Serializable]
	public class MushroomCow : BreedableMobBase
	{
		public MushroomCow() : base(10)
		{
			Type = EntityType.MushroomCow;
		}

		public override string DisplayImage => Age < 0 ? "/StackingEntities.Resources;component/Images/Mobs/MushroomCow/BabyMushroomCow.png" : "/StackingEntities.Resources;component/Images/Mobs/MushroomCow/MushroomCow.png";
	}
}
