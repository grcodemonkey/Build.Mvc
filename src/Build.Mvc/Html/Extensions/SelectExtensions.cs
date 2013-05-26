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
    public static class SelectExtensions
    {
        /// <summary>
        /// Returns a single-selection select element using the specified HTML helper and the name of the form field.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name of the form field to return.</param>
        /// <param name="builderExpression">The builder expression.</param>
        /// <returns>
        /// An HTML select element.
        /// </returns>
        public static ISelectListBuilder BuildDropDownList(this HtmlHelper htmlHelper,
                                                           string name,
                                                           Action<ISelectListBuilder> builderExpression)
        {
            ISelectListBuilder builder = htmlHelper.BuildDropDownList(name);
            if ( builderExpression != null )
            {
                builderExpression.Invoke(builder);
            }
            return builder;
        }

        /// <summary>
        /// Returns a single-selection select element using the specified HTML helper and the name of the form field.
        /// </summary>
        /// <returns>
        /// An HTML select element.
        /// </returns>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name of the form field to return.</param>
        /// <exception cref="T:System.ArgumentException">
        /// The <paramref name="name" /> parameter is null or empty.
        /// </exception>
        public static ISelectListBuilder BuildDropDownList(this HtmlHelper htmlHelper,
                                                           string name)
        {
            return htmlHelper.BuildDropDownList(name, null, null, null);
        }

        /// <summary>
        /// Returns a single-selection select element using the specified HTML helper, the name of the form field, and the specified list items.
        /// </summary>
        /// <returns>
        /// An HTML select element with an option subelement for each item in the list.
        /// </returns>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name of the form field to return.</param>
        /// <param name="selectList">
        /// A collection of <see cref="T:System.Web.Mvc.SelectListItem" /> objects that are used to populate the drop-down list.
        /// </param>
        /// <exception cref="T:System.ArgumentException">
        /// The <paramref name="name" /> parameter is null or empty.
        /// </exception>
        public static ISelectListBuilder BuildDropDownList(this HtmlHelper htmlHelper,
                                                           string name,
                                                           IEnumerable<SelectListItem> selectList)
        {
            return htmlHelper.BuildDropDownList(name, selectList, null, null);
        }

        /// <summary>
        /// Returns a single-selection select element using the specified HTML helper, the name of the form field, and an option label.
        /// </summary>
        /// <returns>
        /// An HTML select element with an option subelement for each item in the list.
        /// </returns>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name of the form field to return.</param>
        /// <param name="optionLabel">The text for a default empty item. This parameter can be null.</param>
        /// <exception cref="T:System.ArgumentException">
        /// The <paramref name="name" /> parameter is null or empty.
        /// </exception>
        public static ISelectListBuilder BuildDropDownList(this HtmlHelper htmlHelper,
                                                           string name,
                                                           string optionLabel)
        {
            return htmlHelper.BuildDropDownList(name, null, optionLabel, null);
        }

        /// <summary>
        /// Returns a single-selection select element using the specified HTML helper, the name of the form field, the specified list items, and the specified HTML attributes.
        /// </summary>
        /// <returns>
        /// An HTML select element with an option subelement for each item in the list.
        /// </returns>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name of the form field to return.</param>
        /// <param name="selectList">
        /// A collection of <see cref="T:System.Web.Mvc.SelectListItem" /> objects that are used to populate the drop-down list.
        /// </param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <exception cref="T:System.ArgumentException">
        /// The <paramref name="name" /> parameter is null or empty.
        /// </exception>
        public static ISelectListBuilder BuildDropDownList(this HtmlHelper htmlHelper,
                                                           string name,
                                                           IEnumerable<SelectListItem> selectList,
                                                           IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.BuildDropDownList(name, selectList, null, htmlAttributes);
        }

        /// <summary>
        /// Returns a single-selection select element using the specified HTML helper, the name of the form field, the specified list items, and the specified HTML attributes.
        /// </summary>
        /// <returns>
        /// An HTML select element with an option subelement for each item in the list.
        /// </returns>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name of the form field to return.</param>
        /// <param name="selectList">
        /// A collection of <see cref="T:System.Web.Mvc.SelectListItem" /> objects that are used to populate the drop-down list.
        /// </param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <exception cref="T:System.ArgumentException">
        /// The <paramref name="name" /> parameter is null or empty.
        /// </exception>
        public static ISelectListBuilder BuildDropDownList(this HtmlHelper htmlHelper,
                                                           string name,
                                                           IEnumerable<SelectListItem> selectList,
                                                           object htmlAttributes)
        {
            return htmlHelper.BuildDropDownList(name, selectList, null, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Returns a single-selection select element using the specified HTML helper, the name of the form field, the specified list items, and an option label.
        /// </summary>
        /// <returns>
        /// An HTML select element with an option subelement for each item in the list.
        /// </returns>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name of the form field to return.</param>
        /// <param name="selectList">
        /// A collection of <see cref="T:System.Web.Mvc.SelectListItem" /> objects that are used to populate the drop-down list.
        /// </param>
        /// <param name="optionLabel">The text for a default empty item. This parameter can be null.</param>
        /// <exception cref="T:System.ArgumentException">
        /// The <paramref name="name" /> parameter is null or empty.
        /// </exception>
        public static ISelectListBuilder BuildDropDownList(this HtmlHelper htmlHelper,
                                                           string name,
                                                           IEnumerable<SelectListItem> selectList,
                                                           string optionLabel)
        {
            return htmlHelper.BuildDropDownList(name, selectList, optionLabel, null);
        }

        /// <summary>
        /// Returns a single-selection select element using the specified HTML helper, the name of the form field, the specified list items, an option label, and the specified HTML attributes.
        /// </summary>
        /// <returns>
        /// An HTML select element with an option subelement for each item in the list.
        /// </returns>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name of the form field to return.</param>
        /// <param name="selectList">
        /// A collection of <see cref="T:System.Web.Mvc.SelectListItem" /> objects that are used to populate the drop-down list.
        /// </param>
        /// <param name="optionLabel">The text for a default empty item. This parameter can be null.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <exception cref="T:System.ArgumentException">
        /// The <paramref name="name" /> parameter is null or empty.
        /// </exception>
        public static ISelectListBuilder BuildDropDownList(this HtmlHelper htmlHelper,
                                                           string name,
                                                           IEnumerable<SelectListItem> selectList,
                                                           string optionLabel,
                                                           IDictionary<string, object> htmlAttributes)
        {
            return new DropDownListBuilder {Html = htmlHelper}.Named(name).SelectList(selectList).OptionLabel(optionLabel).Attr(htmlAttributes);
        }

        /// <summary>
        /// Returns a single-selection select element using the specified HTML helper, the name of the form field, the specified list items, an option label, and the specified HTML attributes.
        /// </summary>
        /// <returns>
        /// An HTML select element with an option subelement for each item in the list.
        /// </returns>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name of the form field to return.</param>
        /// <param name="selectList">
        /// A collection of <see cref="T:System.Web.Mvc.SelectListItem" /> objects that are used to populate the drop-down list.
        /// </param>
        /// <param name="optionLabel">The text for a default empty item. This parameter can be null.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <exception cref="T:System.ArgumentException">
        /// The <paramref name="name" /> parameter is null or empty.
        /// </exception>
        public static ISelectListBuilder BuildDropDownList(this HtmlHelper htmlHelper,
                                                           string name,
                                                           IEnumerable<SelectListItem> selectList,
                                                           string optionLabel,
                                                           object htmlAttributes)
        {
            return htmlHelper.BuildDropDownList(name, selectList, optionLabel, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Returns an HTML select element for each property in the object that is represented by the specified expression.
        /// </summary>
        /// <returns>
        /// An HTML select element for each property in the object that is represented by the expression.
        /// </returns>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the value.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="expression" /> parameter is null.
        /// </exception>
        public static ISelectListBuilder BuildDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                                 Expression<Func<TModel, TProperty>> expression)
        {
            return htmlHelper.BuildDropDownListFor(expression, null, null, null);
        }

        /// <summary>
        /// Returns an HTML select element for each property in the object that is represented by the specified expression using the specified list items.
        /// </summary>
        /// <returns>
        /// An HTML select element for each property in the object that is represented by the expression.
        /// </returns>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
        /// <param name="selectList">
        /// A collection of <see cref="T:System.Web.Mvc.SelectListItem" /> objects that are used to populate the drop-down list.
        /// </param>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the value.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="expression" /> parameter is null.
        /// </exception>
        public static ISelectListBuilder BuildDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                                 Expression<Func<TModel, TProperty>> expression,
                                                                                 IEnumerable<SelectListItem> selectList)
        {
            return htmlHelper.BuildDropDownListFor(expression, selectList, null, null);
        }

        /// <summary>
        /// Returns an HTML select element for each property in the object that is represented by the specified expression using the specified list items, option label, and HTML attributes.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the value.</typeparam>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
        /// <param name="selectList">
        /// A collection of <see cref="T:System.Web.Mvc.SelectListItem" /> objects that are used to populate the drop-down list.
        /// </param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>
        /// An HTML select element for each property in the object that is represented by the expression.
        /// </returns>
        public static ISelectListBuilder BuildDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                                 Expression<Func<TModel, TProperty>> expression,
                                                                                 IEnumerable<SelectListItem> selectList,
                                                                                 IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.BuildDropDownListFor(expression, selectList, null, htmlAttributes);
        }

        /// <summary>
        /// Returns an HTML select element for each property in the object that is represented by the specified expression using the specified list items, option label, and HTML attributes.
        /// </summary>
        /// <returns>
        /// An HTML select element for each property in the object that is represented by the expression.
        /// </returns>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
        /// <param name="selectList">
        /// A collection of <see cref="T:System.Web.Mvc.SelectListItem" /> objects that are used to populate the drop-down list.
        /// </param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the value.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="expression" /> parameter is null.
        /// </exception>
        public static ISelectListBuilder BuildDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                                 Expression<Func<TModel, TProperty>> expression,
                                                                                 IEnumerable<SelectListItem> selectList,
                                                                                 object htmlAttributes)
        {
            return htmlHelper.BuildDropDownListFor(expression, selectList, null, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Returns an HTML select element for each property in the object that is represented by the specified expression using the specified list items and option label.
        /// </summary>
        /// <returns>
        /// An HTML select element for each property in the object that is represented by the expression.
        /// </returns>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
        /// <param name="selectList">
        /// A collection of <see cref="T:System.Web.Mvc.SelectListItem" /> objects that are used to populate the drop-down list.
        /// </param>
        /// <param name="optionLabel">The text for a default empty item. This parameter can be null.</param>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the value.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="expression" /> parameter is null.
        /// </exception>
        public static ISelectListBuilder BuildDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                                 Expression<Func<TModel, TProperty>> expression,
                                                                                 IEnumerable<SelectListItem> selectList,
                                                                                 string optionLabel)
        {
            return htmlHelper.BuildDropDownListFor(expression, selectList, optionLabel, null);
        }

        /// <summary>
        /// Returns an HTML select element for each property in the object that is represented by the specified expression using the specified list items, option label, and HTML attributes.
        /// </summary>
        /// <returns>
        /// An HTML select element for each property in the object that is represented by the expression.
        /// </returns>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
        /// <param name="selectList">
        /// A collection of <see cref="T:System.Web.Mvc.SelectListItem" /> objects that are used to populate the drop-down list.
        /// </param>
        /// <param name="optionLabel">The text for a default empty item. This parameter can be null.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the value.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="expression" /> parameter is null.
        /// </exception>
        public static ISelectListBuilder BuildDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                                 Expression<Func<TModel, TProperty>> expression,
                                                                                 IEnumerable<SelectListItem> selectList,
                                                                                 string optionLabel,
                                                                                 IDictionary<string, object> htmlAttributes)
        {
            return new DropDownListBuilder<TModel, TProperty>
                       {
                           Html = htmlHelper,
                           InitExpression = expression
                       }.
                SelectList(selectList).
                OptionLabel(optionLabel).
                Attr(htmlAttributes);
        }

        /// <summary>
        /// Returns an HTML select element for each property in the object that is represented by the specified expression using the specified list items, option label, and HTML attributes.
        /// </summary>
        /// <returns>
        /// An HTML select element for each property in the object that is represented by the expression.
        /// </returns>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
        /// <param name="selectList">
        /// A collection of <see cref="T:System.Web.Mvc.SelectListItem" /> objects that are used to populate the drop-down list.
        /// </param>
        /// <param name="optionLabel">The text for a default empty item. This parameter can be null.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the value.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="expression" /> parameter is null.
        /// </exception>
        public static ISelectListBuilder BuildDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                                 Expression<Func<TModel, TProperty>> expression,
                                                                                 IEnumerable<SelectListItem> selectList,
                                                                                 string optionLabel,
                                                                                 object htmlAttributes)
        {
            return htmlHelper.BuildDropDownListFor(expression, selectList, optionLabel, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Returns an HTML select element for each property in the object that is represented by the specified expression.
        /// </summary>
        public static ISelectListBuilder BuildDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                                 Expression<Func<TModel, TProperty>> expression,
                                                                                 Action<ISelectListBuilder> builderExpression)
        {
            ISelectListBuilder builder = htmlHelper.BuildDropDownListFor(expression);
            if ( builderExpression != null )
            {
                builderExpression.Invoke(builder);
            }
            return builder;
        }
    }
}