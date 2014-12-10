using System;
using System.Diagnostics;
using System.Text;
using System.Windows;
using StackingEntities.Model.Helpers;
using StackingEntities.Model.Items;

namespace StackingEntities.Desktop.View.Windows
{
	/// <summary>
	/// Interaction logic for GiveGeneratorDialog.xaml
	/// </summary>
	public partial class GiveGeneratorDialog
	{
		private Item _context;
		public GiveGeneratorDialog()
		{
			InitializeComponent();
			_context = (Item) DataContext;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var b = new StringBuilder();

			b.AppendFormat("/give {0} {1} {2} {3} ", TargetTextBox.Text.EscapeJsonString(), _context.Id.EscapeJsonString(), CountTextBox.Value, IdTextBox.Value);

			var b2 = new StringBuilder();

			foreach (var jsonAble in _context.Tag)
			{
				b2.Append(jsonAble.GenerateJson(true));
			}
			if (b2.Length > 0 && b2[b2.Length - 1] == ',')
				b2.Remove(b2.Length - 1, 1);

			if (b2.Length > 0)
				b.AppendFormat("{{{0}}}", b2);

			TextBlock.Text = b.ToString();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			try
			{
				Clipboard.SetText(TextBlock.Text, TextDataFormat.Text);
			}
			catch (Exception)
			{
				Trace.WriteLine("Clipboard failed.");
			}
		}
	}
}
