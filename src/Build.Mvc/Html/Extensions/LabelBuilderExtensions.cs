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
    /// <summary>
    /// 
    /// </summary>
    public static class LabelBuilderExtensions
    {
        /// <summary>
        /// Sets the "for" HTML Attribute
        /// </summary>
        /// <typeparam name="TBuilder">The type of the builder.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="associatedControlId">I think this is what they called it in the ASP.NET Web Forms days...</param>
        /// <returns></returns>
        public static TBuilder For<TBuilder>(this TBuilder instance,
                                             string associatedControlId) where TBuilder : ILabelBuilder
        {
            return instance.Attr("for", associatedControlId);
        }

        /// <summary>
        /// Sets the label text.
        /// </summary>
        public static TBuilder LabelText<TBuilder>(this TBuilder instance,
                                                   string value) where TBuilder : ILabelBuilder
        {
            return instance.Prop("labelText", value);
        }

        /// <summary>
        /// Gets the label text.
        /// </summary>
        public static string LabelText<TBuilder>(this TBuilder instance) where TBuilder : ILabelBuilder
        {
            return instance.Prop<string>("labelText");
        }
    }
}