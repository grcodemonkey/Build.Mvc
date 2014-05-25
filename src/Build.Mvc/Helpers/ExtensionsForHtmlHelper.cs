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
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using Build.Mvc.Html;

namespace Build.Mvc.Helpers
{
    /// <summary>
    /// </summary>
    public static class ExtensionsForHtmlHelper
    {
        /// <summary>
        /// Gets an instance of a <see cref="T:System.Web.Mvc.UrlHelper"/> for the current RequestContext.
        /// </summary>
        /// <param name="html"> The HTML helper. </param>
        /// <returns> </returns>
        public static UrlHelper Url(this HtmlHelper html)
        {
            return new UrlHelper(html.ViewContext.RequestContext);
        }

        public static object GetModelStateValue(this HtmlHelper html, string key, Type destinationType)
        {
            ModelState modelState;
            if (html.ViewData.ModelState.TryGetValue(key, out modelState) && modelState.Value != null)
            {
                return modelState.Value.ConvertTo(destinationType, null);
            }
            return null;
        }

        public static object GetInputValue<TModel, TProperty>(this HtmlHelper<TModel> html, IFormInputBuilder inputBuilder, Expression<Func<TModel, TProperty>> expression)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            return GetInputValue(html, inputBuilder, ExpressionHelper.GetExpressionText(expression), metadata.Model);
        }

        public static object GetInputValue(this HtmlHelper html, IFormInputBuilder inputBuilder, string name, object value, bool useViewData = false)
        {
            if (inputBuilder.InstanceData.ContainsKey("value"))
            {
                return inputBuilder.Val();
            }

            if (useViewData && value == null)
            {
                value = Convert.ToString(html.ViewData.Eval(name), CultureInfo.CurrentCulture);
            }

            string fullHtmlFieldName = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            object attemptedValue = html.GetModelStateValue(fullHtmlFieldName, typeof(string));

            return attemptedValue ?? value;
        }

        public static string GetLabelText(this HtmlHelper html, string expression, string labelText)
        {
            return GetLabelText(ModelMetadata.FromStringExpression(expression, html.ViewData), expression, labelText);
        }

        public static string GetLabelText<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string labelText)
        {
            return GetLabelText(ModelMetadata.FromLambdaExpression(expression, html.ViewData), ExpressionHelper.GetExpressionText(expression), labelText);
        }

        private static string GetLabelText(
            ModelMetadata metadata,
            string htmlFieldName,
            string labelText = null)
        {
            string str = labelText;
            if (str != null)
            {
                return str;
            }
            string displayName = metadata.DisplayName;
            if (displayName == null)
            {
                string propertyName = metadata.PropertyName;
                str = propertyName ?? htmlFieldName.Split(new[] { '.' }).Last();
            }
            else
            {
                str = displayName;
            }
            return str;
        }
    }
}