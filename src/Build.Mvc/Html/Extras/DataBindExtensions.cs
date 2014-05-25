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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace Build.Mvc.Html.Extras
{
    /// <summary>
    /// 
    /// </summary>
    public static class DataBindExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        public const string DataBindAttributeName = "data-bind";

        /// <summary>
        /// Gets a collection of bindings.
        /// </summary>
        public static IDictionary<string, string> Bindings(this IDictionary<string, object> dictionary)
        {
            var collection = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);
            if (dictionary.ContainsKey(DataBindAttributeName))
            {
                string style = Convert.ToString(dictionary[DataBindAttributeName]);
                string[] items = style.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                Array.ForEach(items, item =>
                                         {
                                             string[] parts = item.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
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

        public static TBuilder Bind<TBuilder>(this TBuilder instance,
                                              object map) where TBuilder : IHtmlAttributes
        {
            RouteValueDictionary temp = HtmlHelper.AnonymousObjectToHtmlAttributes(map);

            IDictionary<string, string> bindings = temp.ToDictionary(item => item.Key, item => Convert.ToString(item.Value));

            return instance.Bind(bindings);
        }

        public static TBuilder Bind<TBuilder>(this TBuilder instance,
                                              string bindingName,
                                              string value) where TBuilder : IHtmlAttributes
        {
            IDictionary<string, string> bindings = instance.HtmlAttributes.Bindings();

            bindings.Set(bindingName, value);

            return instance.Bind(bindings);
        }

        public static TBuilder Bind<TBuilder>(this TBuilder instance,
                                              IDictionary<string, string> styles) where TBuilder : IHtmlAttributes
        {
            IDictionary<string, string> bindings = instance.HtmlAttributes.Bindings();

            foreach (var item in styles)
            {
                bindings.Set(item.Key, item.Value);
            }

            using (var sw = new StringWriter())
            {
                foreach (var binding in bindings)
                {
                    sw.Write("{0}:{1},", binding.Key, binding.Value);
                }
                instance.Attr(DataBindAttributeName, sw.ToString().TrimEnd(new[] { ',' }));
            }

            return instance;
        }

        public static TBuilder RemoveBinding<TBuilder>(this TBuilder instance,
                                                       string bindingName) where TBuilder : IHtmlAttributes
        {
            IDictionary<string, string> bindings = instance.HtmlAttributes.Bindings();

            return bindings.Remove(bindingName) ? instance.Bind(bindings) : instance;
        }

        public static TBuilder BindWhen<TBuilder>(this TBuilder editor,
                                                  bool condition,
                                                  string bindingName,
                                                  string value) where TBuilder : IHtmlAttributes
        {
            return condition ? editor.Bind(bindingName, value) : editor;
        }

        public static TBuilder RemoveBindingWhen<TBuilder>(this TBuilder editor,
                                                           bool condition,
                                                           string bindingName) where TBuilder : IHtmlAttributes
        {
            return condition ? editor.RemoveBinding(bindingName) : editor;
        }
    }
}