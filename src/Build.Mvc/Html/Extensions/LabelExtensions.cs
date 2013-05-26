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

    /// <summary>
    ///     Adds buildable versions of Html.Label and Html.LabelFor
    /// </summary>
    public static class LabelExtensions
    {
        /// <summary>
        /// Builds the label.
        /// </summary>
        public static ILabelBuilder BuildLabel(this HtmlHelper html,
                                               string expression,
                                               IDictionary<string, object> htmlAttributes)
        {
            return new LabelBuilder {Html = html}.Expression(expression).Attr(htmlAttributes);
        }

        public static ILabelBuilder BuildLabel(this HtmlHelper html,
                                               string expression,
                                               string labelText,
                                               object htmlAttributes)
        {
            return new LabelBuilder {Html = html}.Expression(expression).LabelText(labelText).Attr(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static ILabelBuilder BuildLabel(this HtmlHelper html,
                                               string expression,
                                               string labelText,
                                               IDictionary<string, object> htmlAttributes)
        {
            return new LabelBuilder {Html = html}.Expression(expression).LabelText(labelText).Attr(htmlAttributes);
        }

        public static ILabelBuilder BuildLabel(this HtmlHelper html,
                                               string expression,
                                               object htmlAttributes)
        {
            return new LabelBuilder {Html = html}.Expression(expression).Attr(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Returns an HTML label that displays the specified text.
        /// </summary>
        public static ILabelBuilder BuildLabel(this HtmlHelper html,
                                               string expression)
        {
            return new LabelBuilder {Html = html}.Expression(expression);
        }

        public static ILabelBuilder BuildLabel(this HtmlHelper html,
                                               string expression,
                                               string labelText)
        {
            return new LabelBuilder {Html = html}.Expression(expression).LabelText(labelText);
        }

        public static ILabelBuilder BuildLabelFor<TModel, TValue>(this HtmlHelper<TModel> html,
                                                                  Expression<Func<TModel, TValue>> expression,
                                                                  string labelText,
                                                                  object htmlAttributes)
        {
            return
                new LabelBuilder<TModel, TValue> {Html = html, InitExpression = expression}.LabelText(labelText)
                                                                                           .Attr(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static ILabelBuilder BuildLabelFor<TModel, TValue>(this HtmlHelper<TModel> html,
                                                                  Expression<Func<TModel, TValue>> expression,
                                                                  string labelText)
        {
            return new LabelBuilder<TModel, TValue> {Html = html, InitExpression = expression}.LabelText(labelText);
        }

        public static ILabelBuilder BuildLabelFor<TModel, TValue>(this HtmlHelper<TModel> html,
                                                                  Expression<Func<TModel, TValue>> expression,
                                                                  string labelText,
                                                                  IDictionary<string, object> htmlAttributes)
        {
            return new LabelBuilder<TModel, TValue> {Html = html, InitExpression = expression}.LabelText(labelText).Attr(htmlAttributes);
        }

        public static ILabelBuilder BuildLabelFor<TModel, TValue>(this HtmlHelper<TModel> html,
                                                                  Expression<Func<TModel, TValue>> expression,
                                                                  object htmlAttributes)
        {
            return new LabelBuilder<TModel, TValue> {Html = html, InitExpression = expression}.Attr(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static ILabelBuilder BuildLabelFor<TModel, TValue>(this HtmlHelper<TModel> html,
                                                                  Expression<Func<TModel, TValue>> expression,
                                                                  IDictionary<string, object> htmlAttributes)
        {
            return new LabelBuilder<TModel, TValue> {Html = html, InitExpression = expression}.Attr(htmlAttributes);
        }

        public static ILabelBuilder BuildLabelFor<TModel, TValue>(this HtmlHelper<TModel> html,
                                                                  Expression<Func<TModel, TValue>> expression)
        {
            return new LabelBuilder<TModel, TValue> {Html = html, InitExpression = expression};
        }
    }
}