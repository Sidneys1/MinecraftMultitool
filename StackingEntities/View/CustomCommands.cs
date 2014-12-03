using System.Windows.Input;

namespace StackingEntities.Desktop.View
{
	static class CustomCommands
	{
		static CustomCommands()
		{
			Exit = new RoutedCommand("Exit", typeof(CustomCommands));
		}
		public static RoutedCommand Exit { get; }
	}
}
