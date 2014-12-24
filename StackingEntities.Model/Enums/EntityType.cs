using System.ComponentModel;
using StackingEntities.Model.Entities.DynamicTiles;
using StackingEntities.Model.Entities.ItemEntities;
using StackingEntities.Model.Entities.Mobs;
using StackingEntities.Model.Entities.Mobs.Friendly;
using StackingEntities.Model.Entities.Mobs.Hostile;
using StackingEntities.Model.Entities.Other;
using StackingEntities.Model.Entities.Other.WallEntities;
using StackingEntities.Model.Entities.Projectiles;
using StackingEntities.Model.Entities.Vehicles;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Enums
{
	public enum EntityType
	{
		// ReSharper disable InconsistentNaming
		[Description("Choose an Entity...")]
		NoEnt = 0x0,
		[Description("Armor Stand"), ClassLink(typeof(ArmorStand))]
		ArmorStand = 30,
		[ClassLink(typeof(Arrow))]
		Arrow = 10,
		[ClassLink(typeof(Bat))]
		Bat = 65,
		[ClassLink(typeof(Blaze))]
        Blaze = 61,
		[ClassLink(typeof(Boat))]
		Boat = 41,
		[Description("Cave Spider"), ClassLink(typeof(CaveSpider))]
		CaveSpider = 59,
		[ClassLink(typeof(Chicken))]
		Chicken = 93,
		[ClassLink(typeof(Cow))]
		Cow = 92,
		[ClassLink(typeof(Creeper))]
		Creeper = 50,
		[Description("Ender Crystal"), ClassLink(typeof(EnderCrystal))]
		EnderCrystal = 200,
		[Description("Ender Dragon"), ClassLink(typeof(EnderDragon))]
		EnderDragon = 63,
		[ClassLink(typeof(Enderman))]
		Enderman = 58,
		[Description("Endermite"), ClassLink(typeof(Endermite))]
		Endermite = 67,
		[Description("Horse"), ClassLink(typeof(EntityHorse))]
		EntityHorse = 100,
		[Description("Thrown Eye of Ender"), ClassLink(typeof(EyeOfEnder))]
		EyeOfEnderSignal = 15,
		[Description("Falling Sand"), ClassLink(typeof(FallingSand))]
		FallingSand = 21,
		[ClassLink(typeof(Fireball))]
		Fireball = 12,
		[Description("Firework Rocket"), ClassLink(typeof(FireworkRocketEntity))]
		FireworksRocketEntity = 22,
		[ClassLink(typeof(Ghast))]
		Ghast = 56,
		[ClassLink(typeof(Giant))]
		Giant = 53,
		[ClassLink(typeof(Guardian))]
		Guardian = 68,
		[ClassLink(typeof(DroppedItem))]
		Item = 1,
		[Description("Item Frame"), ClassLink(typeof(ItemFrame))]
		ItemFrame = 18,
		[Description("Magma Cube"), ClassLink(typeof(LavaSlime))]
		LavaSlime = 62,
		[Description("Lead Fence Knot"), ClassLink(typeof(LeashKnot))]
		LeashKnot = 8,
		[Description("Minecart Chest"), ClassLink(typeof(MinecartChest))]
		MinecartChest = 43,
		[Description("Command Block Minecart"), ClassLink(typeof(MinecartCommandBlock))]
		MinecartCommandBlock = 40,
		[Description("Furnace Minecart"), ClassLink(typeof(MinecartFurnace))]
		MinecartFurnace = 44,
		[Description("Minecart Hopper"), ClassLink(typeof(MinecartHopper))]
		MinecartHopper = 46,
		[ClassLink(typeof(Minecart))]
		Minecart = 42,
		[Description("Spawner Minecart"), ClassLink(typeof(MinecartSpawner))]
		MinecartSpawner = 47,
		[Description("TNT Minecart"), ClassLink(typeof(MinecartTNT))]
		MinecartTNT = 45,
		[Description("Mooshroom"), ClassLink(typeof(MushroomCow))]
		MushroomCow = 96,
		[Description("Ocelot / Cat"), ClassLink(typeof(Ozelot))]
		Ozelot = 98,
		[ClassLink(typeof(Painting))]
		Painting = 9,
		[ClassLink(typeof(Pig))]
		Pig = 90,
		[Description("Zombie Pigman"), ClassLink(typeof(PigZombie))]
		PigZombie = 57,
		[Description("Primed TNT"), ClassLink(typeof(PrimedTNT))]
		PrimedTnt = 20,
		[ClassLink(typeof(Rabbit))]
		Rabbit = 101,
		[ClassLink(typeof(Sheep))]
		Sheep = 91,
		[ClassLink(typeof(Silverfish))]
		Silverfish = 60,
		[Description("Skeleton / Wither Skeleton"), ClassLink(typeof(Skeleton))]
		Skeleton = 51,
		[ClassLink(typeof(Slime))]
		Slime = 55,
		[Description("Fire Charge"), ClassLink(typeof(SmallFireball))]
		SmallFireball = 13,
		[ClassLink(typeof(Snowball))]
		Snowball = 11,
		[Description("Snow Golem"), ClassLink(typeof(SnowMan))]
		SnowMan = 97,
		[ClassLink(typeof(Spider))]
		Spider= 52,
		[ClassLink(typeof(Squid))]
		Squid = 94,
		[Description("Thrown Ender Pearl"), ClassLink(typeof(ThrownEnderPearl))]
		ThrownEnderpearl = 14,
		[Description("Bottle o' Enchanting"), ClassLink(typeof(ThrownExpBottle))]
		ThrownExpBottle = 17,
		[Description("Thrown Potion"), ClassLink(typeof(ThrownPotion))]
		ThrownPotion = 16,
		[ClassLink(typeof(Villager))]
		Villager = 120,
		[Description("Iron Golem"), ClassLink(typeof(VillagerGolem))]
		VillagerGolem = 99,
		[ClassLink(typeof(Witch))]
		Witch = 66,
		[Description("The Wither"), ClassLink(typeof(WitherBoss))]
		WitherBoss = 64,
		[Description("Wither Skull (Projectile)"), ClassLink(typeof(WitherSkull))]
		WitherSkull = 19,
		[ClassLink(typeof(Wolf))]
		Wolf = 95,
		[Description("Experience Orb"), ClassLink(typeof(XpOrb))]
		XPOrb = 2,
		[ClassLink(typeof(Zombie))]
		Zombie = 54
		// ReSharper restore InconsistentNaming
	}
}