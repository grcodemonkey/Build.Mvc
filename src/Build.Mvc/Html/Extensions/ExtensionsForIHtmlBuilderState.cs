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

    /// <summary>
    /// 
    /// </summary>
    public static class ExtensionsForIHtmlBuilderState
    {
        /// <summary>
        /// Gets the id attribute [Short for Attr("id")]
        /// </summary>
        /// <returns></returns>
        public static string Id(this IHtmlBuilderState instance)
        {
            return instance.Attr<string>("id");
        }

        /// <summary>
        /// Sets the id attribute [Short for Attr("id", value)]
        /// </summary>
        /// <typeparam name="TBuilder">The type of the builder.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static TBuilder Id<TBuilder>(this TBuilder instance,
                                            string value) where TBuilder : IHtmlBuilderState
        {
            return instance.Attr("id", value);
        }

        /// <summary>
        /// Gets the name attribute [Short for Attr("name")]
        /// </summary>
        public static string Name(this IHtmlBuilderState instance)
        {
            return instance.Attr<string>("name");
        }

        /// <summary>
        /// Sets the tooltip [Short for Attr("title", value)]
        /// </summary>
        public static TBuilder Tooltip<TBuilder>(this TBuilder instance,
                                                 string value) where TBuilder : IHtmlBuilderState
        {
            return instance.Attr("title", value);
        }

        /// <summary>
        /// Sets the tab index [Short for Attr("tabindex", value)]
        /// </summary>
        public static TBuilder TabIndex<TBuilder>(this TBuilder instance,
                                                  int value) where TBuilder : IHtmlBuilderState
        {
            return instance.Attr("tabindex", value);
        }

        /// <summary>
        /// Sets the access key [Short for Attr("accesskey", value)]
        /// </summary>
        public static TBuilder AccessKey<TBuilder>(this TBuilder instance,
                                                   string value) where TBuilder : IHtmlBuilderState
        {
            return instance.Attr("accesskey", value);
        }

        /// <summary>
        /// Sets the access key [Short for Attr("alt", value)]
        /// </summary>
        public static TBuilder Alt<TBuilder>(this TBuilder instance,
                                             string value) where TBuilder : IHtmlBuilderState
        {
            return instance.Attr("alt", value);
        }
    }
}