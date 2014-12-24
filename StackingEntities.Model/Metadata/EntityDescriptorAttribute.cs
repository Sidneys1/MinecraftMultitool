using System;

namespace StackingEntities.Model.Metadata
{
	[AttributeUsage(AttributeTargets.Property)]
	public class EntityDescriptorAttribute : Attribute
	{
		public readonly string Category, Name, IsEnabledPath, DataGridRowHeaderPath, Description;

		public readonly bool FixedSize, Wide;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category">The GroupBox this will be listed in</param>
		/// <param name="name">The readable name of this option</param>
		/// <param name="desc"></param>
		/// <param name="isEnabledPath">Optional: name of parameter that specifies if this option is enabled</param>
		/// <param name="fixedSize">Whether or not a List is of a fixed length.</param>
		/// <param name="dgRowPath">The path to the row header of a List displayed in a GridView</param>
		/// <param name="wide">Whether to span both the label and control column. (E.g., items with SlotTitle set.)</param>
		public EntityDescriptorAttribute(string category, string name, string desc = null, string isEnabledPath = null, bool fixedSize = false, string dgRowPath = null, bool wide = false)
		{
			Category = category;
			Name = name;
			IsEnabledPath = isEnabledPath;
			FixedSize = fixedSize;
			DataGridRowHeaderPath = dgRowPath;
			Description = desc;
			Wide = wide;
		}
	}
}
