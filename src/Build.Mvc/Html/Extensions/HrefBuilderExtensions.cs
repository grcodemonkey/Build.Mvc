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

    using Build.Mvc.Helpers;

    using JetBrains.Annotations;

    /// <summary>
    /// </summary>
    public static class HrefBuilderExtensions
    {
        /// <summary>
        /// Gets the href attribute value.
        /// </summary>
        public static string Href<TBuilder>(this TBuilder instance) where TBuilder : IHrefBuilder
        {
            return instance.Attr("href");
        }

        /// <summary>
        /// Sets the href attribute value.
        /// </summary>
        public static TBuilder Href<TBuilder>(this TBuilder instance,
                                              string url) where TBuilder : IHrefBuilder
        {
            return instance.Attr("href", instance.Url().Content(url));
        }

        /// <summary>
        /// Sets the href attribute value using the specified route input to generate the URL.
        /// </summary>
        public static TBuilder HrefAction<TBuilder>(this TBuilder instance,
                                                    [AspMvcAction] string actionName) where TBuilder : IHrefBuilder
        {
            return instance.Href(instance.Url().Action(actionName));
        }

        /// <summary>
        /// Sets the href attribute value using the specified route input to generate the URL.
        /// </summary>
        public static TBuilder HrefAction<TBuilder>(this TBuilder instance,
                                                    [AspMvcAction] string actionName,
                                                    object routeValues) where TBuilder : IHrefBuilder
        {
            return instance.Href(instance.Url().Action(actionName, routeValues));
        }

        /// <summary>
        /// Sets the href attribute value using the specified route input to generate the URL.
        /// </summary>
        public static TBuilder HrefAction<TBuilder>(this TBuilder instance,
                                                    [AspMvcAction] string actionName,
                                                    [AspMvcController] string controllerName) where TBuilder : IHrefBuilder
        {
            return instance.Href(instance.Url().Action(actionName, controllerName));
        }

        /// <summary>
        /// Sets the href attribute value using the specified route input to generate the URL.
        /// </summary>
        public static TBuilder HrefAction<TBuilder>(this TBuilder instance,
                                                    [AspMvcAction] string actionName,
                                                    [AspMvcController] string controllerName,
                                                    object routeValues) where TBuilder : IHrefBuilder
        {
            return instance.Href(instance.Url().Action(actionName, controllerName, routeValues));
        }

        /// <summary>
        /// Sets the href attribute value using the specified route input to generate the URL.
        /// </summary>
        public static TBuilder HrefAction<TBuilder>(this TBuilder instance,
                                                    Func<UrlHelper, string> actionFactory) where TBuilder : IHrefBuilder
        {
            return instance.Href(actionFactory.Invoke(instance.Url()));
        }

        /// <summary>
        /// Sets the href attribute value using the specified route input to generate the URL.
        /// </summary>
        public static TBuilder HrefRoute<TBuilder>(this TBuilder instance,
                                                   object routeValues) where TBuilder : IHrefBuilder
        {
            return instance.Href(instance.Url().RouteUrl(routeValues));
        }

        /// <summary>
        /// Sets the href attribute value using the specified route input to generate the URL.
        /// </summary>
        public static TBuilder HrefRoute<TBuilder>(this TBuilder instance,
                                                   IDictionary<string, object> routeValues) where TBuilder : IHrefBuilder
        {
            return instance.Href(instance.Url().RouteUrl(routeValues));
        }

        /// <summary>
        /// Sets the href attribute value using the specified route input to generate the URL.
        /// </summary>
        public static TBuilder HrefRoute<TBuilder>(this TBuilder instance,
                                                   string routeName,
                                                   object routeValues) where TBuilder : IHrefBuilder
        {
            return instance.Href(instance.Url().RouteUrl(routeName, routeValues));
        }

        /// <summary>
        /// Sets the href attribute value using the specified route input to generate the URL.
        /// </summary>
        public static TBuilder HrefRoute<TBuilder>(this TBuilder instance,
                                                   string routeName,
                                                   IDictionary<string, object> routeValues) where TBuilder : IHrefBuilder
        {
            return instance.Href(instance.Url().RouteUrl(routeName, routeValues));
        }

        private static UrlHelper Url(this IHtmlHelper instance)
        {
            return instance.Html.Url();
        }
    }
}