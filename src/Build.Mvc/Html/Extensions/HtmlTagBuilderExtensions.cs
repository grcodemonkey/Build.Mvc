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
    using System.Web.Mvc;

    /// <summary>
    /// 
    /// </summary>
    public static class HtmlTagBuilderExtensions
    {
        /// <summary>
        /// Creates a HTML Builder for creating generic HTML markup.
        /// </summary>
        public static IHtmlTagBuilder BuildTag(this HtmlHelper htmlHelper,
                                               string tagName,
                                               TagRenderMode renderMode)
        {
            return new HtmlTagBuilder(tagName, renderMode) {Html = htmlHelper};
        }

        /// <summary>
        /// Creates a HTML Builder for creating generic HTML markup.
        /// </summary>
        public static IHtmlTagBuilder BuildTag(this HtmlHelper htmlHelper,
                                               string tagName)
        {
            return htmlHelper.BuildTag(tagName, TagRenderMode.Normal);
        }

        /// <summary>
        /// Creates a HTML Builder for an achor tag that wraps an image tag.
        /// </summary>
        public static IHtmlTagBuilder BuildImageLink(this HtmlHelper htmlHelper,
                                                     string imgSrc,
                                                     string imgAlt = "")
        {
            return BuildImageLink(htmlHelper, imgSrc, new { alt = imgAlt });
        }

        /// <summary>
        /// Creates a HTML Builder for an achor tag that wraps an image tag.
        /// </summary>
        public static IHtmlTagBuilder BuildImageLink(this HtmlHelper htmlHelper,
                                                     string imgSrc,
                                                     object imgHtmlAttributes = null)
        {
            return htmlHelper.BuildTag("a").
                              BuildWith(x =>
                                       {
                                           x.InternalBuilder.InnerHtml = htmlHelper.
                                               BuildTag("img", TagRenderMode.SelfClosing).
                                               Src(imgSrc).
                                               Attr(imgHtmlAttributes).
                                               ToHtmlString();
                                       });
        }
    }
}