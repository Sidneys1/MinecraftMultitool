using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using StackingEntities.Desktop.View.Controls;
using StackingEntities.Desktop.ViewModel;
using StackingEntities.Model.Annotations;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Items;
using StackingEntities.Model.Metadata;
using StackingEntities.Model.Objects;
using Xceed.Wpf.Toolkit;
using Attribute = StackingEntities.Model.Objects.Attribute;
using DisplayOptionList = System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<StackingEntities.Desktop.ViewModel.DisplayOption>>;
using CacheTypeList = System.Collections.Generic.Dictionary<System.Type, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<StackingEntities.Desktop.ViewModel.DisplayOption>>>;
using ExpanderList = System.Collections.Generic.List<System.Windows.Controls.Expander>;

namespace StackingEntities.Desktop.View
{
	public class OptionsGenerator
	{
		public static ExpanderList AddGroups(DisplayOptionList dict, bool wide = false)
		{
			return dict.Keys.Select(key => AddGroup(key, dict, wide)).ToList();
		}

		public static Expander AddGroup(string header, DisplayOptionList dict, bool wide = false)
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

				FrameworkElement elem;

				#region Bool

				if (option.PropertyType == typeof(bool))
				{
					elem = ExtractBool(option);
				}

				else if (option.PropertyType == typeof(bool?))
				{
					elem = ExtractNullableBool(option);
				}

				#endregion

				#region Int

				else if (option.PropertyType == typeof(int) || option.PropertyType == typeof(int?))
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

				else if (option.PropertyType.IsGenericType && option.PropertyType.GetGenericTypeDefinition() == typeof(ObservableCollection<>))
				{
					elem = ExtractList(option);
				}

				#endregion

				else
				{
					elem = ExtractGeneric(option);
				}

				if (elem.GetValue(Grid.ColumnSpanProperty)?.Equals(1) ?? true)
				{
					var l = new Label { Content = option.ReadableName, ToolTip = option.Description };
					l.SetValue(Grid.RowProperty, i);

					if (option.EnabledPropertyName != null)
						l.SetBinding(UIElement.IsEnabledProperty, new Binding(option.EnabledPropertyName));

					grid.Children.Add(l);
					elem.SetValue(Grid.ColumnProperty, 1);
				}

				if (option.EnabledPropertyName != null)
					elem.SetBinding(UIElement.IsEnabledProperty, new Binding(option.EnabledPropertyName));

				elem.SetValue(Grid.RowProperty, i);

				elem.ToolTip = option.Description;

				grid.Children.Add(elem);

				i++;
			}

			#endregion

