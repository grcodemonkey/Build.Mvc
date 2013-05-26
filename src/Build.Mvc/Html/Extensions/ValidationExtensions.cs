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
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// Provides Build.Mvc support for ValidationMessage
    /// </summary>
    public static class ValidationExtensions
    {
        /// <summary>
        /// Displays a validation message if an error exists for the specified field in the
        ///     <see
        ///         cref="T:System.Web.Mvc.ModelStateDictionary" />
        /// object.
        /// </summary>
        /// <returns>
        /// If the property or object is valid, an empty string; otherwise, a span element that contains an error message.
        /// </returns>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="modelName">The name of the property or model object that is being validated.</param>
        public static IValidationMessageBuilder BuildValidationMessage(this HtmlHelper htmlHelper,
                                                                       string modelName)
        {
            return htmlHelper.BuildValidationMessage(modelName, null, new RouteValueDictionary());
        }

        public static IValidationMessageBuilder BuildValidationMessage(this HtmlHelper htmlHelper,
                                                                       string modelName,
                                                                       string validationMessage,
                                                                       IDictionary<string, object> htmlAttributes)
        {
            return new ValidationMessageBuilder {Html = htmlHelper}.ModelName(modelName).Message(validationMessage).Attr(htmlAttributes);
        }

        public static IValidationMessageBuilder BuildValidationMessage(this HtmlHelper htmlHelper,
                                                                       string modelName,
                                                                       object htmlAttributes)
        {
            return htmlHelper.BuildValidationMessage(modelName, null, (HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)));
        }

        public static IValidationMessageBuilder BuildValidationMessage(this HtmlHelper htmlHelper,
                                                                       string modelName,
                                                                       string validationMessage)
        {
            return htmlHelper.BuildValidationMessage(modelName, validationMessage, (new RouteValueDictionary()));
        }

        public static IValidationMessageBuilder BuildValidationMessage(this HtmlHelper htmlHelper,
                                                                       string modelName,
                                                                       IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.BuildValidationMessage(modelName, null, htmlAttributes);
        }


        public static IValidationMessageBuilder BuildValidationMessage(this HtmlHelper htmlHelper,
                                                                       string modelName,
                                                                       string validationMessage,
                                                                       object htmlAttributes)
        {
            return htmlHelper.BuildValidationMessage(modelName, validationMessage, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static IValidationMessageBuilder BuildValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                                             Expression<Func<TModel, TProperty>> expression,
                                                                                             string validationMessage,
                                                                                             object htmlAttributes)
        {
            return htmlHelper.BuildValidationMessageFor(expression, validationMessage, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static IValidationMessageBuilder BuildValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                                             Expression<Func<TModel, TProperty>> expression,
                                                                                             string validationMessage)
        {
            return htmlHelper.BuildValidationMessageFor(expression, validationMessage, (new RouteValueDictionary()));
        }

        /// <summary>
        /// Retrieves the validation metadata for the specified model and applies each rule to the data field.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        public static IValidationMessageBuilder BuildValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                                             Expression<Func<TModel, TProperty>> expression)
        {
            return htmlHelper.BuildValidationMessageFor(expression, null, new RouteValueDictionary());
        }

        public static IValidationMessageBuilder BuildValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                                             Expression<Func<TModel, TProperty>> expression,
                                                                                             string validationMessage,
                                                                                             IDictionary<string, object> htmlAttributes)
        {
            return
                new ValidationMessageBuilder<TModel, TProperty> {Html = htmlHelper, InitExpression = expression}.Message(validationMessage).Attr(htmlAttributes);
        }

        public static IValidationSummaryBuilder BuildValidationSummary(this HtmlHelper htmlHelper,
                                                                       bool excludePropertyErrors)
        {
            return htmlHelper.BuildValidationSummary(excludePropertyErrors, null);
        }

        public static IValidationSummaryBuilder BuildValidationSummary(this HtmlHelper htmlHelper,
                                                                       bool excludePropertyErrors,
                                                                       string message)
        {
            return htmlHelper.BuildValidationSummary(excludePropertyErrors, message, null);
        }

        public static IValidationSummaryBuilder BuildValidationSummary(this HtmlHelper htmlHelper,
                                                                       string message)
        {
            return htmlHelper.BuildValidationSummary(false, message, null);
        }

        public static IValidationSummaryBuilder BuildValidationSummary(this HtmlHelper htmlHelper,
                                                                       string message,
                                                                       object htmlAttributes)
        {
            return htmlHelper.BuildValidationSummary(false, message, (HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)));
        }

        public static IValidationSummaryBuilder BuildValidationSummary(this HtmlHelper htmlHelper,
                                                                       string message,
                                                                       IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.BuildValidationSummary(false, message, htmlAttributes);
        }

        public static IValidationSummaryBuilder BuildValidationSummary(this HtmlHelper htmlHelper)
        {
            return htmlHelper.BuildValidationSummary(false);
        }

        public static IValidationSummaryBuilder BuildValidationSummary(this HtmlHelper htmlHelper,
                                                                       bool excludePropertyErrors,
                                                                       string message,
                                                                       IDictionary<string, object> htmlAttributes)
        {
            return new ValidationSummaryBuilder {Html = htmlHelper}.ExcludePropertyErrors(excludePropertyErrors).Message(message).Attr(htmlAttributes);
        }

        public static IValidationSummaryBuilder BuildValidationSummary(this HtmlHelper htmlHelper,
                                                                       bool excludePropertyErrors,
                                                                       string message,
                                                                       object htmlAttributes)
        {
            return htmlHelper.BuildValidationSummary(excludePropertyErrors, message, (HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)));
        }
    }
}