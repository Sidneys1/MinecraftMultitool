using System;
using System.Collections.ObjectModel;
using System.Text;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Items;
using StackingEntities.Model.Items.ItemTags;
using StackingEntities.Model.Metadata;
using StackingEntities.Model.Objects;
using StackingEntities.Model.SimpleTypes;
using Attribute = StackingEntities.Model.Objects.Attribute;

namespace StackingEntities.Model.Entities.Mobs
{
	[Serializable]
	public abstract class MobBase : EntityBase
	{
		protected MobBase(int baseHealth)
		{
			DefaultHealth = baseHealth;
			Health = DefaultHealth.Value;

			Holding.Tag.Add(new ItemTagsMap());
			Holding.Tag.Add(new ItemTagsGeneral());
			Holding.Tag.Add(new ItemTagsFireworkStar());
			Holding.Tag.Add(new ItemTagsDisplay());
			Holding.Tag.Add(new ItemTagsEnchantments());
			Holding.Tag.Add(new ItemTagsBook());
			Holding.Tag.Add(new ItemTagsBlock());

			Leggings.Tag.Add(new ItemTagsDisplay());
			Leggings.Tag.Add(new ItemTagsEnchantments());

			Boots.Tag.Add(new ItemTagsDisplay());
			Boots.Tag.Add(new ItemTagsEnchantments());

			Chestplate.Tag.Add(new ItemTagsDisplay());
			Chestplate.Tag.Add(new ItemTagsEnchantments());

			Helmet.Tag.Add(new ItemTagsDisplay());
			Helmet.Tag.Add(new ItemTagsEnchantments());
		}

		#region Health

		[EntityDescriptor("Mob Options", "Health"), MinMax(0, null)]
		public int Health { get; set; }

		protected int? DefaultHealth { get; set; }

		#endregion

		#region Custom Name

		string _customName = "";

		[EntityDescriptor("Mob Options", "Custom Name")]
		public string CustomName
		{
			get { return _customName; }
			set
			{
				_customName = value;
				PropChanged();
				PropChanged("Display");
			}
		}

		[EntityDescriptor("Mob Options", "CN Visible")]
		public bool CustomNameVisible { get; set; }

		#endregion

		#region Loot

		[EntityDescriptor("Mob Options", "Can Pick Up Loot")]
		public bool CanPickUpLoot { get; set; }

		#endregion

		#region Despawning

		bool _persistanceRequired;
		[EntityDescriptor("Mob Options", "Don't Despawn")]
		public bool PersistanceRequired
		{
			get { return _persistanceRequired; }
			set
			{
				_persistanceRequired = value;
				PropChanged();
				PropChanged("Display");
			}
		}

		#endregion

		#region Equiptment

		[EntityDescriptor("Equipment", "Held Item")]
		public Item Holding { get; set; } = new Item() { Id = string.Empty, SlotTitle = "Held Item" };

		[EntityDescriptor("Equipment", "Boots")]
		public Item Boots { get; set; } = new Item() { Id = string.Empty, CountTagEnabled = false, SlotTitle = "Boots" };

		[EntityDescriptor("Equipment", "Leggings")]
		public Item Leggings { get; set; } = new Item() { Id = string.Empty, CountTagEnabled = false, SlotTitle = "Leggings" };

		[EntityDescriptor("Equipment", "Chestplate")]
		public Item Chestplate { get; set; } = new Item() { Id = string.Empty, CountTagEnabled = false, SlotTitle = "Chestplate" };

		[EntityDescriptor("Equipment", "Helmet")]
		public Item Helmet { get; set; } = new Item() { Id = string.Empty, CountTagEnabled = false, SlotTitle = "Helmet" };

		[EntityDescriptor("Mob Options", "Attributes")]
		public ObservableCollection<Attribute> Attributes { get; } = new ObservableCollection<Attribute>();

		[EntityDescriptor("Mob Options", "Potion Effects")]
		public ObservableCollection<PotionEffect> PotionEffects { get; } = new ObservableCollection<PotionEffect>();

		[EntityDescriptor("Mob Options", "No AI")]
		public bool NoAi { get; set; } = false;

