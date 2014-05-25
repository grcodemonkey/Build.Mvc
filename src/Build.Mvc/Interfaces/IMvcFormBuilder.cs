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

using System.Web.Mvc.Html;
using Build.Mvc.Html;

namespace Build.Mvc
{
    /// <summary>
    /// </summary>
    public interface IMvcFormBuilder : ILinkTargetBuilder, IRouteBuilder, IAutocompleteAttributeBuilder, IHtmlBuilder
    {
        /// <summary>
        /// Gets or sets the form method.
        /// </summary>
        /// <value>
        /// The form method.
        /// </value>
        System.Web.Mvc.FormMethod FormMethod { get; set; }

        /// <summary>
        /// Starts the form tag in the same way that the standard Html.BeginForm() method works.
        /// </summary>
        /// <paramref name="style"> FormRenderStyle.Inline adds css class "form-inline" and FormRenderStyle.Horizontal adds css class "form-horizontal" </paramref>
        /// <returns> </returns>
        MvcForm Begin(FormRenderStyle style = FormRenderStyle.Default);
    }
}