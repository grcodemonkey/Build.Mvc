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
    using System.Web.Mvc;

    /// <summary>
    /// A builder for creating HTML button markup.
    /// </summary>
    public class ButtonBuilder : FormInputBuilder, IButtonBuilder
    {
        public override string ToHtmlString()
        {
            UIStates uiState = this.UIState();

            this.Aria("disabled", "false");

            this.AddClassWhen(uiState.HasFlag(UIStates.Primary), "ui-priority-primary");
            this.AddClassWhen(uiState.HasFlag(UIStates.Secondary), "ui-priority-secondary");
			this.AddClassWhen(uiState.HasFlag(UIStates.Highlight), "ui-state-highlight");
			this.AddClassWhen(uiState.HasFlag(UIStates.Active), "ui-state-active");
			this.AddClassWhen(uiState.HasFlag(UIStates.Error), "ui-state-error");

            this.BuildWhen(uiState.HasFlag(UIStates.Disabled),
                      x =>
                          {
                              x.Attr("disabled", "disabled");
                              x.AddClass("ui-state-disabled");
                              x.Aria("disabled", "true");
                          });

            this.DefaultAttr("aria-role", "button");
            this.DefaultAttr("type", "button");

            this.DefaultProp("tagName", "button");

            var tagName = this.Prop<string>("tagName");

            var tagBuilder = new TagBuilder(tagName);

            if ( string.Compare(tagName, "input", StringComparison.InvariantCultureIgnoreCase) == 0 )
            {
                this.DefaultAttr("value", this.Val());
            }
            else
            {
                tagBuilder.InnerHtml = Convert.ToString(this.Val());
            }
            tagBuilder.MergeAttributes(HtmlAttributes, true);

            return tagBuilder.ToString(TagRenderMode.Normal);
        }
    }
}