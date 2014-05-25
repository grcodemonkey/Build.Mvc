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
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using JetBrains.Annotations;

namespace Build.Mvc.Html
{
    public static class FormExtensions
    {
        #region BuildForm

        public static IMvcFormBuilder BuildForm(this HtmlHelper htmlHelper,
            Action<IMvcFormBuilder> builderExpression)
        {
            IMvcFormBuilder builder = htmlHelper.BuildForm();
            if (builderExpression != null)
            {
                builderExpression.Invoke(builder);
            }
            return builder;
        }

        public static IMvcFormBuilder BuildForm(this HtmlHelper htmlHelper)
        {
            return new MvcFormBuilder {Html = htmlHelper};
        }

        public static IMvcFormBuilder BuildForm(this HtmlHelper htmlHelper,
            object routeValues)
        {
            return htmlHelper.BuildForm(null, null, new RouteValueDictionary(routeValues), FormMethod.Post, new RouteValueDictionary());
        }

        public static IMvcFormBuilder BuildForm(this HtmlHelper htmlHelper,
            RouteValueDictionary routeValues)
        {
            return htmlHelper.BuildForm(null, null, routeValues, FormMethod.Post, new RouteValueDictionary());
        }

        /// <summary>
        /// Builds the form.
        /// </summary>
        /// <param name="htmlHelper"> The HTML helper. </param>
        /// <param name="actionName"> Name of the action. </param>
        /// <returns> </returns>
        public static IMvcFormBuilder BuildForm(this HtmlHelper htmlHelper,
            string actionName)
        {
            return htmlHelper.BuildForm(actionName, null);
        }

        public static IMvcFormBuilder BuildForm(this HtmlHelper htmlHelper,
            string actionName,
            string controllerName)
        {
            return htmlHelper.BuildForm(actionName, controllerName, new RouteValueDictionary(), FormMethod.Post, new RouteValueDictionary());
        }

        public static IMvcFormBuilder BuildForm(this HtmlHelper htmlHelper,
            [AspMvcAction] string actionName,
            [AspMvcController] string controllerName,
            object routeValues)
        {
            return htmlHelper.BuildForm(actionName, controllerName, new RouteValueDictionary(routeValues), FormMethod.Post, new RouteValueDictionary());
        }

        public static IMvcFormBuilder BuildForm(this HtmlHelper htmlHelper,
            [AspMvcAction] string actionName,
            [AspMvcController] string controllerName,
            FormMethod method)
        {
            return htmlHelper.BuildForm(actionName, controllerName, new RouteValueDictionary(), method, new RouteValueDictionary());
        }

        public static IMvcFormBuilder BuildForm(this HtmlHelper htmlHelper,
            [AspMvcAction] string actionName,
            [AspMvcController] string controllerName,
            RouteValueDictionary routeValues)
        {
            return htmlHelper.BuildForm(actionName, controllerName, routeValues, FormMethod.Post, new RouteValueDictionary());
        }

        public static IMvcFormBuilder BuildForm(this HtmlHelper htmlHelper,
            [AspMvcAction] string actionName,
            [AspMvcController] string controllerName,
            object routeValues,
            FormMethod method)
        {
            return htmlHelper.BuildForm(actionName, controllerName, new RouteValueDictionary(routeValues), method, new RouteValueDictionary());
        }

        public static IMvcFormBuilder BuildForm(this HtmlHelper htmlHelper,
            [AspMvcAction] string actionName,
            [AspMvcController] string controllerName,
            FormMethod method,
            IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.BuildForm(actionName, controllerName, new RouteValueDictionary(), method, htmlAttributes);
        }

