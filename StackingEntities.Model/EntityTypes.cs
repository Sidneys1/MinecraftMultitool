using System.ComponentModel;
using StackingEntities.Model.Entities.DynamicTiles;
using StackingEntities.Model.Entities.ItemEntities;
using StackingEntities.Model.Entities.Mobs.Friendly;
using StackingEntities.Model.Entities.Mobs.Hostile;
using StackingEntities.Model.Entities.Other;
using StackingEntities.Model.Entities.Other.WallEntities;
using StackingEntities.Model.Entities.Projectiles;
using StackingEntities.Model.Entities.Vehicles;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model
{
	public enum EntityTypes
	{
		[Description("Choose an Entity...")]
		NoEnt = 0x0,
		[Description("Armor Stand"), ClassLink(typeof(ArmorStand))]
		ArmorStand,
		[ClassLink(typeof(Arrow))]
		Arrow,
		[ClassLink(typeof(Bat))]
		Bat,
		[ClassLink(typeof(Blaze))]
        Blaze,
		[ClassLink(typeof(Boat))]
		Boat,
		[Description("Cave Spider"), ClassLink(typeof(CaveSpider))]
		CaveSpider,
		[ClassLink(typeof(Chicken))]
		Chicken,
		[ClassLink(typeof(Cow))]
		Cow,
		[ClassLink(typeof(Creeper))]
		Creeper,
		[Description("Ender Crystal"), ClassLink(typeof(EnderCrystal))]
		EnderCrystal,
		[Description("Ender Dragon"), ClassLink(typeof(EnderDragon))]
		EnderDragon,
		[ClassLink(typeof(Enderman))]
		Enderman,
		[Description("Endermite"), ClassLink(typeof(Endermite))]
		Endermite,
		[Description("Horse"), ClassLink(typeof(EntityHorse))]
		EntityHorse,
		[Description("Thrown Eye of Ender"), ClassLink(typeof(EyeOfEnder))]
		EyeOfEnderSignal,
		[Description("Falling Sand"), ClassLink(typeof(FallingSand))]
		FallingSand,
		[ClassLink(typeof(Fireball))]
		Fireball,
		[Description("Firework Rocket"), ClassLink(typeof(FireworkRocketEntity))]
		FireworksRocketEntity,
		[ClassLink(typeof(Ghast))]
		Ghast,
		[ClassLink(typeof(Giant))]
		Giant,
		[ClassLink(typeof(Guardian))]
		Guardian,
		[ClassLink(typeof(DroppedItem))]
		Item,
		[Description("Item Frame"), ClassLink(typeof(ItemFrame))]
		ItemFrame,
		[Description("Magma Cube"), ClassLink(typeof(LavaSlime))]
		LavaSlime,
		[Description("Lead Fence Knot"), ClassLink(typeof(LeashKnot))]
		LeashKnot,
		[Description("Minecart Chest"), ClassLink(typeof(MinecartChest))]
		MinecartChest,
		[Description("Command Block Minecart"), ClassLink(typeof(MinecartCommandBlock))]
		MinecartCommandBlock,
		[Description("Furnace Minecart"), ClassLink(typeof(MinecartFurnace))]
		MinecartFurnace,
		[Description("Minecart Hopper"), ClassLink(typeof(MinecartHopper))]
		MinecartHopper,
		[ClassLink(typeof(Minecart))]
		Minecart,
		[Description("Spawner Minecart"), ClassLink(typeof(MinecartSpawner))]
		MinecartSpawner,
		// ReSharper disable once InconsistentNaming
		[Description("TNT Minecart"), ClassLink(typeof(MinecartTNT))]
		MinecartTNT,
		[Description("Mooshroom"), ClassLink(typeof(MushroomCow))]
		MushroomCow,
		[Description("Ocelot / Cat"), ClassLink(typeof(Ozelot))]
		Ozelot,
		[ClassLink(typeof(Painting))]
		Painting,
		[ClassLink(typeof(Pig))]
		Pig,
		[Description("Zombie Pigman"), ClassLink(typeof(PigZombie))]
		PigZombie,
		[Description("Primed TNT"), ClassLink(typeof(PrimedTNT))]
		PrimedTnt,
		[ClassLink(typeof(Rabbit))]
		Rabbit,
		[ClassLink(typeof(Sheep))]
		Sheep,
		[ClassLink(typeof(Silverfish))]
		Silverfish,
		[Description("Skeleton / Wither Skeleton"), ClassLink(typeof(Skeleton))]
		Skeleton,
		[ClassLink(typeof(Slime))]
		Slime,
		[Description("Fire Charge"), ClassLink(typeof(SmallFireball))]
		SmallFireball,
		[ClassLink(typeof(Snowball))]
		Snowball,
		[Description("Snow Golem"), ClassLink(typeof(SnowMan))]
		SnowMan,
		[ClassLink(typeof(Spider))]
		Spider,
		[ClassLink(typeof(Squid))]
		Squid,
		[Description("Thrown Ender Pearl"), ClassLink(typeof(ThrownEnderPearl))]
		ThrownEnderpearl,
		[Description("Bottle o' Enchanting"), ClassLink(typeof(ThrownExpBottle))]
		ThrownExpBottle,
		[Description("Thrown Potion"), ClassLink(typeof(ThrownPotion))]
		ThrownPotion,
		[ClassLink(typeof(Villager))]
		Villager,
		[Description("Iron Golem"), ClassLink(typeof(VillagerGolem))]
		VillagerGolem,
		[ClassLink(typeof(Witch))]
		Witch,
		[Description("The Wither"), ClassLink(typeof(WitherBoss))]
		WitherBoss,
		[Description("Wither Skull (Projectile)"), ClassLink(typeof(WitherSkull))]
		WitherSkull,
		[ClassLink(typeof(Wolf))]
		Wolf,
		[Description("Experience Orb"), ClassLink(typeof(XpOrb))]
		XPOrb,
		[ClassLink(typeof(Zombie))]
		Zombie
	}
}