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
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Web.Mvc;

    /// <summary>
    /// 
    /// </summary>
    public static class CssExtensions
    {
        private static readonly Regex NameExpression = new Regex("([A-Z]+(?=$|[A-Z][a-z])|[A-Z]?[a-z]+)", RegexOptions.Compiled);

        /// <summary>
        /// Converts a propertyName similar to "paddingRight" into "padding-right"
        /// </summary>
        public static string DashifyCamelCaseStyleName(string value)
        {
            value = NameExpression.Replace(value, "-$1").ToLowerInvariant();
            string[] vendorPrefixes = { "-ie", "-moz", "-webkit" };
            if (!vendorPrefixes.Any(x => value.StartsWith(x, StringComparison.OrdinalIgnoreCase)))
            {
                value = value.Trim(new[] { '-' });
            }
            return value;
        }

        /// <summary>
        /// Gets a collection of styles.
        /// </summary>
        public static IDictionary<string, string> Styles(this IDictionary<string, object> dictionary)
        {
            var collection = new Dictionary<string, string>();
            if (dictionary.ContainsKey("style"))
            {
                string style = Convert.ToString(dictionary["style"]);
                var items = style.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                Array.ForEach(items, item =>
                                         {
                                             var parts = item.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                                             if (parts.GetUpperBound(0) >= 1)
                                             {
                                                 string key = parts[0].Trim();
                                                 string value = parts[1].Trim();
                                                 collection.Add(key, value);
                                             }
                                         });
            }
            return collection;
        }

        /// <summary>
        /// Sets the specified style properties.  This typically uses the object initializer syntax similar to: New {paddingRight = "1em"}
        /// </summary>
        public static TBuilder Css<TBuilder>(this TBuilder instance,
                                             object map) where TBuilder : IHtmlBuilderState
        {
            var temp = HtmlHelper.AnonymousObjectToHtmlAttributes(map);

            var styles = temp.ToDictionary(item => DashifyCamelCaseStyleName(item.Key), item => Convert.ToString(item.Value));

            return instance.Css(styles);
        }

        /// <summary>
        /// Sets the specified style name and value.
        /// </summary>
        public static TBuilder Css<TBuilder>(this TBuilder instance,
                                             string styleName,
                                             string value) where TBuilder : IHtmlBuilderState
        {
            var currentStyles = instance.HtmlAttributes.Styles();

            currentStyles.Set(styleName, value);

            return instance.Css(currentStyles);
        }

        /// <summary>
        /// Sets the specified style properties.
        /// </summary>
        public static TBuilder Css<TBuilder>(this TBuilder instance,
                                             IDictionary<string, string> styles) where TBuilder : IHtmlBuilderState
        {
            var currentStyles = instance.HtmlAttributes.Styles();

            foreach (var item in styles)
            {
                currentStyles.Set(item.Key, item.Value);
            }

            using (var sw = new StringWriter())
            {
                foreach (var style in styles)
                {
                    sw.Write("{0}:{1};", style.Key, style.Value);
                }
                instance.Attr("style", sw.ToString().TrimEnd(new[] { ';' }));
            }

            return instance;
        }

        /// <summary>
        /// Removes the specified CSS name.
        /// </summary>
        public static TBuilder RemoveCss<TBuilder>(this TBuilder instance,
                                                   string styleName) where TBuilder : IHtmlBuilderState
        {
            var styles = instance.HtmlAttributes.Styles();

            return styles.Remove(styleName) ? instance.Css(styles) : instance;
        }

        /// <summary>
        /// Sets the specified CSS style name only when the specified condition is true.
        /// </summary>
        public static TBuilder CssWhen<TBuilder>(this TBuilder editor,
                                                 bool condition,
                                                 string styleName,
                                                 string value) where TBuilder : IHtmlBuilderState
        {
            return condition ? editor.Css(styleName, value) : editor;
        }

        /// <summary>
        /// Removes the specified CSS style name only when the specified condition is true.
        /// </summary>
        public static TBuilder RemoveCssWhen<TBuilder>(this TBuilder editor,
                                                       bool condition,
                                                       string styleName) where TBuilder : IHtmlBuilderState
        {
            return condition ? editor.RemoveCss(styleName) : editor;
        }
    }
}