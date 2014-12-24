using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using StackingEntities.Desktop.ViewModel;

namespace StackingEntities.Desktop.View.Controls
{
	/// <summary>
	/// Interaction logic for EntityDisplayControl.xaml
	/// </summary>
	public partial class OptionsDisplayControl
	{
		private static readonly Dictionary<Type, List<Expander>> CachedOptions = new Dictionary<Type, List<Expander>>();

		private object _eBase;

		private object EBase
		{
			set
			{
				if (value == null)
				{
					_eBase = null;
					return;
				}

				var newType = value.GetType();
				
				if (_eBase == null || _eBase.GetType() != newType)
				{

					if (CachedOptions.ContainsKey(value.GetType()))
					{
						EditStackPanel.Children.Clear();
						CachedOptions[newType].ForEach(o => EditStackPanel.Children.Add(o));
					}
					else
					{
						CachedOptions.Add(newType, new List<Expander>());
						GenControls(value);
					}
				}
				_eBase = value;
			}
		}

		public OptionsDisplayControl()
		{
			InitializeComponent();

			DataContextChanged += EntityDisplayControl_DataContextChanged;
		}

		private void EntityDisplayControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			var newValue = e.NewValue;
			EBase = newValue;
			if (newValue == null) EditStackPanel.Children.Clear();
		}

		private void GenControls(object ent)
		{
			EditStackPanel.Children.Clear();

			var dict = new Dictionary<string, List<DisplayOption>>();

			#region Extract Options

			OptionsGenerator.ExtractOptions(ent, dict);

			#endregion

			#region Add Groups

			var type = DataContext.GetType();
			OptionsGenerator.AddGroups(dict).ForEach(o =>
			{
				EditStackPanel.Children.Add(o);
				CachedOptions[type].Add(o);
			});

			#endregion
		}
	}
}
