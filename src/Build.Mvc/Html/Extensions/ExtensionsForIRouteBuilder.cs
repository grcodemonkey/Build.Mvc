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
    using System.Web.Routing;

    using JetBrains.Annotations;

    /// <summary>
    /// </summary>
    public static class ExtensionsForIRouteBuilder
    {
        public static TBuilder ActionName<TBuilder>(this TBuilder instance,
                                                    [AspMvcAction] string action) where TBuilder : IRouteBuilder
        {
            instance.RouteValues["action"] = action;
            return instance;
        }

        public static TBuilder AreaName<TBuilder>(this TBuilder instance,
                                                  [AspMvcArea] string area) where TBuilder : IRouteBuilder
        {
            instance.RouteValues["area"] = area;
            return instance;
        }

        public static TBuilder AreaRoute<TBuilder>(this TBuilder instance,
                                                   [AspMvcArea] string area,
                                                   [AspMvcController] string controller = null,
                                                   [AspMvcAction] string action = null,
                                                   object id = null) where TBuilder : IRouteBuilder
        {
            return instance.AreaName(area).
                            When(!string.IsNullOrEmpty(controller), x => instance.ControllerName(controller)).
                            When(!string.IsNullOrEmpty(action), x => instance.ActionName(action)).
                            When(id != null, x => instance.RouteValues["id"] = id);
        }

        /// <summary>
        /// Sets the "controller" route value parameter to the specified <paramref name="controller" /> name.
        /// </summary>
        public static TBuilder ControllerName<TBuilder>(this TBuilder instance,
                                                        [AspMvcController] string controller) where TBuilder : IRouteBuilder
        {
            instance.RouteValues["controller"] = controller;
            return instance;
        }

        public static TBuilder ControllerRoute<TBuilder>(this TBuilder instance,
                                                         [AspMvcController] string controller,
                                                         [AspMvcAction] string action = null,
                                                         object id = null) where TBuilder : IRouteBuilder
        {
            return instance.ControllerName(controller).
                            When(!string.IsNullOrEmpty(action), x => instance.ActionName(action)).
                            When(id != null, x => instance.RouteValues["id"] = id);
        }

        /// <summary>
        /// Sets the [target="_blank"] attribute
        /// </summary>
        public static TBuilder OpenInNewWindow<TBuilder>(this TBuilder instance) where TBuilder : ILinkTargetBuilder
        {
            return instance.Target("_blank");
        }

        /// <summary>
        /// Sets the specified <paramref name="parameterName" /> in the current builder's
        /// RouteValues collection to the specified <paramref name="value" />.
        /// </summary>
        public static TBuilder Param<TBuilder>(this TBuilder instance,
                                               string parameterName,
                                               object value) where TBuilder : IRouteBuilder
        {
            instance.RouteValues[parameterName] = value;
            return instance;
        }

        /// <summary>
        /// Appends the specified <paramref name="routeValues" /> to the current builder's RouteValues collection.
        /// </summary>
        public static TBuilder Params<TBuilder>(this TBuilder instance,
                                                object routeValues,
                                                bool replaceExisting = true) where TBuilder : IRouteBuilder
        {
            return instance.Params(new RouteValueDictionary(routeValues));
        }

        /// <summary>
        /// Appends the specified <paramref name="routeValues" /> to the current builder's RouteValues collection.
        /// </summary>
        public static TBuilder Params<TBuilder>(this TBuilder instance,
                                                IEnumerable<KeyValuePair<string, object>> routeValues,
                                                bool replaceExisting = true) where TBuilder : IRouteBuilder
        {
            instance.RouteValues.AddRange(routeValues, replaceExisting);
            return instance;
        }

        /// <summary>
        /// Sets the routeName property
        /// </summary>
        public static TBuilder RouteName<TBuilder>(this TBuilder instance,
                                                   string value) where TBuilder : IRouteBuilder
        {
            return instance.Prop("routeName", value);
        }

        /// <summary>
        /// Gets the routeName property
        /// </summary>
        public static string RouteName<TBuilder>(this TBuilder instance) where TBuilder : IRouteBuilder
        {
            return instance.Prop<string>("routeName");
        }

        /// <summary>
        /// Sets the target attrbute value.
        /// </summary>
        public static TBuilder Target<TBuilder>(this TBuilder instance,
                                                string value) where TBuilder : ILinkTargetBuilder
        {
            return instance.Attr("target", value);
        }
    }
}