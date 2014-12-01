using System;
using System.Collections.Generic;
using System.Text;
using StackingEntities.Items;
using StackingEntities.Items.ItemTags;

namespace StackingEntities.Entities.Mobs
{
	public abstract class MobBase : EntityBase
	{
		protected MobBase()
		{
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

		[Property("Mob Options", "Health"), MinMax(0, null)]
		public int Health { get; set; }

		#endregion

		#region Custom Name

		string _customName = "";

		[Property("Mob Options", "Custom Name")]
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

		[Property("Mob Options", "CN Visible")]
		public bool CustomNameVisible { get; set; }

		#endregion

		//[Property("Mob Options", "Effects")]
		//public list<Effect> Effects

		#region Loot

		[Property("Mob Options", "Can Pick Up Loot")]
		public bool CanPickUpLoot { get; set; }

		//public list<Item> Equipment
		//public float[] DropChances = {1f, 1f, 1f, 1f, 1f};

		#endregion

		#region Despawning

		bool _persistanceRequired;
		[Property("Mob Options", "Don't Despawn")]
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

		[Property("Equipment", "Held Item")]
		public Item Holding { get; set; } = new Item() { Id = string.Empty };

		[Property("Equipment", "Boots")]
		public Item Boots { get; set; } = new Item() { Id = string.Empty, CountTagEnabled = false };

		[Property("Equipment", "Leggings")]
		public Item Leggings { get; set; } = new Item() { Id = string.Empty, CountTagEnabled = false };

		[Property("Equipment", "Chestplate")]
		public Item Chestplate { get; set; } = new Item() { Id = string.Empty, CountTagEnabled = false };

		[Property("Equipment", "Helmet")]
		public Item Helmet { get; set; } = new Item() { Id = string.Empty, CountTagEnabled = false };

		[Property("Mob Options", "Attributes")]
		public List<Attribute> Attributes { get; } = new List<Attribute>();

		[Property("Mob Options", "Potion Effects")]
		public List<PotionEffect> PotionEffects { get; } = new List<PotionEffect>();

		[Property("Mob Options", "No AI")]
		public bool NoAi { get; set; } = false;

		[Property("Equipment", "Drop Chances", fixedSize: true, dgRowPath: "Name")]
		public List<SimpleDouble> DropChanceFloats { get; set; } = new List<SimpleDouble> { new SimpleDouble("Held Item"), new SimpleDouble("Boots"), new SimpleDouble("Leggings"), new SimpleDouble("Chestplate"), new SimpleDouble("Helmet") };

		#endregion

		#region UI

		public override string Display => base.Display + (!string.IsNullOrWhiteSpace(CustomName) ? "Named " : "") + (PersistanceRequired ? "Persistent " : "");

		#endregion

		#region Process

		public override string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJSON(topLevel));

			if (!string.IsNullOrWhiteSpace(CustomName))
				b.AppendFormat("CustomName:\"{0}\",", JsonTools.EscapeStringValue(CustomName));
			if (!string.IsNullOrWhiteSpace(CustomName) && CustomNameVisible)
				b.Append("CustomNameVisible:1b,");
			if (CanPickUpLoot)
				b.Append("CanPickUpLoot:1b,");
			if (PersistanceRequired)
				b.Append("PersistanceRequired:1b,");
			if (NoAi)
				b.Append("NoAI:1b,");

			var holding = Holding.GenerateJSON(false);
			var boots = Boots.GenerateJSON(false);
			var leggings = Leggings.GenerateJSON(false);
			var chest = Chestplate.GenerateJSON(false);
			var helm = Helmet.GenerateJSON(false);

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

			StringBuilder aBuilder;
			if (PotionEffects.Count > 0)
			{
				aBuilder = new StringBuilder();
				for (var i = 0; i < PotionEffects.Count; i++)
				{
					var attribute = PotionEffects[i];

					var generateJson = attribute.GenerateJSON(false);
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

					var generateJson = attribute.GenerateJSON(false);
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
