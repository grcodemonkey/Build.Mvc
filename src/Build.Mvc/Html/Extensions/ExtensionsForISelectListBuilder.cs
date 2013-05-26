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
    using System.Web.Mvc;

    /// <summary>
    /// </summary>
    public static class ExtensionsForISelectListBuilder
    {
        /// <summary>
        /// Sets the size attribute (how many vertical items are visible when closed)
        /// </summary>
        public static TBuilder ListSize<TBuilder>(this TBuilder instance,
                                                  int value) where TBuilder : ISelectListBuilder
        {
            return instance.Attr("size", value);
        }

        /// <summary>
        /// Gets the option label
        /// </summary>
        public static string OptionLabel<TBuilder>(this TBuilder instance) where TBuilder : ISelectListBuilder
        {
            return instance.Prop<string>("optionLabel");
        }

        /// <summary>
        /// Sets the option label (the default option with no value)
        /// </summary>
        public static TBuilder OptionLabel<TBuilder>(this TBuilder instance,
                                                     string label) where TBuilder : ISelectListBuilder
        {
            return instance.Prop("optionLabel", label);
        }

        /// <summary>
        /// Gets the selectlist property.
        /// </summary>
        public static IEnumerable<SelectListItem> SelectList(this ISelectListBuilder instance)
        {
            return instance.Prop<IEnumerable<SelectListItem>>("selectlist");
        }

        /// <summary>
        /// Sets the selectlist property to the value of the <paramref name="list" />.
        /// </summary>
        public static TBuilder SelectList<TBuilder>(this TBuilder instance,
                                                    IEnumerable<SelectListItem> list) where TBuilder : ISelectListBuilder
        {
            return instance.Prop("selectlist", list);
        }

        /// <summary>
        /// Sets the selectlist property to the resulting value after it is modified by the specified <paramref name="listBuilder" /> expression.
        /// </summary>
        public static TBuilder SelectList<TBuilder>(this TBuilder instance,
                                                    Action<IList<SelectListItem>> listBuilder) where TBuilder : ISelectListBuilder
        {
            var list = new List<SelectListItem>();
            listBuilder.Invoke(list);
            return instance.SelectList(list);
        }

        /// <summary>
        /// Sets the selectlist property to the resulting value of the <paramref name="valueFactory" /> expression.
        /// </summary>
        public static TBuilder SelectList<TBuilder>(this TBuilder instance,
                                                    Func<IList<SelectListItem>> valueFactory) where TBuilder : ISelectListBuilder
        {
            return instance.SelectList(valueFactory.Invoke());
        }

        /// <summary>
        /// Sets the selectlist property to list stored in the ViewData under the specified <paramref name="viewDataKey" />.
        /// </summary>
        public static TBuilder SelectList<TBuilder>(this TBuilder instance, string viewDataKey) where TBuilder : ISelectListBuilder, IHtmlHelper
        {
            return instance.SelectList(instance.Html.ViewData[viewDataKey] as IEnumerable<SelectListItem>);
        }
    }
}