			return g;

		}

		private static FrameworkElement ExtractNullableBool(DisplayOption option)
		{
			var ctrl = new CheckBox {IsThreeState = true, Style = (Style)Application.Current.Resources["YesNoInheritCheckbox"] };
			ctrl.SetBinding(ToggleButton.IsCheckedProperty, new Binding(option.PropertyName));
			return ctrl;
		}


		private static FrameworkElement ExtractGeneric(DisplayOption option)
		{
			var ctrl = new ContentPresenter { Margin = new Thickness(3)};
			ctrl.SetBinding(ContentPresenter.ContentProperty, new Binding(option.PropertyName));
			if (option.Wide)
				ctrl.SetValue(Grid.ColumnSpanProperty, 2);

			return ctrl;
		}

		private static FrameworkElement ExtractList(DisplayOption option)
		{
			var drop = new Expander { Margin = new Thickness(5), Header = option.ReadableName };

			var listType = option.PropertyType.GetGenericArguments()[0];

			FrameworkElement ctrl;

			if (listType == typeof(Item)
				|| listType == typeof(Attribute)
				|| listType == typeof(VillagerRecipe)
				|| listType == typeof(PotionEffect)
				|| listType == typeof(BookPage)
				|| listType == typeof(Enchantment)
				|| listType == typeof(MapDecoration)
				|| listType == typeof(BlockType)
				|| listType == typeof(BannerPattern)
				|| listType == typeof(JsonTextElement))
			{
				if (!option.FixedSize || (option.Minimum == null || option.Maximum == null))
				{
					var sPanel = new ItemListControl
					{
						SlotDescription = { Text = option.Description },
						AddRemoveButtons = { Visibility = option.FixedSize ? Visibility.Collapsed : Visibility.Visible }
					};
					sPanel.SetBinding(FrameworkElement.DataContextProperty, new Binding(option.PropertyName));
					ctrl = sPanel;
				}
				else
				{
					var invGrid = new InventoryControl
					{
						InvWidth = (int) option.Minimum,
						InvHeight = (int) option.Maximum,
						HorizontalAlignment = HorizontalAlignment.Center
					};
					invGrid.SetBinding(FrameworkElement.DataContextProperty, new Binding(option.PropertyName));
					
					ctrl = invGrid;
				}
			}
			else
			{
				// ReSharper disable once UseObjectOrCollectionInitializer
				var ctrl2 = new DataGrid
				{
					Margin = new Thickness(3),
					AutoGenerateColumns = true,
					CanUserAddRows = !option.FixedSize,
					MinHeight = 50
				};

				ctrl2.AutoGeneratingColumn += (sender1, e1) =>
				{
					var displayName = PropertyHelpers.GetPropertyDisplayName(e1.PropertyDescriptor);
					if (e1.PropertyType == typeof(string))
						((DataGridTextColumn)e1.Column).EditingElementStyle = (Style)Application.Current.Resources["DataGridTextColumnStyle"];

					if (!string.IsNullOrEmpty(displayName))
						e1.Column.Header = displayName;
					else
						e1.Cancel = true;
				};

				if (option.DataGridRowHeaderPath != null)
				{
					var rowHeaderStyle = new Style(typeof(DataGridRowHeader));
					rowHeaderStyle.Setters.Add(new Setter(ContentControl.ContentProperty, new Binding(option.DataGridRowHeaderPath)));
					ctrl2.RowHeaderStyle = rowHeaderStyle;
				}
				ctrl2.Margin = new Thickness(15, 0, 0, 0);
				ctrl = ctrl2;
				ctrl.SetBinding(ItemsControl.ItemsSourceProperty, new Binding(option.PropertyName));
			}


			drop.Content = ctrl;
			drop.SetValue(Grid.ColumnSpanProperty, 2);
			return drop;
		}

		private static FrameworkElement ExtractItem(DisplayOption option)
		{
			var ctrl = new ItemControl { Margin = new Thickness(3) };
			ctrl.SetBinding(FrameworkElement.DataContextProperty, new Binding(option.PropertyName));
			if (option.Wide)
				ctrl.SetValue(Grid.ColumnSpanProperty, 2);
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

			double newVal;
			if (option.Minimum != null)
			{
				newVal = Convert.ToDouble(option.Minimum);
				ctrl.Minimum = newVal;
			}
			if (option.Maximum != null)
			{
				newVal = Convert.ToDouble(option.Maximum);
				ctrl.Maximum = newVal;
			}

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

			int newVal;
			if (option.Minimum != null)
			{
				newVal = Convert.ToInt32(option.Minimum);
				ctrl.Minimum = newVal;
			}
			if (option.Maximum != null)
			{
				newVal = Convert.ToInt32(option.Maximum);
				ctrl.Maximum = newVal;
			}
			return ctrl;
		}

		private static FrameworkElement ExtractBool(DisplayOption option)
		{
			var ctrl = new CheckBox();
			ctrl.SetBinding(ToggleButton.IsCheckedProperty, new Binding(option.PropertyName));
			return ctrl;
		}

		private static readonly CacheTypeList _cachedTypes = new CacheTypeList(); 
		public static void ExtractOptions([NotNull] object ent, DisplayOptionList dict)
		{
			if (ent == null) throw new ArgumentNullException("ent");

			var eType = ent.GetType();
			if (_cachedTypes.ContainsKey(eType))
			{
				foreach (var type in _cachedTypes[eType])
				{
					dict[type.Key] = type.Value;
				}

				return;
			}

			var props = eType.GetProperties();
			_cachedTypes[eType] = new DisplayOptionList();
			foreach (var info in props.Reverse())
			{
				if (!System.Attribute.IsDefined(info, typeof (EntityDescriptorAttribute))) continue;
				var prop = (EntityDescriptorAttribute) info.GetCustomAttribute(typeof (EntityDescriptorAttribute));

				if (!dict.ContainsKey(prop.Category))
					dict.Add(prop.Category, new List<DisplayOption>());
				if (!_cachedTypes[eType].ContainsKey(prop.Category))
					_cachedTypes[eType].Add(prop.Category, new List<DisplayOption>());

				object min = null, max = null;
				var multiline = System.Attribute.IsDefined(info, typeof (MultilineStringAttribute));

				if (System.Attribute.IsDefined(info, typeof (MinMaxAttribute)))
				{
					var att = (MinMaxAttribute) info.GetCustomAttribute(typeof (MinMaxAttribute));
					min = att.Minimum;
					max = att.Maximum;
				}

				var displayOption = new DisplayOption(prop.Name, info.Name, info.PropertyType, prop.Description, min, max, multiline, prop.IsEnabledPath, prop.FixedSize, prop.DataGridRowHeaderPath, prop.Wide);

				_cachedTypes[eType][prop.Category].Insert(0, displayOption);
				dict[prop.Category].Insert(0, displayOption);
			}
		}
	}
}