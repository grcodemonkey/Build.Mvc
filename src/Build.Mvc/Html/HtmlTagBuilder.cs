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
using System.Web.Mvc;

namespace Build.Mvc.Html
{
    /// <summary>
    /// 
    /// </summary>
    public class HtmlTagBuilder : HtmlBuilder, IHtmlTagBuilder
    {
        private HtmlHelper _html;

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlTagBuilder" /> class.
        /// </summary>
        /// <param name="tagName">Name of the tag.</param>
        /// <param name="renderMode">The render mode.</param>
        public HtmlTagBuilder(string tagName, TagRenderMode renderMode)
        {
            InternalBuilder = new TagBuilder(tagName);
            RenderMode = renderMode;
        }

        /// <summary>
        /// Gets or sets the render mode.
        /// </summary>
        /// <value>
        /// The render mode.
        /// </value>
        public TagRenderMode RenderMode { get; set; }

        /// <summary>
        /// Gets or sets the HtmlHelper
        /// </summary>
        public virtual HtmlHelper Html
        {
            get { return _html; }
            set { _html = HtmlHelperContext.MergeHelperContext(value, this); }
        }

        public TagBuilder InternalBuilder { get; private set; }

        public override string ToHtmlString()
        {
            InternalBuilder.MergeAttributes(HtmlAttributes, true);
            return InternalBuilder.ToString(RenderMode);
        }
    }
}