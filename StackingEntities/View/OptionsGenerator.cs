using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Items;
using StackingEntities.View.Controls;
using StackingEntities.ViewModel;
using Xceed.Wpf.Toolkit;

namespace StackingEntities.View
{
	public class OptionsGenerator
	{
		public static Expander AddGroup(string header, Dictionary<string, List<DisplayOption>> dict, bool BindDirect = false, bool wide = false)
		{
			var g = new Expander { Header = header };

			if (wide)
				g.Margin = new Thickness(10, 0, 0, 0);

			var grid = new Grid { Margin = new Thickness(20, 0, 10, 0) };
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0, GridUnitType.Auto) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			g.Content = grid;
			var i = 0;

			#region Add Controls

			foreach (var option in dict[header])
			{
				grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0, GridUnitType.Auto) });

				FrameworkElement elem = new Label();

				#region Bool

				if (option.PropertyType == typeof(bool))
				{
					elem = ExtractBool(option);
				}

				#endregion

				#region Int

				else if (option.PropertyType == typeof(int))
				{
					elem = ExtractInt(option);
				}

				#endregion

				#region String

				else if (option.PropertyType == typeof(string))
				{
					elem = ExtractString(option);
				}

				#endregion

				#region Double

				else if (option.PropertyType == typeof(double))
				{
					elem = ExtractDouble(option);
				}

				#endregion

				#region Enum

				else if (option.PropertyType.IsEnum)
				{
					elem = ExtractEnum(option);
				}

				#endregion

				#region Item

				else if (option.PropertyType == typeof(Item))
				{
					elem = ExtractItem(option);
				}

				#endregion

				#region List

				else if (option.PropertyType.IsGenericType && option.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
				{
					elem = ExtractList(option);
				}

				#endregion

				if (!option.PropertyType.IsGenericType || option.PropertyType.GetGenericTypeDefinition() != typeof(List<>))
				{
					var l = new Label { Content = option.ReadableName };
					l.SetValue(Grid.RowProperty, i);

					if (option.EnabledPropertyName != null)
						l.SetBinding(UIElement.IsEnabledProperty, new Binding(option.EnabledPropertyName));

					grid.Children.Add(l);
					elem.SetValue(Grid.ColumnProperty, 1);
				}

				if (option.EnabledPropertyName != null)
					elem.SetBinding(UIElement.IsEnabledProperty, new Binding(option.EnabledPropertyName));

				elem.SetValue(Grid.RowProperty, i);
				if (BindDirect)
					elem.DataContext = option.DataContext;

				grid.Children.Add(elem);

				i++;
			}

			#endregion

			return g;

		}

		private static FrameworkElement ExtractList(DisplayOption option)
		{
			var drop = new Expander { Margin = new Thickness(5), Header = option.ReadableName };
			// ReSharper disable once UseObjectOrCollectionInitializer
			var ctrl = new DataGrid
			{
				Margin = new Thickness(3),
				AutoGenerateColumns = true,
				CanUserAddRows = !option.FixedSize,
				MinHeight = 50
			};

			ctrl.AutoGeneratingColumn += (sender1, e1) =>
			{
				var displayName = PropertyHelpers.GetPropertyDisplayName(e1.PropertyDescriptor);
				if (!string.IsNullOrEmpty(displayName))
					e1.Column.Header = displayName;
				else
					e1.Cancel = true;
			};

			if (option.DataGridRowHeaderPath != null)
			{
				var rowHeaderStyle = new Style(typeof(DataGridRowHeader));
				rowHeaderStyle.Setters.Add(new Setter(ContentControl.ContentProperty, new Binding(option.DataGridRowHeaderPath)));
				ctrl.RowHeaderStyle = rowHeaderStyle;
			}

			ctrl.SetBinding(ItemsControl.ItemsSourceProperty, new Binding(option.PropertyName));
			//elem = ctrl;
			drop.Content = ctrl;
			drop.SetValue(Grid.ColumnSpanProperty, 2);
			return drop;
		}

		private static FrameworkElement ExtractItem(DisplayOption option)
		{
			var ctrl = new ItemControl { Margin = new Thickness(3) };
			ctrl.SetBinding(FrameworkElement.DataContextProperty, new Binding(option.PropertyName));
			return ctrl;
		}

		private static FrameworkElement ExtractEnum(DisplayOption option)
		{
			var ctrl = new ComboBox { Margin = new Thickness(3) };
			var m = typeof(EnumHelper).GetMethod("GetAllValuesAndDescriptions").MakeGenericMethod(option.PropertyType);
			var ie = m.Invoke(null, null) as IEnumerable;
			ctrl.ItemsSource = ie;
			ctrl.DisplayMemberPath = "Description";
			ctrl.SetBinding(Selector.SelectedValueProperty, new Binding(option.PropertyName));
			ctrl.SelectedValuePath = "Value";
			return ctrl;
		}

		private static FrameworkElement ExtractDouble(DisplayOption option)
		{
			var ctrl = new DoubleUpDown
			{
				FormatString = "F2",
				Margin = new Thickness(3),
				HorizontalAlignment = HorizontalAlignment.Left,
				MinWidth = 50
			};
			ctrl.SetBinding(DoubleUpDown.ValueProperty, new Binding(option.PropertyName));
			return ctrl;
		}

		private static FrameworkElement ExtractString(DisplayOption option)
		{
			var ctrl = new TextBox { Margin = new Thickness(3) };

			if (option.Multiline)
			{
				ctrl.TextWrapping = TextWrapping.Wrap;
				ctrl.AcceptsReturn = true;
				ctrl.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
				ctrl.MinHeight = 100;
			}

			ctrl.SetBinding(TextBox.TextProperty, new Binding(option.PropertyName));
			return ctrl;
		}

		private static FrameworkElement ExtractInt(DisplayOption option)
		{
			var ctrl = new IntegerUpDown
			{
				Margin = new Thickness(3),
				HorizontalAlignment = HorizontalAlignment.Left,
				MinWidth = 50
			};
			ctrl.SetBinding(IntegerUpDown.ValueProperty, new Binding(option.PropertyName));

			if (option.Minimum is int)
				ctrl.Minimum = (int?)option.Minimum;

			if (option.Maximum is int)
				ctrl.Maximum = (int?)option.Maximum;
			return ctrl;
		}

		private static FrameworkElement ExtractBool(DisplayOption option)
		{
			var ctrl = new CheckBox { Margin = new Thickness(3), VerticalAlignment = VerticalAlignment.Center };
			ctrl.SetBinding(ToggleButton.IsCheckedProperty, new Binding(option.PropertyName));
			return ctrl;
		}
	}
}