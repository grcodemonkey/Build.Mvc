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
    /// </summary>
    public static class TextAreaExtensions
    {
        /// <summary>
        /// Returns the specified textarea element by using the specified HTML helper and the name of the form field.
        /// </summary>
        /// <returns>
        /// The textarea element.
        /// </returns>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name of the form field to return.</param>
        public static ITextBoxBuilder BuildTextArea(this HtmlHelper htmlHelper,
                                                    string name)
        {
            return htmlHelper.BuildTextArea(name, null, null);
        }

        /// <summary>
        /// Returns the specified textarea element by using the specified HTML helper and HTML attributes.
        /// </summary>
        /// <returns>
        /// The textarea element.
        /// </returns>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name of the form field to return.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        public static ITextBoxBuilder BuildTextArea(this HtmlHelper htmlHelper,
                                                    string name,
                                                    IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.BuildTextArea(name, null, htmlAttributes);
        }

        /// <summary>
        /// Returns the specified textarea element by using the specified HTML helper and HTML attributes.
        /// </summary>
        /// <returns>
        /// The textarea element.
        /// </returns>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name of the form field to return.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        public static ITextBoxBuilder BuildTextArea(this HtmlHelper htmlHelper,
                                                    string name,
                                                    object htmlAttributes)
        {
            return htmlHelper.BuildTextArea(name, null, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Returns the specified textarea element by using the specified HTML helper, the name of the form field, and the text content.
        /// </summary>
        /// <returns>
        /// The textarea element.
        /// </returns>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name of the form field to return.</param>
        /// <param name="value">The text content.</param>
        public static ITextBoxBuilder BuildTextArea(this HtmlHelper htmlHelper,
                                                    string name,
                                                    string value)
        {
            return htmlHelper.BuildTextArea(name, value, null);
        }

        /// <summary>
        /// Returns the specified textarea element by using the specified HTML helper, the name of the form field, the text content, and the specified HTML attributes.
        /// </summary>
        /// <returns>
        /// The textarea element.
        /// </returns>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name of the form field to return.</param>
        /// <param name="value">The text content.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        public static ITextBoxBuilder BuildTextArea(this HtmlHelper htmlHelper,
                                                    string name,
                                                    string value,
                                                    IDictionary<string, object> htmlAttributes)
        {
            return new TextBoxBuilder {Html = htmlHelper}.Multiline().Named(name).Val(value).Attr(htmlAttributes);
        }

        /// <summary>
        /// Returns the specified textarea element by using the specified HTML helper, the name of the form field, the text content, and the specified HTML attributes.
        /// </summary>
        /// <returns>
        /// The textarea element.
        /// </returns>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name of the form field to return.</param>
        /// <param name="value">The text content.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        public static ITextBoxBuilder BuildTextArea(this HtmlHelper htmlHelper,
                                                    string name,
                                                    string value,
                                                    object htmlAttributes)
        {
            return htmlHelper.BuildTextArea(name, value, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Returns the specified textarea element by using the specified HTML helper, the name of the form field, the text content, the number of rows and columns, and the specified HTML attributes.
        /// </summary>
        /// <returns>
        /// The textarea element.
        /// </returns>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name of the form field to return.</param>
        /// <param name="value">The text content.</param>
        /// <param name="rows">The number of rows.</param>
        /// <param name="columns">The number of columns.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        public static ITextBoxBuilder BuildTextArea(this HtmlHelper htmlHelper,
                                                    string name,
                                                    string value,
                                                    int rows,
                                                    int columns,
                                                    IDictionary<string, object> htmlAttributes)
        {
            return new TextBoxBuilder {Html = htmlHelper}.Multiline(rows, columns).Named(name).Val(value).Attr(htmlAttributes);
        }

        /// <summary>
        /// Returns the specified textarea element by using the specified HTML helper, the name of the form field, the text content, the number of rows and columns, and the specified HTML attributes.
        /// </summary>
        /// <returns>
        /// The textarea element.
        /// </returns>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name of the form field to return.</param>
        /// <param name="value">The text content.</param>
        /// <param name="rows">The number of rows.</param>
        /// <param name="columns">The number of columns.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        public static ITextBoxBuilder BuildTextArea(this HtmlHelper htmlHelper,
                                                    string name,
                                                    string value,
                                                    int rows,
                                                    int columns,
                                                    object htmlAttributes)
        {
            return htmlHelper.BuildTextArea(name, value, rows, columns, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Returns an HTML textarea element for each property in the object that is represented by the specified expression.
        /// </summary>
        /// <returns>
        /// An HTML textarea element for each property in the object that is represented by the expression.
        /// </returns>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="expression" /> parameter is null.
        /// </exception>
        public static ITextBoxBuilder BuildTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                          Expression<Func<TModel, TProperty>> expression)
        {
            return htmlHelper.BuildTextAreaFor(expression, null);
        }

        /// <summary>
        /// Returns an HTML textarea element for each property in the object that is represented by the specified expression using the specified HTML attributes.
        /// </summary>
        /// <returns>
        /// An HTML textarea element for each property in the object that is represented by the expression.
        /// </returns>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="expression" /> parameter is null.
        /// </exception>
        public static ITextBoxBuilder BuildTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                          Expression<Func<TModel, TProperty>> expression,
                                                                          object htmlAttributes)
        {
            return htmlHelper.BuildTextAreaFor(expression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Returns an HTML textarea element for each property in the object that is represented by the specified expression using the specified HTML attributes and the number of rows and columns.
        /// </summary>
        /// <returns>
        /// An HTML textarea element for each property in the object that is represented by the expression.
        /// </returns>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <param name="rows">The number of rows.</param>
        /// <param name="columns">The number of columns.</param>
        /// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="expression" /> parameter is null.
        /// </exception>
        public static ITextBoxBuilder BuildTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                          Expression<Func<TModel, TProperty>> expression,
                                                                          int rows,
                                                                          int columns,
                                                                          object htmlAttributes)
        {
            return htmlHelper.BuildTextAreaFor(expression, rows, columns, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Returns an HTML textarea element for each property in the object that is represented by the specified expression using the specified HTML attributes and the number of rows and columns.
        /// </summary>
        /// <returns>
        /// An HTML textarea element for each property in the object that is represented by the expression.
        /// </returns>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <param name="rows">The number of rows.</param>
        /// <param name="columns">The number of columns.</param>
        /// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="expression" /> parameter is null.
        /// </exception>
        public static ITextBoxBuilder BuildTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                          Expression<Func<TModel, TProperty>> expression,
                                                                          int rows,
                                                                          int columns,
                                                                          IDictionary<string, object> htmlAttributes)
        {
            return new TextBoxBuilder<TModel, TProperty> {Html = htmlHelper, InitExpression = expression}.Multiline(rows, columns).Attr(htmlAttributes);
        }

        /// <summary>
        /// Returns an HTML textarea element for each property in the object that is represented by the specified expression using the specified HTML attributes.
        /// </summary>
        /// <returns>
        /// An HTML textarea element for each property in the object that is represented by the expression.
        /// </returns>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="expression" /> parameter is null.
        /// </exception>
        public static ITextBoxBuilder BuildTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                          Expression<Func<TModel, TProperty>> expression,
                                                                          IDictionary<string, object> htmlAttributes)
        {
            return new TextBoxBuilder<TModel, TProperty> {Html = htmlHelper, InitExpression = expression}.Multiline().Attr(htmlAttributes);
        }
    }
}