		[EntityDescriptor("Equipment", "Drop Chances", fixedSize: true, dgRowPath: "Name")]
		public ObservableCollection<SimpleDouble> DropChanceFloats { get; set; } = new ObservableCollection<SimpleDouble> { new SimpleDouble("Held Item"), new SimpleDouble("Boots"), new SimpleDouble("Leggings"), new SimpleDouble("Chestplate"), new SimpleDouble("Helmet") };

		#endregion

		#region UI

		public override string Display => base.Display + (!string.IsNullOrWhiteSpace(CustomName) ? "Named " : "") + (PersistanceRequired ? "Persistent " : "");

		#endregion

		#region Process

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (!string.IsNullOrWhiteSpace(CustomName))
				b.AppendFormat("CustomName:\"{0}\",", CustomName.EscapeJsonString());
			if (!string.IsNullOrWhiteSpace(CustomName) && CustomNameVisible)
				b.Append("CustomNameVisible:1b,");
			if (CanPickUpLoot)
				b.Append("CanPickUpLoot:1b,");
			if (PersistanceRequired)
				b.Append("PersistanceRequired:1b,");
			if (NoAi)
				b.Append("NoAI:1b,");

			var holding = Holding.GenerateJson(false);
			var boots = Boots.GenerateJson(false);
			var leggings = Leggings.GenerateJson(false);
			var chest = Chestplate.GenerateJson(false);
			var helm = Helmet.GenerateJson(false);

			if (holding != string.Empty)
				holding = holding.Remove(holding.Length - 1, 1);

			if (boots != string.Empty)
				boots = boots.Remove(boots.Length - 1, 1);

			if (leggings != string.Empty)
				leggings = leggings.Remove(leggings.Length - 1, 1);

			if (chest != string.Empty)
				chest = chest.Remove(chest.Length - 1, 1);

			if (helm != string.Empty)
				helm = helm.Remove(helm.Length - 1, 1);

			if (holding != string.Empty || boots != string.Empty || leggings != string.Empty || chest != string.Empty || helm != string.Empty)
				b.AppendFormat("Equipment:[0:{{{0}}},1:{{{1}}},2:{{{2}}},3:{{{3}}},4:{{{4}}}],", holding, boots, leggings, chest, helm);

			if (DefaultHealth.HasValue && Health != DefaultHealth)
				b.AppendFormat("HealF:{0}f,", Health);

			StringBuilder aBuilder;
			if (PotionEffects.Count > 0)
			{
				aBuilder = new StringBuilder();
				for (var i = 0; i < PotionEffects.Count; i++)
				{
					var attribute = PotionEffects[i];

					var generateJson = attribute.GenerateJson(false);
					if (!string.IsNullOrWhiteSpace(generateJson))
						aBuilder.AppendFormat("{0}:{{{1}}},", i, generateJson);
				}

				aBuilder.Remove(aBuilder.Length - 1, 1);

				if (aBuilder.Length > 0)
					b.AppendFormat("ActiveEffects:[{0}],", aBuilder);
			}


			if (Attributes.Count > 0)
			{
				aBuilder = new StringBuilder();
				for (var i = 0; i < Attributes.Count; i++)
				{
					var attribute = Attributes[i];

					var generateJson = attribute.GenerateJson(false);
					if (!string.IsNullOrWhiteSpace(generateJson))
						aBuilder.AppendFormat("{0}:{{{1}}},", i, generateJson);
				}

				aBuilder.Remove(aBuilder.Length - 1, 1);

				if (aBuilder.Length > 0)
					b.AppendFormat("Attributes:[{0}],", aBuilder);
			}


			if (Math.Abs(DropChanceFloats[0].Value) > 0.001 || Math.Abs(DropChanceFloats[1].Value) > 0.001 ||
				Math.Abs(DropChanceFloats[2].Value) > 0.001 || Math.Abs(DropChanceFloats[3].Value) > 0.001 ||
				Math.Abs(DropChanceFloats[4].Value) > 0.001)
			{
				b.AppendFormat("DropChances:[0:{0:0.##}f,1:{1:0.##}f,2:{2:0.##}f,3:{3:0.##}f,4:{4:0.##}f],",
					DropChanceFloats[0].Value, DropChanceFloats[1].Value, DropChanceFloats[2].Value, DropChanceFloats[3].Value,
					DropChanceFloats[4].Value);
			}

			return b.ToString();
		}

		#endregion
	}
}
