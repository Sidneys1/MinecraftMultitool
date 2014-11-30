using System.Text;

namespace StackingEntities.Entities.Mobs.Hostile
{
	internal class Zombie : MobBase
	{
		public Zombie() { Type = EntityTypes.Zombie; Health = 20; ConversionTime = -1; }

		#region Type

		bool _isVillager, _isBaby;
		[Property("Zombie Options", "Is Villager")]
		public bool IsVillager
		{
			get { return _isVillager; }
			set {
				_isVillager = value;
				PropChanged("IsVillager");
				PropChanged("DisplayImage");
				PropChanged("Display");
			}
		}

		[Property("Zombie Options", "Is Baby")]
		public bool IsBaby 
		{
			get { return _isBaby; }
			set
			{
				_isBaby = value;
				PropChanged("IsVillager");
				PropChanged("DisplayImage");
				PropChanged("Display");
			}
		}

		#endregion

		#region Abilities

		[Property("Zombie Options", "Can Break Doors")]
		public bool CanBreakDoors { get; set; }
		[Property("Zombie Options", "Conversion Time"), MinMax(-1, null)]
		public int ConversionTime { get; set; }

		#endregion

		#region UI

		public override string Display => base.Display + (IsBaby ? "Baby " : "") + "Zombie" + (IsVillager ? " Villager" : "");

		public override string DisplayImage
		{
			get
			{
				if (IsBaby)
				{
					return IsVillager ? "/Images/Mobs/Zombie/BabyZombieVillager.png" : "/Images/Mobs/Zombie/BabyZombie.png";
				}
				return IsVillager ? "/Images/Mobs/Zombie/ZombieVillager.png" : "/Images/Mobs/Zombie/Zombie.png";
			}
		}

		#endregion

		#region Process

		public override string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJSON(topLevel));

			if (IsVillager)
				b.Append("IsVillager:true,");

			if (IsBaby)
				b.Append("IsBaby:true,");

			if (CanBreakDoors)
				b.Append("CanBreakDoors:true,");

			if (Health != 20)
				b.Append(string.Format("HealF:{0},", Health));

			

			return b.ToString();
		}

		#endregion
	}
}