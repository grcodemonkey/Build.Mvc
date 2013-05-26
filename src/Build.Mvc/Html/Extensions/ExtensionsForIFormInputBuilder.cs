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
    /// <summary>
    /// 
    /// </summary>
    public static class ExtensionsForIFormInputBuilder
    {
        /// <summary>
        /// HTML5 - The autofocus attribute specifies that a field should automatically get focus when a page is loaded.
        /// </summary>
        public static TBuilder Autofocus<TBuilder>(this TBuilder instance) where TBuilder : IFormInputBuilder
        {
            return instance.Attr("autofocus", "autofocus");
        }

        /// <summary>
        /// Sets the value of this control to the resulting formatted string.
        /// </summary>
        public static TBuilder FormatVal<TBuilder>(this TBuilder instance,
                                                   string format,
                                                   params object[] args) where TBuilder : IFormInputBuilder
        {
            if (args == null || args.Length == 0)
            {
                return instance.Val(format);
            }
            return instance.Val(string.Format(format, args));
        }

        /// <summary>
        /// Sets the height attribute value.
        /// </summary>
        public static TBuilder Height<TBuilder>(this TBuilder instance,
                                                int value) where TBuilder : IFormInputBuilder
        {
            return instance.Attr("height", value);
        }

        /// <summary>
        /// Sets the height attribute value.
        /// </summary>
        public static TBuilder Height<TBuilder>(this TBuilder instance,
                                                string value) where TBuilder : IFormInputBuilder
        {
            return instance.Attr("height", value);
        }

        /// <summary>
        /// Sets the name attribute.  If the id attribute is blank, then the id attribute is also set to the name.
        /// </summary>
        public static TBuilder Named<TBuilder>(this TBuilder instance,
                                               string name) where TBuilder : IFormInputBuilder
        {
            if (string.IsNullOrEmpty(instance.Id()))
            {
                instance.Id(name);
            }
            return instance.Attr("name", name);
        }

        /// <summary>
        /// HTML5 - When present, it specifies that an input field must be filled out before submitting the form.
        /// </summary>
        public static TBuilder Required<TBuilder>(this TBuilder instance) where TBuilder : IFormInputBuilder
        {
            return instance.Attr("required", "required");
        }
        /// <summary>
        /// Gets the value.
        /// </summary>
        public static object Val(this IFormInputBuilder instance)
        {
            return instance.Prop<object>("value");
        }

        /// <summary>
        /// Sets the value for this control.
        /// </summary>
        public static TBuilder Val<TBuilder>(this TBuilder instance,
                                             object value) where TBuilder : IFormInputBuilder
        {
            return instance.Prop("value", value);
        }
        /// <summary>
        /// Sets the width attribute value.
        /// </summary>
        public static TBuilder Width<TBuilder>(this TBuilder instance,
                                               int value) where TBuilder : IFormInputBuilder
        {
            return instance.Attr("width", value);
        }

        /// <summary>
        /// Sets the width attribute value.
        /// </summary>
        public static TBuilder Width<TBuilder>(this TBuilder instance,
                                               string value) where TBuilder : IFormInputBuilder
        {
            return instance.Attr("width", value);
        }
    }
}