using System;
using System.Diagnostics;

namespace StackingEntities.Annotations
{
	/// <summary>
	/// ASP.NET MVC attribute. Indicates that a parameter is an MVC Master. Use this attribute
	/// for custom wrappers similar to <c>System.Web.Mvc.Controller.View(String, String)</c>
	/// </summary>
	[AttributeUsage(AttributeTargets.Parameter)]
	[Conditional("JETBRAINS_ANNOTATIONS")]
	public sealed class AspMvcMasterAttribute : Attribute { }
}