        public static IMvcFormBuilder BuildForm(this HtmlHelper htmlHelper,
            [AspMvcAction] string actionName,
            [AspMvcController] string controllerName,
            FormMethod method,
            object htmlAttributes)
        {
            return htmlHelper.BuildForm(actionName, controllerName, new RouteValueDictionary(), method, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static IMvcFormBuilder BuildForm(this HtmlHelper htmlHelper,
            [AspMvcAction] string actionName,
            [AspMvcController] string controllerName,
            RouteValueDictionary routeValues,
            FormMethod method)
        {
            return htmlHelper.BuildForm(actionName, controllerName, routeValues, method, new RouteValueDictionary());
        }

        public static IMvcFormBuilder BuildForm(this HtmlHelper htmlHelper,
            [AspMvcAction] string actionName,
            [AspMvcController] string controllerName,
            object routeValues,
            FormMethod method,
            object htmlAttributes)
        {
            return htmlHelper.BuildForm(actionName, controllerName, new RouteValueDictionary(routeValues), method, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static IMvcFormBuilder BuildForm(this HtmlHelper htmlHelper,
            [AspMvcAction] string actionName,
            [AspMvcController] string controllerName,
            RouteValueDictionary routeValues,
            FormMethod method,
            IDictionary<string, object> htmlAttributes)
        {
            return new MvcFormBuilder {Html = htmlHelper, RouteValues = routeValues, FormMethod = method}.ActionName(actionName).ControllerName(controllerName).Attr(htmlAttributes);
        }

        #endregion

        #region BuildRouteForm

        public static IMvcFormBuilder BuildRouteForm(this HtmlHelper htmlHelper,
            object routeValues)
        {
            return htmlHelper.BuildRouteForm(null, new RouteValueDictionary(routeValues), FormMethod.Post, new RouteValueDictionary());
        }

        public static IMvcFormBuilder BuildRouteForm(this HtmlHelper htmlHelper,
            string routeName)
        {
            return htmlHelper.BuildRouteForm(routeName, new RouteValueDictionary(), FormMethod.Post, new RouteValueDictionary());
        }

        public static IMvcFormBuilder BuildRouteForm(this HtmlHelper htmlHelper,
            RouteValueDictionary routeValues)
        {
            return htmlHelper.BuildRouteForm(null, routeValues, FormMethod.Post, new RouteValueDictionary());
        }

        public static IMvcFormBuilder BuildRouteForm(this HtmlHelper htmlHelper,
            string routeName,
            object routeValues)
        {
            return htmlHelper.BuildRouteForm(routeName, new RouteValueDictionary(routeValues), FormMethod.Post, new RouteValueDictionary());
        }

        public static IMvcFormBuilder BuildRouteForm(this HtmlHelper htmlHelper,
            string routeName,
            FormMethod method)
        {
            return htmlHelper.BuildRouteForm(routeName, new RouteValueDictionary(), method, new RouteValueDictionary());
        }

        public static IMvcFormBuilder BuildRouteForm(this HtmlHelper htmlHelper,
            string routeName,
            RouteValueDictionary routeValues)
        {
            return htmlHelper.BuildRouteForm(routeName, routeValues, FormMethod.Post, new RouteValueDictionary());
        }

        public static IMvcFormBuilder BuildRouteForm(this HtmlHelper htmlHelper,
            string routeName,
            object routeValues,
            FormMethod method)
        {
            return htmlHelper.BuildRouteForm(routeName, new RouteValueDictionary(routeValues), method, new RouteValueDictionary());
        }

        public static IMvcFormBuilder BuildRouteForm(this HtmlHelper htmlHelper,
            string routeName,
            FormMethod method,
            IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.BuildRouteForm(routeName, new RouteValueDictionary(), method, htmlAttributes);
        }

        public static IMvcFormBuilder BuildRouteForm(this HtmlHelper htmlHelper,
            string routeName,
            FormMethod method,
            object htmlAttributes)
        {
            return htmlHelper.BuildRouteForm(routeName, new RouteValueDictionary(), method, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static IMvcFormBuilder BuildRouteForm(this HtmlHelper htmlHelper,
            string routeName,
            RouteValueDictionary routeValues,
            FormMethod method)
        {
            return htmlHelper.BuildRouteForm(routeName, routeValues, method, new RouteValueDictionary());
        }

        public static IMvcFormBuilder BuildRouteForm(this HtmlHelper htmlHelper,
            string routeName,
            object routeValues,
            FormMethod method,
            object htmlAttributes)
        {
            return htmlHelper.BuildRouteForm(routeName, new RouteValueDictionary(routeValues), method, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static IMvcFormBuilder BuildRouteForm(this HtmlHelper htmlHelper,
            string routeName,
            RouteValueDictionary routeValues,
            FormMethod method,
            IDictionary<string, object> htmlAttributes)
        {
            return new MvcFormBuilder {Html = htmlHelper, RouteValues = routeValues, FormMethod = method}.RouteName(routeName).Attr(htmlAttributes).IncludeImplicitMvcValues(false);
        }

        #endregion

        #region FormBuilderContext

        private const string FormBuilderContextKey = "__build.mvc__FormBuilderContext";

        public static void SetFormBuilderContext(this HtmlHelper htmlHelper, FormBuilderContext builderContext)
        {
            htmlHelper.ViewContext.HttpContext.Items[FormBuilderContextKey] = builderContext;
        }

        public static void UpdateFormBuilderContext(this HtmlHelper htmlHelper, Action<FormBuilderContext> updateAction)
        {
            if (updateAction == null)
            {
                return;
            }
            FormBuilderContext formBuilderContext = htmlHelper.GetFormBuilderContext();
            updateAction(formBuilderContext);
            htmlHelper.SetFormBuilderContext(formBuilderContext);
        }

        public static FormBuilderContext GetFormBuilderContext(this HtmlHelper htmlHelper)
        {
            IDictionary items = htmlHelper.ViewContext.HttpContext.Items;

            FormBuilderContext builderContext = null;
            if (items.Contains(FormBuilderContextKey))
            {
                builderContext = items[FormBuilderContextKey] as FormBuilderContext;
            }

            if (builderContext == null)
            {
                builderContext = new FormBuilderContext();
                items[FormBuilderContextKey] = builderContext;
            }

            return builderContext;
        }

        #endregion
    }
}