using System.ComponentModel;

namespace StackingEntities
{
	public abstract class Displayable : INotifyPropertyChanged
	{
		public abstract string Display { get; }
		public abstract string DisplayImage { get; }
		public virtual event PropertyChangedEventHandler PropertyChanged;

		protected void PropChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			//PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}