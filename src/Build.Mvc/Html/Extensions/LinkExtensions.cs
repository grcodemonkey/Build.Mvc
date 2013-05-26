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
    using System.Web.Routing;

    using JetBrains.Annotations;

    /// <summary>
    /// Adds builder extensions for Html.ActionLink and Html.RouteLink
    /// </summary>
    public static class LinkExtensions
    {
        /// <summary>
        /// Builds the action link.
        /// </summary>
        public static INavigationBuilder BuildActionLink(this HtmlHelper htmlHelper,
                                                         string linkText,
                                                         Action<INavigationBuilder> builderExpression)
        {
            INavigationBuilder builder = htmlHelper.BuildActionLink(linkText);
            if ( builderExpression != null )
            {
                builderExpression.Invoke(builder);
            }
            return builder;
        }

        /// <summary>
        /// Builds the action link.
        /// </summary>
        public static INavigationBuilder BuildActionLink(this HtmlHelper htmlHelper,
                                                         string linkText)
        {
            return new LinkBuilder
                       {
                           Html = htmlHelper,
                           LinkText = linkText
                       };
        }

        /// <summary>
        /// Builds the action link.
        /// </summary>
        public static INavigationBuilder BuildActionLink(this HtmlHelper htmlHelper,
                                                         string linkText,
                                                         [AspMvcAction] string actionName)
        {
            return new LinkBuilder
                       {
                           Html = htmlHelper,
                           LinkText = linkText
                       }.
                ActionName(actionName);
        }

        /// <summary>
        /// Builds the action link.
        /// </summary>
        public static INavigationBuilder BuildActionLink(this HtmlHelper htmlHelper,
                                                         string linkText,
                                                         [AspMvcAction] string actionName,
                                                         object routeValues)
        {
            return new LinkBuilder
                       {
                           Html = htmlHelper,
                           LinkText = linkText,
                           RouteValues = new RouteValueDictionary(routeValues)
                       }.
                ActionName(actionName);
        }

        /// <summary>
        /// Builds the action link.
        /// </summary>
        public static INavigationBuilder BuildActionLink(this HtmlHelper htmlHelper,
                                                         string linkText,
                                                         [AspMvcAction] string actionName,
                                                         [AspMvcController] string controllerName)
        {
            return new LinkBuilder
                       {
                           Html = htmlHelper,
                           LinkText = linkText
                       }.
                ActionName(actionName).
                ControllerName(controllerName);
        }

        /// <summary>
        /// Builds the action link.
        /// </summary>
        public static INavigationBuilder BuildActionLink(this HtmlHelper htmlHelper,
                                                         string linkText,
                                                         [AspMvcAction] string actionName,
                                                         RouteValueDictionary routeValues)
        {
            return new LinkBuilder
                       {
                           Html = htmlHelper,
                           LinkText = linkText,
                           RouteValues = routeValues
                       }.ActionName(actionName);
        }

        /// <summary>
        /// Builds the action link.
        /// </summary>
        public static INavigationBuilder BuildActionLink(this HtmlHelper htmlHelper,
                                                         string linkText,
                                                         [AspMvcAction] string actionName,
                                                         object routeValues,
                                                         object htmlAttributes)
        {
            return new LinkBuilder
                       {
                           Html = htmlHelper,
                           LinkText = linkText,
                           RouteValues = new RouteValueDictionary(routeValues)
                       }.
                ActionName(actionName).
                Attr(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Builds the action link.
        /// </summary>
        public static INavigationBuilder BuildActionLink(this HtmlHelper htmlHelper,
                                                         string linkText,
                                                         [AspMvcAction] string actionName,
                                                         RouteValueDictionary routeValues,
                                                         IDictionary<string, object> htmlAttributes)
        {
            return new LinkBuilder {Html = htmlHelper, LinkText = linkText, RouteValues = routeValues}.ActionName(actionName).Attr(htmlAttributes);
        }

        /// <summary>
        /// Builds the action link.
        /// </summary>
        public static INavigationBuilder BuildActionLink(this HtmlHelper htmlHelper,
                                                         string linkText,
                                                         [AspMvcAction] string actionName,
                                                         [AspMvcController] string controllerName,
                                                         object routeValues,
                                                         object htmlAttributes)
        {
            return new LinkBuilder
                       {
                           Html = htmlHelper,
                           LinkText = linkText,
                           RouteValues = new RouteValueDictionary(routeValues)
                       }.
                ActionName(actionName).
                ControllerName(controllerName).
                Attr(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Builds the action link.
        /// </summary>
        public static INavigationBuilder BuildActionLink(this HtmlHelper htmlHelper,
                                                         string linkText,
                                                         [AspMvcAction] string actionName,
                                                         [AspMvcController] string controllerName,
                                                         RouteValueDictionary routeValues,
                                                         IDictionary<string, object> htmlAttributes)
        {
            return new LinkBuilder
                       {
                           Html = htmlHelper,
                           LinkText = linkText,
                           RouteValues = routeValues
                       }.
                ActionName(actionName).
                ControllerName(controllerName).
                Attr(htmlAttributes);
        }


        /// <summary>
        /// Builds the route link.
        /// </summary>
        public static INavigationBuilder BuildRouteLink(this HtmlHelper htmlHelper,
                                                        string linkText,
                                                        object routeValues)
        {
            return new LinkBuilder
                       {
                           Html = htmlHelper,
                           LinkText = linkText,
                           RouteValues = new RouteValueDictionary(routeValues)
                       };
        }

        /// <summary>
        /// Builds the route link.
        /// </summary>
        public static INavigationBuilder BuildRouteLink(this HtmlHelper htmlHelper,
                                                        string linkText,
                                                        string routeName)
        {
            return new LinkBuilder
                       {
                           Html = htmlHelper,
                           LinkText = linkText
                       }.
                RouteName(routeName);
        }

        /// <summary>
        /// Builds the route link.
        /// </summary>
        public static INavigationBuilder BuildRouteLink(this HtmlHelper htmlHelper,
                                                        string linkText,
                                                        RouteValueDictionary routeValues)
        {
            return new LinkBuilder
                       {
                           Html = htmlHelper,
                           LinkText = linkText,
                           RouteValues = routeValues
                       };
        }

        /// <summary>
        /// Builds the route link.
        /// </summary>
        public static INavigationBuilder BuildRouteLink(this HtmlHelper htmlHelper,
                                                        string linkText,
                                                        object routeValues,
                                                        object htmlAttributes)
        {
            return new LinkBuilder
                       {
                           Html = htmlHelper,
                           LinkText = linkText,
                           RouteValues = new RouteValueDictionary(routeValues)
                       }.
                Attr(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Builds the route link.
        /// </summary>
        public static INavigationBuilder BuildRouteLink(this HtmlHelper htmlHelper,
                                                        string linkText,
                                                        string routeName,
                                                        object routeValues)
        {
            return new LinkBuilder
                       {
                           Html = htmlHelper,
                           LinkText = linkText,
                           RouteValues = new RouteValueDictionary(routeValues)
                       }.
                RouteName(routeName);
        }

        /// <summary>
        /// Builds the route link.
        /// </summary>
        public static INavigationBuilder BuildRouteLink(this HtmlHelper htmlHelper,
                                                        string linkText,
                                                        string routeName,
                                                        RouteValueDictionary routeValues)
        {
            return new LinkBuilder
                       {
                           Html = htmlHelper,
                           LinkText = linkText,
                           RouteValues = routeValues
                       }.
                RouteName(routeName);
        }

        /// <summary>
        /// Builds the route link.
        /// </summary>
        public static INavigationBuilder BuildRouteLink(this HtmlHelper htmlHelper,
                                                        string linkText,
                                                        RouteValueDictionary routeValues,
                                                        IDictionary<string, object> htmlAttributes)
        {
            return new LinkBuilder
                       {
                           Html = htmlHelper,
                           LinkText = linkText,
                           RouteValues = routeValues
                       }.
                Attr(htmlAttributes);
        }

        /// <summary>
        /// Builds the route link.
        /// </summary>
        public static INavigationBuilder BuildRouteLink(this HtmlHelper htmlHelper,
                                                        string linkText,
                                                        string routeName,
                                                        object routeValues,
                                                        object htmlAttributes)
        {
            return new LinkBuilder
                       {
                           Html = htmlHelper,
                           LinkText = linkText,
                           RouteValues = new RouteValueDictionary(routeValues)
                       }.
                RouteName(routeName).
                Attr(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Builds the route link.
        /// </summary>
        public static INavigationBuilder BuildRouteLink(this HtmlHelper htmlHelper,
                                                        string linkText,
                                                        string routeName,
                                                        RouteValueDictionary routeValues,
                                                        IDictionary<string, object> htmlAttributes)
        {
            return new LinkBuilder
                       {
                           Html = htmlHelper,
                           LinkText = linkText,
                           RouteValues = routeValues
                       }.
                RouteName(routeName).
                Attr(htmlAttributes);
        }
    }
}