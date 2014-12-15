using System.ComponentModel;

namespace StackingEntities.Model.Enums
{
	public enum VillagerCareer
	{
		Default=0,
		Farmer = 1,
		Fisherman = 2,
		Shepherd = 3,
		Fletcher = 4,
		Librarian = 1,
		Cleric = 1,
		Armorer = 1,
		[Description("Weapon Smith")]
		WeaponSmith = 2,
		[Description("Tool Smith")]
		ToolSmith = 3,
		Butcher = 1,
		Leatherworker = 2
	}
}