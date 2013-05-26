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
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    /// <summary>
    /// An abstract class for all HtmlBuilders that create HTML form markup.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    public abstract class FormInputBuilder<TModel, TProperty> : FormInputBuilder, IHtmlHelper<TModel>
    {
        private HtmlHelper<TModel> _html;

        /// <summary>
        ///     Gets or sets the init expression.
        /// </summary>
        public Expression<Func<TModel, TProperty>> InitExpression { get; set; }

        /// <summary>
        ///     Gets or sets the HtmlHelper
        /// </summary>
        public new HtmlHelper<TModel> Html
        {
            get { return _html; }
            set
            {
                _html = HtmlHelperContext.MergeHelperContext(value, this);
                base.Html = _html;
            }
        }
    }

    /// <summary>
    /// An abstract class for all HtmlBuilders that create HTML form markup.
    /// </summary>
    public abstract class FormInputBuilder : HtmlBuilder, IFormInputBuilder, IHtmlHelper
    {
        private HtmlHelper _html;

        /// <summary>
        ///     Gets or sets the HtmlHelper
        /// </summary>
        public virtual HtmlHelper Html
        {
            get { return _html; }
            set { _html = HtmlHelperContext.MergeHelperContext(value, this); }
        }
    }
}