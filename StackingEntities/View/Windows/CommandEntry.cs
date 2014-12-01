using System.Windows;

namespace StackingEntities.View.Windows
{
	/// <summary>
	/// Interaction logic for CommandEntry.xaml
	/// </summary>
	public partial class CommandEntry
	{
		public CommandEntry()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
			Hide();
		}
	}
}
