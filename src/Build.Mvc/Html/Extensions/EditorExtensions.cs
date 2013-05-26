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
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Build.Mvc.Html
{
    public static class EditorExtensions
    {
        public static IEditorBuilder BuildEditor(this HtmlHelper html,
                                                 string expression)
        {
            return new EditorBuilder {Html = html}.Expression(expression);
        }

        public static IEditorBuilder BuildEditor(this HtmlHelper html,
                                                 string expression,
                                                 object additionalViewData)
        {
            return new EditorBuilder {Html = html}.Expression(expression).AdditionalViewData(additionalViewData);
        }

        public static IEditorBuilder BuildEditor(this HtmlHelper html,
                                                 string expression,
                                                 string templateName)
        {
            return new EditorBuilder {Html = html}.Expression(expression).TemplateName(templateName);
        }

        public static IEditorBuilder BuildEditor(this HtmlHelper html,
                                                 string expression,
                                                 string templateName,
                                                 object additionalViewData)
        {
            return new EditorBuilder {Html = html}.Expression(expression).TemplateName(templateName).AdditionalViewData(additionalViewData);
        }

        public static IEditorBuilder BuildEditor(this HtmlHelper html,
                                                 string expression,
                                                 string templateName,
                                                 string htmlFieldName)
        {
            return new EditorBuilder {Html = html}.Expression(expression).TemplateName(templateName).HtmlFieldName(htmlFieldName);
        }

        public static IEditorBuilder BuildEditor(this HtmlHelper html,
                                                 string expression,
                                                 string templateName,
                                                 string htmlFieldName,
                                                 object additionalViewData)
        {
            return new EditorBuilder {Html = html}.Expression(expression).TemplateName(templateName).HtmlFieldName(htmlFieldName).AdditionalViewData(additionalViewData);
        }

        public static IEditorBuilder BuildEditorFor<TModel, TValue>(this HtmlHelper<TModel> html,
                                                                    Expression<Func<TModel, TValue>> expression)
        {
            return new EditorBuilder<TModel, TValue> {Html = html, InitExpression = expression};
        }

        public static IEditorBuilder BuildEditorFor<TModel, TValue>(this HtmlHelper<TModel> html,
                                                                    Expression<Func<TModel, TValue>> expression,
                                                                    object additionalViewData)
        {
            return new EditorBuilder<TModel, TValue> {Html = html, InitExpression = expression}.AdditionalViewData(additionalViewData);
        }

        public static IEditorBuilder BuildEditorFor<TModel, TValue>(this HtmlHelper<TModel> html,
                                                                    Expression<Func<TModel, TValue>> expression,
                                                                    string templateName)
        {
            return new EditorBuilder<TModel, TValue> {Html = html, InitExpression = expression}.TemplateName(templateName);
        }

        public static IEditorBuilder BuildEditorFor<TModel, TValue>(this HtmlHelper<TModel> html,
                                                                    Expression<Func<TModel, TValue>> expression,
                                                                    string templateName,
                                                                    object additionalViewData)
        {
            return new EditorBuilder<TModel, TValue> {Html = html, InitExpression = expression}.TemplateName(templateName).AdditionalViewData(additionalViewData);
        }

        public static IEditorBuilder BuildEditorFor<TModel, TValue>(this HtmlHelper<TModel> html,
                                                                    Expression<Func<TModel, TValue>> expression,
                                                                    string templateName,
                                                                    string htmlFieldName)
        {
            return new EditorBuilder<TModel, TValue> {Html = html, InitExpression = expression}.TemplateName(templateName).HtmlFieldName(htmlFieldName);
        }

        public static IEditorBuilder BuildEditorFor<TModel, TValue>(this HtmlHelper<TModel> html,
                                                                    Expression<Func<TModel, TValue>> expression,
                                                                    string templateName,
                                                                    string htmlFieldName,
                                                                    object additionalViewData)
        {
            return new EditorBuilder<TModel, TValue> {Html = html, InitExpression = expression}.TemplateName(templateName).HtmlFieldName(htmlFieldName).AdditionalViewData(additionalViewData);
        }
    }
}