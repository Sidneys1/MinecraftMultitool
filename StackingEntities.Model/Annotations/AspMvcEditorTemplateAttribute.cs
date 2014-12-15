using System;
using System.Diagnostics;

namespace StackingEntities.Model.Annotations
{
	/// <summary>
	/// ASP.NET MVC attribute. Indicates that a parameter is an MVC editor template.
	/// Use this attribute for custom wrappers similar to
	/// <c>System.Web.Mvc.Html.EditorExtensions.EditorForModel(HtmlHelper, String)</c>
	/// </summary>
	[AttributeUsage(AttributeTargets.Parameter)]
	[Conditional("JETBRAINS_ANNOTATIONS")]
	public sealed class AspMvcEditorTemplateAttribute : Attribute { }
}