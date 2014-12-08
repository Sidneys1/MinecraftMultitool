using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Items;
using StackingEntities.Model.Items.ItemTags;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Mobs.Friendly
{
	public class EntityHorse : BreedableMobBase
	{
		private HorseType _horseType;
		private bool _tame;
		private bool _allowVariant;
		private bool _chestedHorse;

		[EntityDescriptor("Horse Options", "Horse Type")]
		public HorseType HorseType
		{
			get { return _horseType; }
			set { _horseType = value; PropChanged("DisplayImage"); PropChanged("Display"); PropChanged("VariantEnabled"); PropChanged("IsHorse"); PropChanged("IsNotHorse"); }
		}
		[EntityDescriptor("Horse Options", "Tamed")]
		public bool Tame
		{
			get { return _tame; }
			set { _tame = value; PropChanged("Display"); }
		}

		[EntityDescriptor("Horse Options", "Temper", "0-100. Makes the Horse easier to tame."), MinMax(0, 100)]
		public int Temper { get; set; }

		public bool VariantEnabled => AllowVariant && IsHorse;
		public bool IsHorse => (HorseType != HorseType.Donkey && HorseType != HorseType.Mule);
		public bool IsNotHorse => (HorseType == HorseType.Donkey || HorseType == HorseType.Mule);

		[EntityDescriptor("Horse Options", "Use Colors/Markings", isEnabledPath: "IsHorse")]
		public bool AllowVariant
		{
			get { return _allowVariant; }
			set { _allowVariant = value; PropChanged("VariantEnabled"); }
		}

		[EntityDescriptor("Horse Options", "Color", isEnabledPath: "VariantEnabled")]
		public HorseColors Color { get; set; }
		[EntityDescriptor("Horse Options", "Markings", isEnabledPath: "VariantEnabled")]
		public HorseMarkings Markings { get; set; }

		[EntityDescriptor("Horse Options", "Has Saddle")]
		public bool Saddle { get; set; }

		[EntityDescriptor("Horse Options", "Armor Item", isEnabledPath: "IsHorse")]
		public Item ArmorItem { get; } = new Item(false) { CountTagEnabled = false, Slot = null, DamageTagEnabled = false, SlotTitle = "Armor Item" };

		[EntityDescriptor("Horse Options", "Has Chests", isEnabledPath: "IsNotHorse")]
		public bool ChestedHorse
		{
			get { return _chestedHorse; }
			set { _chestedHorse = value; PropChanged(); }
		}

		[EntityDescriptor("Horse Options", "Inventory", isEnabledPath: "ChestedHorse", fixedSize: true), MinMax(5, 3)]
		public ObservableCollection<Item> Inventory { get; } = new ObservableCollection<Item>();

		public EntityHorse() : base(30)
		{
			Type = EntityTypes.EntityHorse;

			for (var i = 2; i <= 16; i++)
			{
				Inventory.Add(new Item { Slot = i, SlotTagEnabled = false });
			}

			ArmorItem.Tag.Add(new ItemTagsGeneral());
			ArmorItem.Tag.Add(new ItemTagsDisplay());
		}

		public override string Display
			=>
				string.Format("{0}{1}{2}", base.Display, Tame ? "Tamed " : string.Empty,
					HorseType == HorseType.Default ? "Horse" : HorseType.Description());

		public override string DisplayImage
		{
			get
			{
				var pre = string.Empty;

				if (Age < 0)
					pre = "Baby";

				var post = _horseType == HorseType.Default ? "Horse" : _horseType.ToString();

				return string.Format("/StackingEntities.Resources;component/Images/Mobs/Horse/{0}{1}.png", pre, post);
			}
		}

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (Tame)
				b.Append("Tame:1b,");

			if (Saddle)
				b.Append("Saddle:1b,");

			if (Temper != 0)
				b.AppendFormat("Temper:{0},", Temper);

			if (HorseType != HorseType.Default)
				b.AppendFormat("Type:{0:D},", HorseType);

			if (VariantEnabled)
				b.AppendFormat("Variant:{0},", ((int)Color) | (((int)Markings) << 8));

			if (IsHorse && ArmorItem.HasId)
				b.AppendFormat("ArmorItem:{{{0}}},", ArmorItem.GenerateJson(false));

			if (!IsHorse && ChestedHorse)
				b.Append("ChestedHorse:1b,");

			if (!IsHorse && ChestedHorse && Inventory.Count > 0)
				b.Append(JsonTools.GenItems(Inventory));

			return b.ToString();
		}
	}

	public enum HorseType
	{
		Default,
		Horse,
		Donkey,
		Mule,
		[Description("Undead Horse")]
		UndeadHorse,
		[Description("Skeleton Horse")]
		SkeletonHorse
	}

	public enum HorseColors
	{
		White,
		Buckskin,
		[Description("Dark Bay")]
		DarkBay,
		Bay,
		Black,
		[Description("Dapple Gray")]
		DappleGray,
		[Description("Flaxen Chestnut")]
		FlaxenChestnut
	}

	public enum HorseMarkings
	{
		None,
		[Description("Stockings & Blaze")]
		StockingsAndBlaze,
		[Description("Snowflake Appaloosa")]
		SnowflakeAppaloosa,
		Paint,
		Sooty
	}
}
