using System.Text;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Entities.Mobs.Hostile
{
	public class Skeleton :MobBase
	{
		private bool _skeletonType;

		[Property("Skeleton Options", "Is Wither Skeleton")]
		public bool SkeletonType
		{
			get { return _skeletonType; }
			set { _skeletonType = value; PropChanged("Display"); PropChanged("DisplayImage"); }
		}

		public Skeleton()
		{
			Type = EntityTypes.Skeleton;
			Health = 20;
		}

		public override string Display => base.Display + (SkeletonType? "Wither Skeleton" :"Skeleton");

		public override string DisplayImage => "/StackingEntities;component/Images/Mobs/Skeleton/" + (SkeletonType ? "WitherSkeleton.png" : "Skeleton.png");

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(topLevel));

			if (Health != 20)
				b.AppendFormat("HealF:{0}f,", Health);

			if (SkeletonType)
				b.Append("SkeletonType:1b,");

			return b.ToString();
		}
	}
}
