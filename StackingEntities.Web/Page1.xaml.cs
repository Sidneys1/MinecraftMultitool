﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using StackingEntities.Model;
using StackingEntities.Model.Entities;
using StackingEntities.Model.Metadata;
using StackingEntities.Desktop.View;
using StackingEntities.Desktop.ViewModel;
using Attribute = System.Attribute;

namespace StackingEntities.Web
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1
    {
		readonly DataModel _model;
		public Page1()
        {
            InitializeComponent();
			_model = (DataModel)DataContext;
		}

		private void DeleteSelectedEntityButton_Clicked(object sender, MouseButtonEventArgs e)
		{
			_model.Entities.Remove((EntityBase)EntitiesListBox.SelectedItem);
		}

		private void MoveSelectedEntityUpBtn_Clicked(object sender, MouseButtonEventArgs e)
		{
			if (EntitiesListBox.SelectedIndex == -1)
				return;

			var ent = (EntityBase)EntitiesListBox.SelectedItem;
			var index = EntitiesListBox.SelectedIndex;

			if (index <= 0) return;
			EntitiesListBox.SelectedIndex = -1;
			_model.Entities.Remove(ent);
			if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift) //Keyboard.IsKeyDown(Key.LeftShift))
			{
				_model.Entities.Insert(0, ent);
				EntitiesListBox.SelectedIndex = 0;
			}
			else
			{
				_model.Entities.Insert(--index, ent);
				EntitiesListBox.SelectedIndex = index;
			}
		}

		private void MoveSelectedEntityDownBtn_Clicked(object sender, MouseButtonEventArgs e)
		{
			if (EntitiesListBox.SelectedIndex == -1)
				return;
			var ent = (EntityBase)EntitiesListBox.SelectedItem;
			var index = EntitiesListBox.SelectedIndex;

			if (index == _model.Entities.Count - 1) return;
			EntitiesListBox.SelectedIndex = -1;
			_model.Entities.Remove(ent);

			if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
			{
				var ind = _model.Entities.Count;
				_model.Entities.Insert(ind, ent);
				EntitiesListBox.SelectedIndex = ind;
			}
			else
			{
				_model.Entities.Insert(++index, ent);
				EntitiesListBox.SelectedIndex = index;
			}
		}

		private void GenerateButton_Clicked(object sender, RoutedEventArgs e)
		{
			SummonCommandOutputTxtBx.Text = _model.GenerateSummon();
		}

		private void CopyButton_Clicked(object sender, RoutedEventArgs e)
		{
			try
			{
				Clipboard.SetText(SummonCommandOutputTxtBx.Text, TextDataFormat.Text);
			}
			catch (Exception)
			{
				Trace.WriteLine("Clipboard failed.");
			}
		}

		private void EntitiesListBox_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			switch (e.Key)
			{
				case Key.Up:
					MoveSelectedEntityUpBtn_Clicked(this, null);
					e.Handled = true;
					break;
				case Key.Down:
					MoveSelectedEntityDownBtn_Clicked(this, null);
					e.Handled = true;
					break;
				case Key.Delete:
					DeleteSelectedEntityButton_Clicked(this, null);
					e.Handled = true;
					break;
			}
		}

		EntityTypes _lastEntity = EntityTypes.NoEnt;
		private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (EntitiesListBox.SelectedItem != null)
			{
				var ent = (EntityBase)EntitiesListBox.SelectedItem;

				if (_lastEntity != ent.Type)
				{
					EditStackPanel.Children.Clear();

					GenControls(ent);
				}

				_lastEntity = ent.Type;
			}
			else
			{
				EditStackPanel.Children.Clear();
				_lastEntity = EntityTypes.Zombie + 1;
			}
		}

		private void GenControls(EntityBase ent)
		{
			var dict = new Dictionary<string, List<DisplayOption>>();

			#region Extract Options

			ExtractOptions(ent, dict);

			#endregion

			#region Add Groups

			foreach (var str in dict.Keys)
			{
				EditStackPanel.Children.Add(OptionsGenerator.AddGroup(str, dict));
			}

			#endregion
		}

		private static void ExtractOptions(EntityBase ent, IDictionary<string, List<DisplayOption>> dict)
		{
			var props = ent.GetType().GetPropertiesSorted();
			foreach (var info in props.Reverse())
			{
				//info
				if (!Attribute.IsDefined(info, typeof(EntityDescriptorAttribute))) continue;
				var prop = (EntityDescriptorAttribute)info.GetCustomAttribute(typeof(EntityDescriptorAttribute));
				if (!dict.ContainsKey(prop.Category))
					dict.Add(prop.Category, new List<DisplayOption>());

				object min = null, max = null;
				var multiline = Attribute.IsDefined(info, typeof(MultilineStringAttribute));

				if (Attribute.IsDefined(info, typeof(MinMaxAttribute)))
				{
					var att = (MinMaxAttribute)info.GetCustomAttribute(typeof(MinMaxAttribute));
					min = att.Minimum;
					max = att.Maximum;
				}

				dict[prop.Category].Insert(0,
					new DisplayOption(prop.Name, info.Name, info.PropertyType, ent, prop.Description, min, max, multiline, prop.IsEnabledPath, prop.FixedSize, prop.DataGridRowHeaderPath));
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var etype = (EntityTypes)EntityTypeComboBox.SelectedValue;

			var props = etype.GetType().GetMember(etype.ToString())[0].GetCustomAttributes(typeof(ClassLinkAttribute));
			var attributes = props as IList<Attribute> ?? props.ToList();
			var eb = attributes.Cast<ClassLinkAttribute>().FirstOrDefault();
			if (eb != null)
				_model.Entities.Insert(0, (EntityBase)Activator.CreateInstance(eb.LinkType));
		}

		private void AboutMenuItem_Click(object sender, RoutedEventArgs e)
		{
			// TODO
		}

		private void CommandListDialogButton_Clicked(object sender, RoutedEventArgs e)
		{
			// TODO
		}
	}
}
