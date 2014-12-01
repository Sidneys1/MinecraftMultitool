using System.Text;
using StackingEntities.ViewModel;

namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	public class Zombie : MobBase
	{
		public Zombie() { Type = EntityTypes.Zombie; Health = 20; }

		#region Type

		bool _isVillager, _isBaby;
		[Property("Zombie Options", "Is Villager")]
		public bool IsVillager
		{
			get { return _isVillager; }
			set {
				_isVillager = value;
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
				PropChanged("DisplayImage");
				PropChanged("Display");
			}
		}

		#endregion

		#region Abilities

		[Property("Zombie Options", "Can Break Doors")]
		public bool CanBreakDoors { get; set; }

		[Property("Zombie Options", "Conversion Time"), MinMax(-1, int.MaxValue)]
		public int ConversionTime { get; set; } = -1;

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
				b.Append("IsVillager:1b,");

			if (IsBaby)
				b.Append("IsBaby:1b,");

			if (CanBreakDoors)
				b.Append("CanBreakDoors:1b,");

			if (Health != 20)
				b.AppendFormat("HealF:{0},", Health);

			if (ConversionTime != -1)
				b.AppendFormat("ConversionTime:{0},", ConversionTime);

			return b.ToString();
		}

		#endregion
	}
}