using System;

namespace StackingEntities.Model.Metadata
{
	[AttributeUsage(AttributeTargets.Field)]
	public class ClassLinkAttribute : Attribute
	{
		public readonly Type LinkType;

		public ClassLinkAttribute(Type linkType)
		{
			LinkType = linkType;
		}
	}
}
