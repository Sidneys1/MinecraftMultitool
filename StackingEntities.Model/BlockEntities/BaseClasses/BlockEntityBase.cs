using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using StackingEntities.Model.Annotations;
using StackingEntities.Model.Interface;

namespace StackingEntities.Model.BlockEntities.BaseClasses
{
	[Serializable]
	public abstract class BlockEntityBase : IJsonAble, INotifyPropertyChanged
	{
		#region Properties

		//[EntityDescriptor("Block Entity Options", "Block ID", "The ID of the block this Block Entity represents.")]
		//public string Id { get; set; }

		// Should be unneeded.
		//[EntityDescriptor("Block Entity Options", "Block Position",
		//	"The coordinates of the block this Block Entity represents.", fixedSize: true, dgRowPath: "Name")]
		//public ObservableCollection<SimpleInt> CoordinateInts { get; } = new ObservableCollection<SimpleInt>
		//{
		//	new SimpleInt("X"),
		//	new SimpleInt("Y"),
		//	new SimpleInt("Z")
		//};

		#endregion

		//protected BlockEntityBase(string id)
		//{
		//	Id = id;
		//}

		#region IJsonAble

		public virtual string GenerateJson(bool topLevel)
		{
			return "{";
			//var b = new StringBuilder("{id:");
			//b.AppendFormat("\"{0}\",", Id.EscapeJsonString());
			//return b.ToString();
		}

		#endregion

		[field:NonSerialized]
		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void PropChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
