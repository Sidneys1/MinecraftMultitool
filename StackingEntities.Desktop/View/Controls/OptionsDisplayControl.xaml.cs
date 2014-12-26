using System.Windows;
using CacheList = System.Collections.Generic.Dictionary<System.Type, System.Collections.Generic.List<System.Windows.Controls.Expander>>;
using ExpanderList = System.Collections.Generic.List<System.Windows.Controls.Expander>;
using UIList = System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<StackingEntities.Desktop.ViewModel.DisplayOption>>;

namespace StackingEntities.Desktop.View.Controls
{
	/// <summary>
	/// Interaction logic for EntityDisplayControl.xaml
	/// </summary>
	public partial class OptionsDisplayControl
	{
		private static readonly CacheList CachedOptions = new CacheList();

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
						CachedOptions.Add(newType, new ExpanderList());
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

			var dict = new UIList();

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
