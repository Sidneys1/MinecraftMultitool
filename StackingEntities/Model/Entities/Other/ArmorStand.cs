using System;
using System.Collections.Generic;
using System.Text;
using StackingEntities.Model.Items;
using StackingEntities.Model.Items.ItemTags;
using StackingEntities.ViewModel;

namespace StackingEntities.Model.Entities.Other
{
	internal class ArmorStand : EntityBase
	{
		public ArmorStand()
		{
			Type = EntityTypes.ArmorStand;

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

		#region Pose

		[Property("Pose", "Body Pose", fixedSize: true, dgRowPath: "Name")]
		public List<SimpleDouble> BodyPose { get; } = new List<SimpleDouble> { new SimpleDouble("X"), new SimpleDouble("Y"), new SimpleDouble("Z") };

		//[Property("Body Pose", "X Rotation"), MinMax(0, 359)]
		//public double BodyX { get; set; }
		//[Property("Body Pose", "Y Rotation"), MinMax(0, 359)]
		//public double BodyY { get; set; }
		//[Property("Body Pose", "Z Rotation"), MinMax(0, 359)]
		//public double BodyZ { get; set; }

		[Property("Pose", "Head Pose", fixedSize: true, dgRowPath: "Name")]
		public List<SimpleDouble> HeadPose { get; } = new List<SimpleDouble> { new SimpleDouble("X"), new SimpleDouble("Y"), new SimpleDouble("Z") };

		//[Property("Head Pose", "X Rotation"), MinMax(0, 359)]
		//public double HeadX { get; set; }
		//[Property("Head Pose", "Y Rotation"), MinMax(0, 359)]
		//public double HeadY { get; set; }
		//[Property("Head Pose", "Z Rotation"), MinMax(0, 359)]
		//public double HeadZ { get; set; }

		[Property("Pose", "Left Arm Pose", fixedSize: true, dgRowPath: "Name")]
		public List<SimpleDouble> LeftArmPose { get; } = new List<SimpleDouble> { new SimpleDouble("X"), new SimpleDouble("Y"), new SimpleDouble("Z") };

		//[Property("Left Arm Pose", "X Rotation"), MinMax(0, 359)]
		//public double LeftArmX { get; set; }
		//[Property("Left Arm Pose", "Y Rotation"), MinMax(0, 359)]
		//public double LeftArmY { get; set; }
		//[Property("Left Arm Pose", "Z Rotation"), MinMax(0, 359)]
		//public double LeftArmZ { get; set; }

		[Property("Pose", "Right Arm Pose", fixedSize: true, dgRowPath: "Name")]
		public List<SimpleDouble> RightArmPose { get; } = new List<SimpleDouble> { new SimpleDouble("X"), new SimpleDouble("Y"), new SimpleDouble("Z") };

		//[Property("Right Arm Pose", "X Rotation"), MinMax(0, 359)]
		//public double RightArmX { get; set; }
		//[Property("Right Arm Pose", "Y Rotation"), MinMax(0, 359)]
		//public double RightArmY { get; set; }
		//[Property("Right Arm Pose", "Z Rotation"), MinMax(0, 359)]
		//public double RightArmZ { get; set; }

		[Property("Pose", "Left Leg Pose", fixedSize: true, dgRowPath: "Name")]
		public List<SimpleDouble> LeftLegPose { get; } = new List<SimpleDouble> { new SimpleDouble("X"), new SimpleDouble("Y"), new SimpleDouble("Z") };

		//[Property("Left Leg Pose", "X Rotation"), MinMax(0, 359)]
		//public double LeftLegX { get; set; }
		//[Property("Left Leg Pose", "Y Rotation"), MinMax(0, 359)]
		//public double LeftLegY { get; set; }
		//[Property("Left Leg Pose", "Z Rotation"), MinMax(0, 359)]
		//public double LeftLegZ { get; set; }

		[Property("Pose", "Right Leg Pose", fixedSize: true, dgRowPath: "Name")]
		public List<SimpleDouble> RightLegPose { get; } = new List<SimpleDouble> { new SimpleDouble("X"), new SimpleDouble("Y"), new SimpleDouble("Z") };

		//[Property("Right Leg Pose", "X Rotation"), MinMax(0, 359)]
		//public double RightLegX { get; set; }
		//[Property("Right Leg Pose", "Y Rotation"), MinMax(0, 359)]
		//public double RightLegY { get; set; }
		//[Property("Right Leg Pose", "Z Rotation"), MinMax(0, 359)]
		//public double RightLegZ { get; set; } 

		#endregion

		#region Slots

		[Property("Disabled Slots", "Hands")]
		public DisabledSlots HandsDisabledSlots { get; set; } = DisabledSlots.All;

		[Property("Disabled Slots", "Fee")]
		public DisabledSlots FeetDisabledSlots { get; set; }

		[Property("Disabled Slots", "Legs")]
		public DisabledSlots LegsDisabledSlots { get; set; }

		[Property("Disabled Slots", "Chest")]
		public DisabledSlots ChestDisabledSlots { get; set; }

		[Property("Disabled Slots", "Head")]
		public DisabledSlots HeadDisabledSlots { get; set; }

		[Property("Equipment", "Holding")]
		public Item Holding { get; set; } = new Item() { Id = string.Empty };

		[Property("Equipment", "Boots")]
		public Item Boots { get; set; } = new Item() { Id = string.Empty, CountTagEnabled = false };

		[Property("Equipment", "Leggings")]
		public Item Leggings { get; set; } = new Item() { Id = string.Empty, CountTagEnabled = false };

		[Property("Equipment", "Chestplate")]
		public Item Chestplate { get; set; } = new Item() { Id = string.Empty, CountTagEnabled = false };

		[Property("Equipment", "Helmet")]
		public Item Helmet { get; set; } = new Item() { Id = string.Empty, CountTagEnabled = false };

		#endregion

		#region Bools

		private bool _marker;

		[Property("Armor Stand Options", "Marker")]
		public bool Marker
		{
			get { return _marker; }
			set
			{
				_marker = value;
				PropChanged("Display");
			}
		}

		private bool _invisible;

		[Property("Armor Stand Options", "Invisible")]
		public bool Invisible
		{
			get { return _invisible; }
			set
			{
				_invisible = value;
				PropChanged("Display");
			}
		}

		private bool _noBasePlate;

		[Property("Armor Stand Options", "No Baseplate")]
		public bool NoBasePlate
		{
			get { return _noBasePlate; }
			set
			{
				_noBasePlate = value;
				PropChanged("Display");
			}
		}

		private bool _noGravity;

		[Property("Armor Stand Options", "No Gravity")]
		public bool NoGravity
		{
			get { return _noGravity; }
			set
			{
				_noGravity = value;
				PropChanged("Display");
			}
		}

		private bool _showArms;

		[Property("Armor Stand Options", "Show Arms")]
		public bool ShowArms
		{
			get { return _showArms; }
			set
			{
				_showArms = value;
				PropChanged("Display");
			}
		}

		private bool _small;
		

		[Property("Armor Stand Options", "Small")]
		public bool Small
		{
			get { return _small; }
			set
			{
				_small = value;
				PropChanged("Display");
			}
		}

		#endregion

		public override string Display
		{
			get
			{
				var b = new StringBuilder(base.Display);

				if (Small)
					b.Append("Small ");

				if (ShowArms)
					b.Append("Armed ");

				if (Invisible)
					b.Append("Invisible ");

				if (Marker)
					b.Append("Marker ");

				if (NoBasePlate)
					b.Append("w/o Baseplate ");

				if (NoBasePlate && NoGravity)
					b.Append("or Gravity");
				else if (NoGravity)
					b.Append("w/o Gravity");


				//b.Append("Armor Stand");
				return b.ToString();
			}
		}

		public override string DisplayImage => "Images/Other/ArmorStand.png";

		public override string GenerateJSON(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJSON(topLevel));

			//DisabledSlots

			if (Marker)
				b.Append("Marker:1b,");
			if (Invisible)
				b.Append("Invisible:1b,");
			if (NoBasePlate)
				b.Append("NoBasePlate:1b,");
			if (NoGravity)
				b.Append("NoGravity:1b,");
			if (ShowArms)
				b.Append("ShowArms:1b,");
			if (Small)
				b.Append("Small:1b,");

			uint slots = 0;
			if ((HandsDisabledSlots & DisabledSlots.Remove) == DisabledSlots.Remove)
				slots |= 1;
			if ((HandsDisabledSlots & DisabledSlots.Replace) == DisabledSlots.Replace)
				slots |= 1 << 8;
			if ((HandsDisabledSlots & DisabledSlots.Place) == DisabledSlots.Place)
				slots |= 1 << 16;

			if ((FeetDisabledSlots & DisabledSlots.Remove) == DisabledSlots.Remove)
				slots |= 1<<1;
			if ((FeetDisabledSlots & DisabledSlots.Replace) == DisabledSlots.Replace)
				slots |= 1 << 9;
			if ((FeetDisabledSlots & DisabledSlots.Place) == DisabledSlots.Place)
				slots |= 1 << 17;

			if ((LegsDisabledSlots & DisabledSlots.Remove) == DisabledSlots.Remove)
				slots |= 1 << 2;
			if ((LegsDisabledSlots & DisabledSlots.Replace) == DisabledSlots.Replace)
				slots |= 1 << 10;
			if ((LegsDisabledSlots & DisabledSlots.Place) == DisabledSlots.Place)
				slots |= 1 << 18;

			if ((ChestDisabledSlots & DisabledSlots.Remove) == DisabledSlots.Remove)
				slots |= 1 << 3;
			if ((ChestDisabledSlots & DisabledSlots.Replace) == DisabledSlots.Replace)
				slots |= 1 << 11;
			if ((ChestDisabledSlots & DisabledSlots.Place) == DisabledSlots.Place)
				slots |= 1 << 19;

			if ((HeadDisabledSlots & DisabledSlots.Remove) == DisabledSlots.Remove)
				slots |= 1 << 4;
			if ((HeadDisabledSlots & DisabledSlots.Replace) == DisabledSlots.Replace)
				slots |= 1 << 12;
			if ((HeadDisabledSlots & DisabledSlots.Place) == DisabledSlots.Place)
				slots |= 1 << 20;

			if (slots != 65793)
				b.Append(string.Format("DisabledSlots:{0},", slots));

			var poseInner = new StringBuilder();

			const float tol = 0.001f;
			if (Math.Abs(BodyPose[0].Value) > tol || Math.Abs(BodyPose[1].Value) > tol || Math.Abs(BodyPose[2].Value) > tol)
				poseInner.AppendFormat("Body:[{0:0.##}f,{1:0.##}f,{2:0.##}f],", BodyPose[0].Value, BodyPose[1].Value, BodyPose[2].Value);
			if (Math.Abs(LeftArmPose[0].Value) > tol || Math.Abs(LeftArmPose[1].Value) > tol || Math.Abs(LeftArmPose[2].Value) > tol)
				poseInner.AppendFormat("LeftArm:[{0:0.##}f,{1:0.##}f,{2:0.##}f],", LeftArmPose[0].Value, LeftArmPose[1].Value, LeftArmPose[2].Value);
			if (Math.Abs(RightArmPose[0].Value) > tol || Math.Abs(RightArmPose[1].Value) > tol || Math.Abs(RightArmPose[2].Value) > tol)
				poseInner.AppendFormat("RightArm:[{0:0.##}f,{1:0.##}f,{2:0.##}f],", RightArmPose[0].Value, RightArmPose[1].Value, RightArmPose[2].Value);
			if (Math.Abs(LeftLegPose[0].Value) > tol || Math.Abs(LeftLegPose[1].Value) > tol || Math.Abs(LeftLegPose[2].Value) > tol)
				poseInner.AppendFormat("LeftLeg:[{0:0.##}f,{1:0.##}f,{2:0.##}f],", LeftLegPose[0].Value, LeftLegPose[1].Value, LeftLegPose[2].Value);
			if (Math.Abs(RightLegPose[0].Value) > tol || Math.Abs(RightLegPose[1].Value) > tol || Math.Abs(RightLegPose[2].Value) > tol)
				poseInner.AppendFormat("RightLeg:[{0:0.##}f,{1:0.##}f,{2:0.##}f],", RightLegPose[0].Value, RightLegPose[1].Value, RightLegPose[2].Value);
			if (Math.Abs(HeadPose[0].Value) > tol || Math.Abs(HeadPose[1].Value) > tol || Math.Abs(HeadPose[2].Value) > tol)
				poseInner.AppendFormat("Head:[{0:0.##}f,{1:0.##}f,{2:0.##}f],", HeadPose[0].Value, HeadPose[1].Value, HeadPose[2].Value);

			if (poseInner.Length <= 0) return b.ToString();
			poseInner.Remove(poseInner.Length - 1, 1);
			poseInner.Insert(0, "Pose:{");
			poseInner.Append("},");
			b.Append(poseInner);

			return b.ToString();
		}
	}
}