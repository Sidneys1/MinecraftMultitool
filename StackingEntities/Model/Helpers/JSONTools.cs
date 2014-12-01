using System.Text;

namespace StackingEntities.Model.Helpers
{
	public static class JsonTools
	{
		public static string EscapeJsonString(this string value)
		{
			const char backSlash = '\\';
			const char slash = '/';
			const char dblQuote = '"';

			const char ret = '\r';

			var output = new StringBuilder(value.Length);
			foreach (var c in value)
			{
				switch (c)
				{
					case slash:
						output.AppendFormat("{0}{1}", backSlash, slash);
						break;

					case backSlash:
						output.AppendFormat("{0}{0}", backSlash);
						break;

					case dblQuote:
						output.AppendFormat("{0}{1}", backSlash, dblQuote);
						break;

					case ret:
						break;

					//case NEW:
					//	output.Append("\\n");
					//	break;

					default:
						output.Append(c);
						break;
				}
			}

			return output.ToString();
		}
	}
}
