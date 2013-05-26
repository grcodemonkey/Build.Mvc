using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;
using Build.Mvc.TwitterBootstrap;
using HtmlHelper = System.Web.Mvc.HtmlHelper;

namespace Build.Mvc.Html
{
	/// <summary>
	/// 
	/// </summary>
	public static class ExtensionsForTwitterBoostrap
	{
		/// <summary>
		/// 
		/// </summary>
		public static IBtnBuilder Btn(this HtmlHelper html, string buttonText = null)
		{
			return new BtnBuilder().Val(buttonText);
		}

		/// <summary>
		/// 
		/// </summary>
		public static ILabelBuilder BuildControlLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string labelText = null)
		{
			return html.BuildLabelFor(expression, labelText).AddClass("control-label");
		}

		/// <summary>
		/// Builds a Twitter Bootstrap style text box control group.
		/// </summary>
		public static IHtmlString BuildTextBoxControlGroup(this HtmlHelper html, string expression, Action<ITextBoxBuilder> textboxBuilder = null, Action<ILabelBuilder> labelBuilder = null)
		{
			using ( var writer = new HtmlWriter() )
			{
				writer.AddAttribute("class", "control-group");
				writer.RenderBeginTag("div");

				writer.Write(html.BuildLabel(expression).AddClass("control-label").BuildWith(labelBuilder));

				writer.AddAttribute("class", "controls");
				writer.RenderBeginTag("div");
				writer.Write(html.BuildTextBox(expression).BuildWith(textboxBuilder));
				writer.RenderEndTag(); // div

				writer.RenderEndTag(); // div

				return writer.ToHtml();
			}
		}

		/// <summary>
		/// Builds a Twitter Bootstrap style text box control group.
		/// </summary>
		public static IHtmlString BuildTextBoxControlGroup<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Action<ITextBoxBuilder> textboxBuilder = null, Action<ILabelBuilder> labelBuilder = null)
		{
			using ( var writer = new HtmlWriter() )
			{
				writer.AddAttribute("class", "control-group");
				writer.RenderBeginTag("div");

				writer.Write(html.BuildLabelFor(expression).AddClass("control-label").BuildWith(labelBuilder));

				writer.AddAttribute("class", "controls");
				writer.RenderBeginTag("div");
				writer.Write(html.BuildTextBoxFor(expression).BuildWith(textboxBuilder));
				writer.RenderEndTag(); // div

				writer.RenderEndTag(); // div

				return writer.ToHtml();
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public static IBtnBuilder DropDownToggle(this IBtnBuilder builder, bool dropDownToggle = true)
		{
			return builder.Prop("__dropDownToggle", dropDownToggle);
		}

		/// <summary>
		/// 
		/// </summary>
		public static IBtnBuilder Glyph(this IBtnBuilder builder, params string[] glyphs)
		{
			return SetGlyph(builder, "__glyphLeft", glyphs);
		}

		/// <summary>
		/// 
		/// </summary>
		public static IBtnBuilder Link(this IBtnBuilder builder)
		{
			return builder.Prop("tagName", "a");
		}

		/// <summary>
		/// 
		/// </summary>
		public static IBtnBuilder LinkBtn(this HtmlHelper html, string buttonText = null)
		{
			return html.Btn(buttonText).Link();
		}

		/// <summary>
		/// 
		/// </summary>
		public static IBtnBuilder RightGlyph(this IBtnBuilder builder, params string[] glyphs)
		{
			return SetGlyph(builder, "__glyphRight", glyphs);
		}

		/// <summary>
		/// 
		/// </summary>
		public static IBtnBuilder Style(this IBtnBuilder builder, BtnStyles style)
		{
			return builder.Prop("__btnStyle", style | builder.Prop<BtnStyles>("__btnStyle"));
		}

		/// <summary>
		/// Sets the button type="submit"
		/// </summary>
		public static IBtnBuilder Submit(this IBtnBuilder builder)
		{
			return builder.Attr("type", "submit");
		}

		/// <summary>
		/// Builds a &lt;button type="submit"&gt; tag with class="btn"
		/// </summary>
		public static IBtnBuilder SubmitBtn(this HtmlHelper html, string buttonText = null)
		{
			return html.Btn(buttonText).Submit();
		}

		private static IBtnBuilder SetGlyph(IBtnBuilder builder, string key, string[] glyphs)
		{
			for (int index = 0; index < glyphs.Length; index++)
			{
				glyphs[index] = TwitterBootstrap.Glyph.GlyphPrefix + glyphs[index];
			}
			return builder.Prop(key, string.Join(" ", glyphs));
		}
	}
}
