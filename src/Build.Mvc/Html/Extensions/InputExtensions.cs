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
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Build.Mvc.Html
{
    /// <summary>
    /// 
    /// </summary>
    public static class InputExtensions
    {
        public static ICheckBoxBuilder BuildCheckBox(this HtmlHelper htmlHelper,
                                                     string name,
                                                     bool isChecked)
        {
            return htmlHelper.BuildCheckBox(name, isChecked, null);
        }

        public static ICheckBoxBuilder BuildCheckBox(this HtmlHelper htmlHelper,
                                                     string name,
                                                     IDictionary<string, object> htmlAttributes)
        {
            return new CheckBoxBuilder {Html = htmlHelper}.Named(name).Attr(htmlAttributes);
        }

        public static ICheckBoxBuilder BuildCheckBox(this HtmlHelper htmlHelper,
                                                     string name,
                                                     bool isChecked,
                                                     object htmlAttributes)
        {
            return htmlHelper.BuildCheckBox(name, isChecked, ( HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) ));
        }

        public static ICheckBoxBuilder BuildCheckBox(this HtmlHelper htmlHelper,
                                                     string name,
                                                     object htmlAttributes)
        {
            return htmlHelper.BuildCheckBox(name, ( HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) ));
        }

        public static ICheckBoxBuilder BuildCheckBox(this HtmlHelper htmlHelper,
                                                     string name)
        {
            return htmlHelper.BuildCheckBox(name, null);
        }

        public static ICheckBoxBuilder BuildCheckBox(this HtmlHelper htmlHelper,
                                                     string name,
                                                     bool isChecked,
                                                     IDictionary<string, object> htmlAttributes)
        {
            return new CheckBoxBuilder {Html = htmlHelper}.Named(name).Attr(htmlAttributes).IsChecked(isChecked);
        }

        public static ICheckBoxBuilder BuildCheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper,
                                                                Expression<Func<TModel, bool>> expression,
                                                                IDictionary<string, object> htmlAttributes)
        {
            if ( expression == null )
            {
                throw new ArgumentNullException("expression");
            }
            return new CheckBoxBuilder<TModel> {Html = htmlHelper, InitExpression = expression}.Attr(htmlAttributes);
        }

        public static ICheckBoxBuilder BuildCheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper,
                                                                Expression<Func<TModel, bool>> expression,
                                                                object htmlAttributes)
        {
            return htmlHelper.BuildCheckBoxFor(expression, ( HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) ));
        }

        public static ICheckBoxBuilder BuildCheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper,
                                                                Expression<Func<TModel, bool>> expression)
        {
            return htmlHelper.BuildCheckBoxFor(expression, (IDictionary<string, object>) null);
        }

        public static ICheckBoxBuilder BuildCheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper,
                                                         Expression<Func<TModel, bool>> expression,
                                                         Action<ICheckBoxBuilder> builderExpression)
        {
            ICheckBoxBuilder builder = htmlHelper.BuildCheckBoxFor(expression);
            if (builderExpression != null)
            {
                builderExpression.Invoke(builder);
            }
            return builder;
        }

        public static IHiddenBuilder BuildHidden(this HtmlHelper htmlHelper,
                                                 string name,
                                                 object value,
                                                 IDictionary<string, object> htmlAttributes)
        {
            return new HiddenBuilder {Html = htmlHelper}.Named(name).Val(value).Attr(htmlAttributes);
        }

        public static IHiddenBuilder BuildHidden(this HtmlHelper htmlHelper,
                                                 string name)
        {
            return htmlHelper.BuildHidden(name, null, null);
        }

        public static IHiddenBuilder BuildHidden(this HtmlHelper htmlHelper,
                                                 string name,
                                                 object value)
        {
            return htmlHelper.BuildHidden(name, value, null);
        }

        public static IHiddenBuilder BuildHidden(this HtmlHelper htmlHelper,
                                                 string name,
                                                 object value,
                                                 object htmlAttributes)
        {
            return htmlHelper.BuildHidden(name, value, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static IHiddenBuilder BuildHiddenFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                       Expression<Func<TModel, TProperty>> expression,
                                                                       IDictionary<string, object> htmlAttributes)
        {
            return new HiddenBuilder<TModel, TProperty> {Html = htmlHelper, InitExpression = expression}.Attr(htmlAttributes);
        }

        public static IHiddenBuilder BuildHiddenFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                       Expression<Func<TModel, TProperty>> expression)
        {
            return htmlHelper.BuildHiddenFor(expression, null);
        }

        public static IHiddenBuilder BuildHiddenFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                       Expression<Func<TModel, TProperty>> expression,
                                                                       object htmlAttributes)
        {
            return htmlHelper.BuildHiddenFor(expression, ( HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) ));
        }

        public static ITextBoxBuilder BuildPassword(this HtmlHelper htmlHelper,
                                                    string name,
                                                    object value,
                                                    object htmlAttributes)
        {
            return htmlHelper.BuildPassword(name, value, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static ITextBoxBuilder BuildPassword(this HtmlHelper htmlHelper,
                                                    string name)
        {
            return htmlHelper.BuildPassword(name, null);
        }

        public static ITextBoxBuilder BuildPassword(this HtmlHelper htmlHelper,
                                                    string name,
                                                    object value,
                                                    IDictionary<string, object> htmlAttributes)
        {
            return new TextBoxBuilder {Html = htmlHelper}.Password().Named(name).Val(value).Attr(htmlAttributes);
        }

        public static ITextBoxBuilder BuildPassword(this HtmlHelper htmlHelper,
                                                    string name,
                                                    object value)
        {
            return htmlHelper.BuildPassword(name, value, null);
        }

        public static ITextBoxBuilder BuildPasswordFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                          Expression<Func<TModel, TProperty>> expression,
                                                                          object htmlAttributes)
        {
            return htmlHelper.BuildPasswordFor(expression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static ITextBoxBuilder BuildPasswordFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                          Expression<Func<TModel, TProperty>> expression,
                                                                          IDictionary<string, object> htmlAttributes)
        {
            return new TextBoxBuilder<TModel, TProperty> {Html = htmlHelper, InitExpression = expression}.Password().Attr(htmlAttributes);
        }

        public static ITextBoxBuilder BuildPasswordFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                          Expression<Func<TModel, TProperty>> expression)
        {
            return htmlHelper.BuildPasswordFor(expression, null);
        }

        public static IRadioButtonBuilder BuildRadioButton(this HtmlHelper htmlHelper,
                                                           string name,
                                                           object value,
                                                           object htmlAttributes)
        {
            return htmlHelper.BuildRadioButton(name, value, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static IRadioButtonBuilder BuildRadioButton(this HtmlHelper htmlHelper,
                                                           string name,
                                                           object value,
                                                           IDictionary<string, object> htmlAttributes)
        {
            return new RadioButtonBuilder {Html = htmlHelper}.Named(name).Attr(htmlAttributes).Val(value);
        }

        public static IRadioButtonBuilder BuildRadioButton(this HtmlHelper htmlHelper,
                                                           string name,
                                                           object value)
        {
            return htmlHelper.BuildRadioButton(name, value, null);
        }

        public static IRadioButtonBuilder BuildRadioButton(this HtmlHelper htmlHelper,
                                                           string name,
                                                           object value,
                                                           bool isChecked)
        {
            return htmlHelper.BuildRadioButton(name, value, isChecked, null);
        }

        public static IRadioButtonBuilder BuildRadioButton(this HtmlHelper htmlHelper,
                                                           string name,
                                                           object value,
                                                           bool isChecked,
                                                           IDictionary<string, object> htmlAttributes)
        {
            return new RadioButtonBuilder {Html = htmlHelper}.Named(name).Attr(htmlAttributes).Val(value).IsChecked(isChecked);
        }

        public static IRadioButtonBuilder BuildRadioButton(this HtmlHelper htmlHelper,
                                                           string name,
                                                           object value,
                                                           bool isChecked,
                                                           object htmlAttributes)
        {
            return htmlHelper.BuildRadioButton(name, value, isChecked, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static IRadioButtonBuilder BuildRadioButtonFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                                 Expression<Func<TModel, TProperty>> expression,
                                                                                 object value,
                                                                                 object htmlAttributes)
        {
            return htmlHelper.BuildRadioButtonFor(expression, value, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static IRadioButtonBuilder BuildRadioButtonFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                                 Expression<Func<TModel, TProperty>> expression,
                                                                                 object value)
        {
            return htmlHelper.BuildRadioButtonFor(expression, value, (IDictionary<string, object>) null);
        }

        public static IRadioButtonBuilder BuildRadioButtonFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                                 Expression<Func<TModel, TProperty>> expression,
                                                                                 object value,
                                                                                 IDictionary<string, object> htmlAttributes)
        {
            return new RadioButtonBuilder<TModel, TProperty> {Html = htmlHelper, InitExpression = expression}.Val(value).Attr(htmlAttributes);
        }

        public static IRadioButtonBuilder BuildRadioButtonFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                 Expression<Func<TModel, TProperty>> expression,
                                                                 object value,
                                                                 Action<IRadioButtonBuilder> builderExpression)
        {
            IRadioButtonBuilder builder = htmlHelper.BuildRadioButtonFor(expression, value);
            if (builderExpression != null)
            {
                builderExpression.Invoke(builder);
            }
            return builder;
        }

        public static ITextBoxBuilder BuildTextBox(this HtmlHelper htmlHelper,
                                                   string name,
                                                   object value,
                                                   object htmlAttributes)
        {
            return htmlHelper.BuildTextBox(name, value, null, htmlAttributes);
        }

        public static ITextBoxBuilder BuildTextBox(this HtmlHelper htmlHelper,
                                                   string name,
                                                   object value)
        {
            return htmlHelper.BuildTextBox(name, value, format: null);
        }

        public static ITextBoxBuilder BuildTextBox(this HtmlHelper htmlHelper,
                                                   string name,
                                                   object value,
                                                   string format,
                                                   IDictionary<string, object> htmlAttributes)
        {
            return new TextBoxBuilder {Html = htmlHelper}.Singleline().Named(name).Val(value).Format(format).Attr(htmlAttributes);
        }

        public static ITextBoxBuilder BuildTextBox(this HtmlHelper htmlHelper,
                                                   string name,
                                                   object value,
                                                   IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.BuildTextBox(name, value, null, htmlAttributes);
        }

        public static ITextBoxBuilder BuildTextBox(this HtmlHelper htmlHelper,
                                                   string name,
                                                   object value,
                                                   string format,
                                                   object htmlAttributes)
        {
            return htmlHelper.BuildTextBox(name, value, format, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static ITextBoxBuilder BuildTextBox(this HtmlHelper htmlHelper,
                                                   string name)
        {
            return htmlHelper.BuildTextBox(name, value: null);
        }

        public static ITextBoxBuilder BuildTextBox(this HtmlHelper htmlHelper,
                                                   string name,
                                                   object value,
                                                   string format)
        {
            return htmlHelper.BuildTextBox(name, value, format, null);
        }

        public static ITextBoxBuilder BuildTextBox(this HtmlHelper htmlHelper,
                                                   string name,
                                                   Action<ITextBoxBuilder> builderExpression)
        {
            return htmlHelper.BuildTextBox(name).BuildWith(builderExpression);
        }

        public static ITextBoxBuilder BuildTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                         Expression<Func<TModel, TProperty>> expression,
                                                                         string format,
                                                                         IDictionary<string, object> htmlAttributes)
        {
            return new TextBoxBuilder<TModel, TProperty> {Html = htmlHelper, InitExpression = expression}.Singleline().Format(format).Attr(htmlAttributes);
        }

        public static ITextBoxBuilder BuildTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                         Expression<Func<TModel, TProperty>> expression,
                                                                         object htmlAttributes)
        {
            return htmlHelper.BuildTextBoxFor(expression, null, htmlAttributes);
        }

        public static ITextBoxBuilder BuildTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                         Expression<Func<TModel, TProperty>> expression,
                                                                         IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.BuildTextBoxFor(expression, null, htmlAttributes);
        }

        public static ITextBoxBuilder BuildTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                         Expression<Func<TModel, TProperty>> expression,
                                                                         string format,
                                                                         object htmlAttributes)
        {
            return htmlHelper.BuildTextBoxFor(expression, format, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static ITextBoxBuilder BuildTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                         Expression<Func<TModel, TProperty>> expression)
        {
            return htmlHelper.BuildTextBoxFor(expression, (string) null);
        }

        public static ITextBoxBuilder BuildTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                         Expression<Func<TModel, TProperty>> expression,
                                                                         string format)
        {
            return htmlHelper.BuildTextBoxFor(expression, format, null);
        }


        public static ITextBoxBuilder BuildTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                         Expression<Func<TModel, TProperty>> expression,
                                                                         Action<ITextBoxBuilder> builderExpression)
        {
            ITextBoxBuilder builder = htmlHelper.BuildTextBoxFor(expression);
            if ( builderExpression != null )
            {
                builderExpression.Invoke(builder);
            }
            return builder;
        }
    }
}
