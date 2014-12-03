using System.ComponentModel;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities
{
	public enum EntityTypes
	{
		[Description("Choose an Entity...")]
		NoEnt = 0x0,
		[Description("Armor Stand"), ClassLink(typeof(Other.ArmorStand))]
		ArmorStand,
		[ClassLink(typeof(Projectiles.Arrow))]
		Arrow,
		[ClassLink(typeof(Mobs.Friendly.Bat))]
		Bat,
		[ClassLink(typeof(Mobs.Hostile.Blaze))]
        Blaze,
		[ClassLink(typeof(Vehicles.Boat))]
		Boat,
		[Description("Cave Spider"), ClassLink(typeof(Mobs.Hostile.CaveSpider))]
		CaveSpider,
		[ClassLink(typeof(Mobs.Friendly.Chicken))]
		Chicken,
		[ClassLink(typeof(Mobs.Friendly.Cow))]
		Cow,
		[ClassLink(typeof(Mobs.Hostile.Creeper))]
		Creeper,
		[Description("Ender Crystal"), ClassLink(typeof(Other.EnderCrystal))]
		EnderCrystal,
		[Description("Ender Dragon"), ClassLink(typeof(Mobs.Hostile.EnderDragon))]
		EnderDragon,
		[ClassLink(typeof(Mobs.Hostile.Enderman))]
		Enderman,
		[Description("Endermite"), ClassLink(typeof(Mobs.Hostile.Endermite))]
		Endermite,
		//[Description("Horse/Donkey")]
		//EntityHorse,
		[Description("Thrown Eye of Ender"), ClassLink(typeof(Other.EyeOfEnder))]
		EyeOfEnderSignal,
		[Description("Falling Sand"), ClassLink(typeof(DynamicTiles.FallingSand))]
		FallingSand,
		[ClassLink(typeof(Projectiles.Fireball))]
		Fireball,
		[Description("Firework Rocket"), ClassLink(typeof(Other.FireworkRocketEntity))]
		FireworksRocketEntity,
		[ClassLink(typeof(Mobs.Hostile.Ghast))]
		Ghast,
		[ClassLink(typeof(Mobs.Hostile.Giant))]
		Giant,
		[ClassLink(typeof(Mobs.Hostile.Guardian))]
		Guardian,
		[ClassLink(typeof(ItemEntities.DroppedItem))]
		Item,
		[Description("Item Frame"), ClassLink(typeof(Other.WallEntities.ItemFrame))]
		ItemFrame,
		[Description("Magma Cube"), ClassLink(typeof(Mobs.Hostile.LavaSlime))]
		LavaSlime,
		//[Description("Leash Knot")]
		//LeashKnot,
		//[Description("Minecart Chest")]
		//MinecartChest,
		[Description("Command Block Minecart"), ClassLink(typeof(Vehicles.MinecartCommandBlock))]
		MinecartCommandBlock,
		[Description("Furnace Minecart"), ClassLink(typeof(Vehicles.MinecartFurnace))]
		MinecartFurnace,
		//MinecartHopper,
		[ClassLink(typeof(Vehicles.Minecart))]
		Minecart,
		//[Description("Spawner Minecart")]
		//MinecartSpawner,
		// ReSharper disable once InconsistentNaming
		[Description("TNT Minecart"), ClassLink(typeof(Vehicles.MinecartTNT))]
		MinecartTNT,
		//[Description("Mooshroom")]
		//MushroomCow,
		[Description("Ocelot / Cat"), ClassLink(typeof(Mobs.Friendly.Ozelot))]
		Ozelot,
		[ClassLink(typeof(Other.WallEntities.Painting))]
		Painting,
		[ClassLink(typeof(Mobs.Friendly.Pig))]
		Pig,
		[Description("Zombie Pigman"), ClassLink(typeof(Mobs.Hostile.PigZombie))]
		PigZombie,
		[Description("Primed TNT"), ClassLink(typeof(DynamicTiles.PrimedTNT))]
		PrimedTnt,
		[ClassLink(typeof(Mobs.Friendly.Rabbit))]
		Rabbit,
		[ClassLink(typeof(Mobs.Friendly.Sheep))]
		Sheep,
		//Silverfish,
		[Description("Skeleton / Wither Skeleton"), ClassLink(typeof(Mobs.Hostile.Skeleton))]
		Skeleton,
		[ClassLink(typeof(Mobs.Hostile.Slime))]
		Slime,
		[Description("Fire Charge"), ClassLink(typeof(Projectiles.SmallFireball))]
		SmallFireball,
		[ClassLink(typeof(Projectiles.Snowball))]
		Snowball,
		//[Description("Snow Golem")]
		//SnowMan,
		//Spider,
		//Squid,
		[Description("Thrown Ender Pearl"), ClassLink(typeof(Projectiles.ThrownEnderPearl))]
		ThrownEnderpearl,
		[Description("Bottle o' Enchanting"), ClassLink(typeof(Projectiles.ThrownExpBottle))]
		ThrownExpBottle,
		[Description("Thrown Potion"), ClassLink(typeof(Projectiles.ThrownPotion))]
		ThrownPotion,
		//Villager,
		[Description("Iron Golem"), ClassLink(typeof(Mobs.Friendly.VillagerGolem))]
		VillagerGolem,
		//Witch,
		[Description("The Wither"), ClassLink(typeof(Mobs.Hostile.WitherBoss))]
		WitherBoss,
		[Description("Wither Skull (Projectile)"), ClassLink(typeof(Projectiles.WitherSkull))]
		WitherSkull,
		[ClassLink(typeof(Mobs.Friendly.Wolf))]
		Wolf,
		[Description("Experience Orb"), ClassLink(typeof(ItemEntities.XpOrb))]
		XPOrb,
		[ClassLink(typeof(Mobs.Hostile.Zombie))]
		Zombie
	}
}