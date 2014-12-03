using System.ComponentModel;
using System.Text;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Mobs.Friendly
{
	public class Villager : MobBase
	{
		// TODO Inventory

		// TODO Trades

		[EntityDescriptor("Villager Options", "Willing", "Whether or not the Villager is willing to breed.")]
		public bool Willing { get; set; } = false;

		[EntityDescriptor("Villager Options", "Level", "What trading level is unlocked."), MinMax(0, int.MaxValue)]
		public int CareerLevel { get; set; }

		[EntityDescriptor("Villager Options", "Profession")]
		public VillagerProfession Profession { get; set; } = VillagerProfession.Default;

		[EntityDescriptor("Villager Options", "Career")]
		public VillagerCareer Career { get; set; } = VillagerCareer.Default;

		public Villager() : base(20)
		{
			Type = EntityTypes.Villager;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Mobs/Villager/Villager.png";

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (Willing)
				b.Append("Willing:1b,");

			if (CareerLevel != 0)
				b.AppendFormat("CareerLevel:{0},", CareerLevel);

			if (Profession != VillagerProfession.Default)
				b.AppendFormat("Profession:{0:D},", Profession);

			if (Career != VillagerCareer.Default)
				b.AppendFormat("Career:{0:D},", Career);

			return b.ToString();

		}
	}

	public enum VillagerProfession
	{
		Default = -1,
		Farmer,
		Librarian,
		Priest,
		Blacksmith,
		Butcher
	}

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
