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
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    public static class ClassNameExtensions
    {
        /// <summary>
        /// Gets a collection of class names.
        /// </summary>
        public static IEnumerable<string> ClassNames(this IDictionary<string, object> dictionary)
        {
            var collection = new List<string>();
            if (dictionary.ContainsKey("class"))
            {
                string value = Convert.ToString(dictionary["class"]);
                string[] items = value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                collection.AddRange(items);
            }
            return collection;
        }

        /// <summary>
        /// Determines whether the specified dictionary contains a class attribute with the specified class name.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="className">Name of the class.</param>
        /// <returns>
        /// <c>true</c> if the specified dictionary contains class; otherwise, <c>false</c>.
        /// </returns>
        public static bool ContainsClass(this IDictionary<string, object> dictionary,
                                         string className)
        {
            return dictionary.ClassNames().Contains(className, StringComparer.InvariantCulture);
        }

        /// <summary>
        /// Inserts the specified class name(s) to the beginning of the class name collection.
        /// </summary>
        public static TBuilder InsertClass<TBuilder>(this TBuilder instance,
                                                     params string[] classes) where TBuilder : IHtmlAttributes
        {
            var classNames = new List<string>();

            classNames.AddRange(classes);
            classNames.AddRange(instance.HtmlAttributes.ClassNames());

            instance.Attr("class", string.Join(" ", classNames.Distinct()));

            return instance;
        }

        /// <summary>
        /// Adds the specified class name(s).
        /// </summary>
        public static TBuilder AddClass<TBuilder>(this TBuilder instance,
                                                  params string[] classes) where TBuilder : IHtmlAttributes
        {
            var classNames = new List<string>(instance.HtmlAttributes.ClassNames());

            classNames.AddRange(classes);

            instance.Attr("class", string.Join(" ", classNames.Distinct()));

            return instance;
        }

        /// <summary>
        /// Removes the specified class name.
        /// </summary>
        public static TBuilder RemoveClass<TBuilder>(this TBuilder instance,
                                                     string className) where TBuilder : IHtmlAttributes
        {
            var classNames = new List<string>(instance.HtmlAttributes.ClassNames());


            if (classNames.Remove(className))
            {
                instance.Attr("class", string.Join(" ", classNames));
            }

            return instance;
        }

        /// <summary>
        /// Inserts the specified class name(s) to the beginning of the class name collection only when the specified condition is true.
        /// </summary>
        public static TBuilder InsertClassWhen<TBuilder>(this TBuilder editor,
                                                         bool condition,
                                                         params string[] classes) where TBuilder : IHtmlAttributes
        {
            return condition ? editor.InsertClass(classes) : editor;
        }

        /// <summary>
        /// Adds the specified class name(s) only when the specified condition is true.
        /// </summary>
        public static TBuilder AddClassWhen<TBuilder>(this TBuilder editor,
                                                      bool condition,
                                                      params string[] classes) where TBuilder : IHtmlAttributes
        {
            return condition ? editor.AddClass(classes) : editor;
        }

        /// <summary>
        /// Removes the specified class name only when the specified condition is true.
        /// </summary>
        public static TBuilder RemoveClassWhen<TBuilder>(this TBuilder editor,
                                                         bool condition,
                                                         string className) where TBuilder : IHtmlAttributes
        {
            return condition ? editor.RemoveClass(className) : editor;
        }
    }
}