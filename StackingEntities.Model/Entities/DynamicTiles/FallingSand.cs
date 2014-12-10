using System;
using System.Text;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.DynamicTiles
{
	[Serializable]
	internal class FallingSand : EntityBase
	{
		public FallingSand() 
		{
			Type = EntityTypes.FallingSand;
			DropItem = true;
			FallHurtMax = 40;
			FallHurtAmount = 2;
		}

		string _block;

		[EntityDescriptor("Falling Sand Options", "Block")]
		public string Block
		{
			get { return _block; }
			set { _block = value; PropChanged(); PropChanged("Display"); }
		}

		[EntityDescriptor("Falling Sand Options", "Block Data")]
		public int Data { get; set; }

		[EntityDescriptor("Falling Sand Options", "Time")]
		public int Time { get; set; }

		[EntityDescriptor("Falling Sand Options", "Drop Item")]
		public bool DropItem { get; set; }

		[EntityDescriptor("Falling Sand Options", "Damage Enemies/Players")]
		public bool HurtEnemies { get; set; }

		[EntityDescriptor("Falling Sand Options", "Max Damage")]
		public int FallHurtMax { get; set; }

		[EntityDescriptor("Falling Sand Options", "Damage Multiplier")]
		public double FallHurtAmount { get; set; }

		#region UI

		public override string Display => "Falling " + (!string.IsNullOrWhiteSpace(Block) ? Block : "Sand");

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/DynamicTiles/FallingSand.png";

		#endregion

		#region Process

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (!string.IsNullOrWhiteSpace(Block))
				b.Append(string.Format("Block:\"{0}\",", Block));

			if (Data != 0)
				b.Append(string.Format("Data:{0},", Data));

			if (Time != 0)
				b.Append(string.Format("Time:{0},", Time));

			if (!DropItem)
				b.Append(string.Format("DropItem:{0},", DropItem.ToString().ToLower()));

			b.Append(string.Format("HurtEnemies:{0},", HurtEnemies.ToString().ToLower()));

			if (FallHurtMax != 40)
				b.Append(string.Format("FallHurtMax:{0},", FallHurtMax));

			if (Math.Abs(FallHurtAmount - 2) > 0)
				b.Append(string.Format("FallHurtAmount:{0},", FallHurtAmount));

			return b.ToString();
		}

		#endregion
	}
}