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
    using System.Collections.Generic;
    using System.Web.Mvc;

    /// <summary>
    /// Adds a variety of extensions for modifying a Builder's HTML attributes.
    /// </summary>
    public static class ExtensionsForIHtmlAttributes
    {
        /// <summary>
        ///     Sets the specified attribute name/value pair.
        /// </summary>
        public static TBuilder Attr<TBuilder>(this TBuilder instance,
                                              string attributeName,
                                              object value) where TBuilder : IHtmlAttributes
        {
            instance.HtmlAttributes.Set(attributeName, value);
            return instance;
        }

        /// <summary>
        ///     Get the specified attribute value as a string.
        /// </summary>
        public static string Attr<TBuilder>(this TBuilder instance,
                                            string attributeName) where TBuilder : IHtmlAttributes
        {
            return instance.Attr<string>(attributeName);
        }

        /// <summary>
        ///     Adds the values from an anonymous object to the builder's HTML Attribute collection.
        /// </summary>
        public static TBuilder Attr<TBuilder>(this TBuilder instance,
                                              object htmlAttributes) where TBuilder : IHtmlAttributes
        {
            return htmlAttributes == null ? instance : instance.Attr(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        ///     Gets the specified attribute value.
        /// </summary>
        public static TValue Attr<TValue>(this IHtmlAttributes instance,
                                          string attributeName)
        {
            return instance.HtmlAttributes.Get<TValue>(attributeName);
        }

        /// <summary>
        ///     Iteratively adds the values from the specified dictionary to the builder's HTML Attribute collection.  Existing keys will be replaced.
        /// </summary>
        public static TBuilder Attr<TBuilder>(this TBuilder instance,
                                              IDictionary<string, object> htmlAttributes) where TBuilder : IHtmlAttributes
        {
            if ( htmlAttributes != null && htmlAttributes.Count > 0 )
            {
                instance.HtmlAttributes.AddRange(htmlAttributes, true);
            }
            return instance;
        }

        /// <summary>
        ///     Sets the specified attribute name/value pair only when the specified <paramref name="condition"></paramref> is <c>true</c>.
        /// </summary>
        public static TBuilder AttrWhen<TBuilder>(this TBuilder editor,
                                                  bool condition,
                                                  string attributeName,
                                                  object value) where TBuilder : IHtmlAttributes
        {
            return condition ? editor.Attr(attributeName, value) : editor;
        }

        /// <summary>
        ///     Sets the specified attribute name/value pair only when it does not already exist.
        /// </summary>
        public static TBuilder DefaultAttr<TBuilder>(this TBuilder instance,
                                                     string attributeName,
                                                     object value) where TBuilder : IHtmlAttributes
        {
            if ( !instance.HtmlAttributes.ContainsKey(attributeName) )
            {
                instance.HtmlAttributes.Set(attributeName, value);
            }
            return instance;
        }

        /// <summary>
        ///     Iteratively adds the values from the specified dictionary to the builder's HTML Attribute collection.  Existing keys will not be replaced.
        /// </summary>
        public static TBuilder DefaultAttr<TBuilder>(this TBuilder instance,
                                                     IDictionary<string, object> htmlAttributes) where TBuilder : IHtmlAttributes
        {
            instance.HtmlAttributes.AddRange(htmlAttributes, false);
            return instance;
        }

        /// <summary>
        ///     Removes the specified attribute name.
        /// </summary>
        public static TBuilder RemoveAttr<TBuilder>(this TBuilder instance,
                                                    string attributeName) where TBuilder : IHtmlAttributes
        {
            if ( instance.HtmlAttributes.ContainsKey(attributeName) )
            {
                instance.HtmlAttributes.Remove(attributeName);
            }
            return instance;
        }

        /// <summary>
        ///     Removes the specified attribute name/value pair only when the specified <paramref name="condition"></paramref> is <c>true</c>.
        /// </summary>
        public static TBuilder RemoveAttrWhen<TBuilder>(this TBuilder editor,
                                                        bool condition,
                                                        string attributeName) where TBuilder : IHtmlAttributes
        {
            return condition ? editor.RemoveAttr(attributeName) : editor;
        }
    }
}