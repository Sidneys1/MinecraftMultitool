using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Interface
{
	[Serializable]
	public abstract class Displayable : INotifyPropertyChanged
	{
		public abstract string Display { get; }
		public abstract string DisplayImage { get; }
		[field:NonSerialized]
		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void PropChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}