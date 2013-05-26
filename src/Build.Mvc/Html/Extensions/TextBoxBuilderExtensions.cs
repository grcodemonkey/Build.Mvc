// -----------------------------------------------------------------------------
// Designed by geeks in Michigan.  Assembled by a compiler near you.
// -----------------------------------------------------------------------------
// 
// Copyright (c) 2011-2012 Jeremy Bell, Laurence Blackledge
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 
// It is pitch black. You are likely to be eaten by a grue.
// 

namespace Build.Mvc.Html
{
    using System.Web.UI.WebControls;

    /// <summary>
    /// 
    /// </summary>
    public static class TextBoxBuilderExtensions
    {
        /// <summary>
        /// Sets the format option of the Html.Textbox helper method.
        /// </summary>
        public static TBuilder Format<TBuilder>(this TBuilder instance,
                                                string value) where TBuilder : ITextBoxBuilder
        {
            return instance.Prop("format", value);
        }

        /// <summary>
        /// Gets the format option of the Html.Textbox helper method.
        /// </summary>
        public static string Format<TBuilder>(this TBuilder instance) where TBuilder : ITextBoxBuilder
        {
            return instance.Prop<string>("format");
        }

        /// <summary>
        /// Sets the upper valid range.
        /// </summary>
        /// <typeparam name="TBuilder">The type of the builder.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static TBuilder Max<TBuilder>(this TBuilder instance,
                                             object value) where TBuilder : ITextBoxBuilder
        {
            return instance.Attr("max", value);
        }

        /// <summary>
        /// Gets the max attribute.
        /// </summary>
        /// <returns></returns>
        public static object Max<TBuilder>(this TBuilder instance) where TBuilder : ITextBoxBuilder
        {
            return instance.Attr<object>("max");
        }

        /// <summary>
        /// Gets the maxlength attribute.
        /// </summary>
        /// <returns></returns>
        public static int MaxLength<TBuilder>(this TBuilder instance) where TBuilder : ITextBoxBuilder
        {
            return instance.Attr<int>("maxlength");
        }

        /// <summary>
        /// Sets the max length.
        /// </summary>
        /// <typeparam name="TBuilder">The type of the builder.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static TBuilder MaxLength<TBuilder>(this TBuilder instance,
                                                   int value) where TBuilder : ITextBoxBuilder
        {
            return instance.Attr("maxlength", value);
        }

        /// <summary>
        /// Gets the min attribute.
        /// </summary>
        /// <returns></returns>
        public static object Min<TBuilder>(this TBuilder instance) where TBuilder : ITextBoxBuilder
        {
            return instance.Attr<object>("min");
        }

        /// <summary>
        /// Sets the lower valid range.
        /// </summary>
        /// <typeparam name="TBuilder">The type of the builder.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static TBuilder Min<TBuilder>(this TBuilder instance,
                                             object value) where TBuilder : ITextBoxBuilder
        {
            return instance.Attr("min", value);
        }

        /// <summary>
        /// Gets the minlength attribute.
        /// </summary>
        /// <returns></returns>
        public static int Minlength<TBuilder>(this TBuilder instance) where TBuilder : ITextBoxBuilder
        {
            return instance.Attr<int>("minlength");
        }

        /// <summary>
        /// Sets the minimum valid length.
        /// </summary>
        /// <typeparam name="TBuilder">The type of the builder.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static TBuilder MinLength<TBuilder>(this TBuilder instance,
                                                   int value) where TBuilder : ITextBoxBuilder
        {
            return instance.Attr("minlength", value);
        }

        /// <summary>
        /// Gets the <see cref="TextBoxMode" /> property
        /// </summary>
        public static TextBoxMode Mode<TBuilder>(this TBuilder instance) where TBuilder : ITextBoxBuilder
        {
            return instance.Prop<TextBoxMode>("mode");
        }

        /// <summary>
        /// Sets the render mode to Multiline.
        /// </summary>
        /// <returns></returns>
        public static TBuilder Multiline<TBuilder>(this TBuilder instance) where TBuilder : ITextBoxBuilder
        {
            return instance.Prop("mode", TextBoxMode.MultiLine);
        }

        /// <summary>
        /// Sets the render mode to Multiline.
        /// </summary>
        /// <returns></returns>
        public static TBuilder Multiline<TBuilder>(this TBuilder instance,
                                                   int rows,
                                                   int cols) where TBuilder : ITextBoxBuilder
        {
            return instance.Multiline().Size(rows, cols);
        }

        /// <summary>
        /// Sets the render mode to Password.
        /// </summary>
        public static TBuilder Password<TBuilder>(this TBuilder instance) where TBuilder : ITextBoxBuilder
        {
            return instance.Prop("mode", TextBoxMode.Password);
        }

        /// <summary>
        /// Gets the pattern attribute.
        /// </summary>
        /// <returns></returns>
        public static string Pattern<TBuilder>(this TBuilder instance) where TBuilder : ITextBoxBuilder
        {
            return instance.Attr("pattern");
        }

        /// <summary>
        /// Requires that the text box value match the specified regular expression pattern.
        /// Example: "^\d{3}\-\d{2}\-\d{4}$" would match a social security number.
        /// </summary>
        /// <typeparam name="TBuilder">The type of the builder.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static TBuilder Pattern<TBuilder>(this TBuilder instance,
                                                 string value) where TBuilder : ITextBoxBuilder
        {
            return instance.Attr("pattern", value);
        }

        /// <summary>
        /// Sets the specified placeholder text.
        /// </summary>
        public static TBuilder Placeholder<TBuilder>(this TBuilder instance,
                                                     string value) where TBuilder : ITextBoxBuilder
        {
            return instance.Attr("placeholder", value);
        }

        /// <summary>
        /// Gets the specified placeholder text.
        /// </summary>
        /// <returns></returns>
        public static string Placeholder<TBuilder>(this TBuilder instance) where TBuilder : ITextBoxBuilder
        {
            return instance.Attr("placeholder");
        }

        /// <summary>
        /// Sets the render mode to Singleline.
        /// </summary>
        /// <returns></returns>
        public static TBuilder Singleline<TBuilder>(this TBuilder instance) where TBuilder : ITextBoxBuilder
        {
            return instance.Prop("mode", TextBoxMode.SingleLine);
        }

        /// <summary>
        /// Sets the textbox size. [Short for Attr("size", value)]
        /// </summary>
        /// <typeparam name="TBuilder">The type of the builder.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static TBuilder Size<TBuilder>(this TBuilder instance,
                                              int value) where TBuilder : ITextBoxBuilder
        {
            return instance.Attr("size", value);
        }

        /// <summary>
        /// Sets the textarea size. [Short for Attr("rows", rows).Attr("cols", cols)]
        /// </summary>
        public static TBuilder Size<TBuilder>(this TBuilder instance,
                                              int rows,
                                              int columns) where TBuilder : ITextBoxBuilder
        {
            return instance.Attr("rows", rows).Attr("cols", columns);
        }

        /// <summary>
        /// Sets the textbox step. [Short for Attr("step", value)]
        /// </summary>
        public static TBuilder Step<TBuilder>(this TBuilder instance,
                                              object value) where TBuilder : ITextBoxBuilder
        {
            return instance.Attr("step", value);
        }

		/// <summary>
		/// Sets the vcard_name attribute.
		/// </summary>
		public static TBuilder VCard<TBuilder>(this TBuilder instance, string vcardName) where TBuilder : IHtmlAttributes
		{
			return instance.Attr("vcard_name", vcardName);
		}
    }
}