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
		#region IJsonAble

		public virtual string GenerateJson(bool topLevel)
		{
			return "{";
		}

		#endregion

		#region INotifyPropertyChanged

		[field: NonSerialized]
		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void PropChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion

	}
}
