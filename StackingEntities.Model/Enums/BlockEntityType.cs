using System.ComponentModel;
using StackingEntities.Model.BlockEntities;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Enums
{
	public enum BlockEntityType
	{
		// ReSharper disable InconsistentNaming
		[ClassLink(typeof(Banner))]
		Banner,
		[ClassLink(typeof(Beacon))]
		Beacon,
		[Description("Brewing Stand"), ClassLink(typeof(Cauldron))]
		Cauldron,
		[ClassLink(typeof(Chest))]
		Chest,
		[Description("Command Block"), ClassLink(typeof(Control))]
		Control,
		[ClassLink(typeof(Dropper))]	
		Dropper,
		[Description("Flower Pot"), ClassLink(typeof(FlowerPot))]
		FlowerPot,
		[ClassLink(typeof(Furnace))]
		Furnace,
		[ClassLink(typeof(Hopper))]
		Hopper,
		//[Description("Mob Spawner")]
		//MobSpawner,
		[Description("Note Block"), ClassLink(typeof(Music))]
		Music,
		[Description("Jukebox"), ClassLink(typeof(RecordPlayer))]
		RecordPlayer,
		[ClassLink(typeof(Sign))]
		Sign,
		[Description("Skull/Player Head"), ClassLink(typeof(Head))]
		Skull,
		[Description("Dispenser"), ClassLink(typeof(Dropper))]
		Trap
		// ReSharper restore InconsistentNaming
	}
}
