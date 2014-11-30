using System.Text;

namespace StackingEntities
{
	public static class JsonTools
	{
		public static string EscapeStringValue(string value)
		{
			const char BACK_SLASH = '\\';
			const char SLASH = '/';
			const char DBL_QUOTE = '"';

			const char RET = '\r';

			var output = new StringBuilder(value.Length);
			foreach (var c in value)
			{
				switch (c)
				{
					case SLASH:
						output.AppendFormat("{0}{1}", BACK_SLASH, SLASH);
						break;

					case BACK_SLASH:
						output.AppendFormat("{0}{0}", BACK_SLASH);
						break;

					case DBL_QUOTE:
						output.AppendFormat("{0}{1}", BACK_SLASH, DBL_QUOTE);
						break;

					case RET:
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
