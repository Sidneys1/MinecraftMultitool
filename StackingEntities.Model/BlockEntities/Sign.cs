using System;
using System.Text;
using StackingEntities.Model.BlockEntities.BaseClasses;
using StackingEntities.Model.Metadata;
using StackingEntities.Model.Objects;

namespace StackingEntities.Model.BlockEntities
{
	[Serializable]
	public class Sign : BlockEntityBase
	{
		#region Properties

		[EntityDescriptor("Sign Options", "Line 1", wide:true)]
		public JsonTextElement Text1 { get; } = new JsonTextElement { Title = "Line 1" };
		[EntityDescriptor("Sign Options", "Line 2", wide: true)]
		public JsonTextElement Text2 { get; } = new JsonTextElement { Title = "Line 2" };
		[EntityDescriptor("Sign Options", "Line 3", wide: true)]
		public JsonTextElement Text3 { get; } = new JsonTextElement { Title = "Line 3" };
		[EntityDescriptor("Sign Options", "Line 4", wide: true)]
		public JsonTextElement Text4 { get; } = new JsonTextElement { Title = "Line 4" };

		#endregion

		#region Inherited

		public override string GenerateJson(bool topLevel)
		{
			var b = new StringBuilder(base.GenerateJson(false));

			var s = Text1.GenerateJson(false);
			if (!string.IsNullOrWhiteSpace(s) && s != "\"\"")
			{

				b.AppendFormat(s.StartsWith("\"") ? "Text1:{0}," : "Text1:\"{0}\",", s);
			}

			s = Text2.GenerateJson(false);
			if (!string.IsNullOrWhiteSpace(s) && s != "\"\"")
			{

				b.AppendFormat(s.StartsWith("\"") ? "Text2:{0}," : "Text2:\"{0}\",", s);
			}

			s = Text3.GenerateJson(false);
			if (!string.IsNullOrWhiteSpace(s) && s != "\"\"")
			{

				b.AppendFormat(s.StartsWith("\"") ? "Text3:{0}," : "Text3:\"{0}\",", s);
			}

			s = Text4.GenerateJson(false);
			if (!string.IsNullOrWhiteSpace(s) && s != "\"\"")
			{

				b.AppendFormat(s.StartsWith("\"") ? "Text4:{0}," : "Text4:\"{0}\",", s);
			}

			return b.ToString();
		}

		#endregion
	}
}
