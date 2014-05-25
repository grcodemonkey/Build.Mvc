using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using Build.Mvc.Html;

namespace Build.Mvc.TwitterBootstrap
{
    /// <summary>
    /// </summary>
    public static class ExtensionsForTwitterBoostrap
    {
        /// <summary>
        /// </summary>
        public static IBtnBuilder Btn(this HtmlHelper html, string buttonText = null)
        {
            return new BtnBuilder().Val(buttonText);
        }

        /// <summary>
        /// </summary>
        public static ILabelBuilder BuildControlLabel(this HtmlHelper html, string expression, string labelText = null)
        {
            return html.BuildLabel(expression, labelText).AddClass("control-label");
        }

        /// <summary>
        /// </summary>
        public static ILabelBuilder BuildControlLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string labelText = null)
        {
            return html.BuildLabelFor(expression, labelText).AddClass("control-label");
        }

        /// <summary>
        /// </summary>
        public static IBtnBuilder DropDownToggle(this IBtnBuilder builder, bool dropDownToggle = true)
        {
            return builder.Prop("__dropDownToggle", dropDownToggle);
        }

        /// <summary>
        /// </summary>
        public static IBtnBuilder Glyph(this IBtnBuilder builder, params string[] glyphs)
        {
            return SetGlyph(builder, "__glyphLeft", glyphs);
        }

        /// <summary>
        /// </summary>
        public static IBtnBuilder Link(this IBtnBuilder builder)
        {
            return builder.Prop("tagName", "a");
        }

        /// <summary>
        /// </summary>
        public static IBtnBuilder LinkBtn(this HtmlHelper html, string buttonText = null)
        {
            return html.Btn(buttonText).Link();
        }

        /// <summary>
        /// </summary>
        public static IBtnBuilder RightGlyph(this IBtnBuilder builder, params string[] glyphs)
        {
            return SetGlyph(builder, "__glyphRight", glyphs);
        }

        /// <summary>
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