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
namespace Build.Mvc
{
    /// <summary>
    /// 
    /// </summary>
    public static class EditorBuilderExtensions
    {
        public static object AdditionalViewData(this IEditorBuilder instance)
        {
            return instance.Prop<object>("additionalViewData");
        }

        public static TBuilder AdditionalViewData<TBuilder>(this TBuilder instance,
                                                            object value) where TBuilder : IEditorBuilder
        {
            return instance.Prop("additionalViewData", value);
        }

        public static TBuilder HtmlFieldName<TBuilder>(this TBuilder instance,
                                                       string value) where TBuilder : IEditorBuilder
        {
            return instance.Prop("htmlFieldName", value);
        }

        public static string HtmlFieldName(this IEditorBuilder instance)
        {
            return instance.Prop<string>("htmlFieldName");
        }

        public static TBuilder TemplateName<TBuilder>(this TBuilder instance,
                                                      string value) where TBuilder : IEditorBuilder
        {
            return instance.Prop("templateName", value);
        }

        public static string TemplateName(this IEditorBuilder instance)
        {
            return instance.Prop<string>("templateName");
        }
    }
}