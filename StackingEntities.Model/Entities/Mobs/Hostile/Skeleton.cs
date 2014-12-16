using System;
using System.Text;
using StackingEntities.Model.Enums;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	[Serializable]
	public class Skeleton :MobBase
	{
		private bool _skeletonType;

		[EntityDescriptor("Skeleton Options", "Is Wither Skeleton")]
		public bool SkeletonType
		{
			get { return _skeletonType; }
			set { _skeletonType = value; PropChanged("Display"); PropChanged("DisplayImage"); }
		}

		public Skeleton() : base(20)
		{
			Type = EntityType.Skeleton;
		}

		public override string Display => base.Display + (SkeletonType? "Wither Skeleton" :"Skeleton");

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Mobs/Skeleton/" + (SkeletonType ? "WitherSkeleton.png" : "Skeleton.png");

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (SkeletonType)
				b.Append("SkeletonType:1b,");

			return b.ToString();
		}
	}
}
