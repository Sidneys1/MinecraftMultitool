using System.Text;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	public class Zombie : MobBase
	{
		public Zombie() : base(20) { Type = EntityTypes.Zombie; }

		#region Type

		bool _isVillager, _isBaby;
		[EntityDescriptor("Zombie Options", "Is Villager")]
		public bool IsVillager
		{
			get { return _isVillager; }
			set {
				_isVillager = value;
				PropChanged("DisplayImage");
				PropChanged("Display");
			}
		}

		[EntityDescriptor("Zombie Options", "Is Baby")]
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

		[EntityDescriptor("Zombie Options", "Can Break Doors")]
		public bool CanBreakDoors { get; set; }

		[EntityDescriptor("Zombie Options", "Conversion Time"), MinMax(-1, int.MaxValue)]
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
					return IsVillager ? "/StackingEntities.Resources;component/Images/Mobs/Zombie/BabyZombieVillager.png" : "/StackingEntities.Resources;component/Images/Mobs/Zombie/BabyZombie.png";
				}
				return IsVillager ? "/StackingEntities.Resources;component/Images/Mobs/Zombie/ZombieVillager.png" : "/StackingEntities.Resources;component/Images/Mobs/Zombie/Zombie.png";
			}
		}

		#endregion

		#region Process

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (IsVillager)
				b.Append("IsVillager:1b,");

			if (IsBaby)
				b.Append("IsBaby:1b,");

			if (CanBreakDoors)
				b.Append("CanBreakDoors:1b,");

			if (ConversionTime != -1)
				b.AppendFormat("ConversionTime:{0},", ConversionTime);

			return b.ToString();
		}

		#endregion
	}
}