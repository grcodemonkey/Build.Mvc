using System;
using System.Web;
using System.Web.Mvc.Html;
using System.Web.UI.WebControls;
using Build.Mvc.Html;

namespace Build.Mvc.Helpers
{
	/// <summary>
	/// </summary>
	public static class TextBoxBuilderHelper
	{
		/// <summary>
		///     Builds the textbox.
		/// </summary>
		/// <typeparam name="TBuilder">The type of the builder.</typeparam>
		/// <param name="instance">The instance.</param>
		/// <returns></returns>
		public static IHtmlString BuildTextBox<TBuilder>(TBuilder instance) where TBuilder : ITextBoxBuilder, IHtmlHelper
		{
			TextBoxMode mode = instance.Mode();

			switch (mode)
			{
				case TextBoxMode.Password:
					return instance.Html.Password(instance.Name(), instance.Val(), instance.HtmlAttributes);
				case TextBoxMode.MultiLine:
					return instance.Html.TextArea(instance.Name(),
					                              Convert.ToString(instance.Val()),
					                              instance.Attr<int>("rows"),
					                              instance.Attr<int>("cols"),
					                              instance.HtmlAttributes);
			}

			return instance.Html.TextBox(instance.Name(), instance.Val(), instance.Format(), instance.HtmlAttributes);
		}

		/// <summary>
		///     Builds the text box.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="instance">The instance.</param>
		/// <returns></returns>
		public static IHtmlString BuildTextBoxFor<TModel, TProperty>(TextBoxBuilder<TModel, TProperty> instance)
		{
			if (instance.InitExpression == null)
			{
				return BuildTextBox(instance);
			}

			TextBoxMode mode = instance.Mode();

			switch (mode)
			{
				case TextBoxMode.Password:
					return instance.Html.PasswordFor(instance.InitExpression, instance.HtmlAttributes);
				case TextBoxMode.MultiLine:
					return instance.Html.TextAreaFor(instance.InitExpression, instance.Attr<int>("rows"), instance.Attr<int>("cols"), instance.HtmlAttributes);
				default:
					return instance.Html.TextBoxFor(instance.InitExpression, instance.Format(), instance.HtmlAttributes);
			}
		}
	}
}