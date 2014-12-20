using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using StackingEntities.Desktop.ViewModel;
using StackingEntities.Model.Entities;

namespace StackingEntities.Desktop.View.Controls
{
	/// <summary>
	/// Interaction logic for EntityDisplayControl.xaml
	/// </summary>
	public partial class EntityDisplayControl
	{
		private static readonly Dictionary<Type, List<Expander>> CachedOptions = new Dictionary<Type, List<Expander>>();

		private EntityBase _eBase;

		private EntityBase EBase
		{
			set
			{
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

		public EntityDisplayControl()
		{
			InitializeComponent();

			DataContextChanged += EntityDisplayControl_DataContextChanged;
		}

		private void EntityDisplayControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			var newValue = e.NewValue as EntityBase;
			if (newValue != null)
				EBase = newValue;
			else EditStackPanel.Children.Clear();
		}

		private void GenControls(EntityBase ent)
		{
			EditStackPanel.Children.Clear();

			var dict = new Dictionary<string, List<DisplayOption>>();

			#region Extract Options

			OptionsGenerator.ExtractOptions(ent, dict);

			#endregion

			#region Add Groups

			Type _type = DataContext.GetType();
			OptionsGenerator.AddGroups(dict).ForEach(o =>
			{
				EditStackPanel.Children.Add(o);
				CachedOptions[_type].Add(o);
			});

			#endregion
		}
	}
}
