using System.ComponentModel;

namespace StackingEntities.Entities
{
	public enum EntityTypes
	{
		[Description("Choose an Entity...")]
		NoEnt = 0x0,
		[Description("Armor Stand")]
		ArmorStand,
		//Arrow,
		Bat,
		Blaze,
		Boat,
		[Description("Cave Spider")]
		CaveSpider,
		Chicken,
		Cow,
		Creeper,
		[Description("Ender Crystal")]
		EnderCrystal,
		[Description("Ender Dragon")]
		EnderDragon,
		Enderman,
		[Description("Endermite")]
		Endermite,
		//[Description("Horse/Donkey")]
		//EntityHorse,
		[Description("Thrown Eye of Ender")]
		EyeOfEnderSignal,
		[Description("Falling Sand")]
		FallingSand,
		//Fireball,
		[Description("Firework Rocket")]
		FireworksRocketEntity,
		Ghast,
		Giant,
		Guardian,
		Item,
		[Description("Item Frame")]
		ItemFrame,
		[Description("Magma Cube")]
		LavaSlime,
		//[Description("Leash Knot")]
		//LeashKnot,
		//[Description("Minecart Chest")]
		//MinecartChest,
		[Description("Command Block Minecart")]
		MinecartCommandBlock,
		[Description("Furnace Minecart")]
		MinecartFurnace,
		//MinecartHopper,
		Minecart,
		//[Description("Spawner Minecart")]
		//MinecartSpawner,
		// ReSharper disable once InconsistentNaming
		[Description("TNT Minecart")]
		MinecartTNT,
		//[Description("Mooshroom")]
		//MushroomCow,
		[Description("Ocelot / Cat")]
		Ozelot,
		Painting,
		Pig,
		//[Description("Zombie Pigman")]
		//PigZombie,
		[Description("Primed TNT")]
		PrimedTnt,
		Rabbit,
		Sheep,
		//Silverfish,
		[Description("Skeleton / Wither Skeleton")]
		Skeleton,
		Slime,
		//[Description("Fire Charge")]
		//SmallFireball,
		//Snowball,
		//[Description("Snow Golem")]
		//SnowMan,
		//Spider,
		//Squid,
		//[Description("Thrown Enderpearl")]
		//ThrownEnderpearl,
		//[Description("Thrown Experience Bottle")]
		//ThrownExpBottle,
		//[Description("Thrown Potion")]
		//ThrownPotion,
		//Villager,
		[Description("Iron Golem")]
		VillagerGolem,
		//Witch,
		[Description("The Wither")]
		WitherBoss,
		//[Description("Wither Skull (Projectile)")]
		//WitherSkull,
		Wolf,
		[Description("Experience Orb")]
		XPOrb,
		Zombie
	}
}