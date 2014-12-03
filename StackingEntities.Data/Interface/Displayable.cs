﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Interface
{
	public abstract class Displayable : INotifyPropertyChanged
	{
		public abstract string Display { get; }
		public abstract string DisplayImage { get; }
		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void PropChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}