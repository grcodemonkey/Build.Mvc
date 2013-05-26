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
using System.Collections.Generic;
using System.Web.Mvc;

namespace Build.Mvc
{
    public class HtmlHelperContext<TModel> : HtmlHelper<TModel>, IHtmlHelperContext
    {
        private readonly IHtmlBuilderState _builderState;

        public HtmlHelperContext(HtmlHelper<TModel> htmlHelper)
            : base(htmlHelper.ViewContext, htmlHelper.ViewDataContainer, htmlHelper.RouteCollection)
        {
            _builderState = new HtmlBuilderState();
        }

        #region IHtmlHelperContext Members

        public void Dispose()
        {
        }

        public IDictionary<string, object> HtmlAttributes
        {
            get { return _builderState.HtmlAttributes; }
        }

        public IDictionary<string, object> InstanceData
        {
            get { return _builderState.InstanceData; }
        }

        #endregion
    }

    public class HtmlHelperContext : HtmlHelper, IHtmlHelperContext
    {
        private readonly IHtmlBuilderState _builderState;

        public HtmlHelperContext(HtmlHelper htmlHelper)
            : base(htmlHelper.ViewContext, htmlHelper.ViewDataContainer, htmlHelper.RouteCollection)
        {
            _builderState = new HtmlBuilderState();
        }

        #region IHtmlHelperContext Members

        public void Dispose()
        {
        }

        public IDictionary<string, object> HtmlAttributes
        {
            get { return _builderState.HtmlAttributes; }
        }

        public IDictionary<string, object> InstanceData
        {
            get { return _builderState.InstanceData; }
        }

        #endregion

        public static THtmlHelper MergeHelperContext<THtmlHelper>(THtmlHelper helper,
                                                                  IHtmlBuilderState target) where THtmlHelper : HtmlHelper
        {
            if (helper != null)
            {
                var castedHelper = helper as IHtmlHelperContext;
                if (castedHelper != null)
                {
                    helper.ViewContext.HttpContext.Trace.Write("Merging");
                    target.HtmlAttributes.AddRange(castedHelper.HtmlAttributes, true);
                    target.InstanceData.AddRange(castedHelper.InstanceData, true);
                }
            }
            return helper;
        }
    }
}