using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Build.Mvc.Helpers;
using Build.Mvc.Html;

namespace Build.Mvc.TwitterBootstrap.Helpers
{
    public static class SelectListGroupHelper
    {
        public static IHtmlString Render(HtmlHelper html, ISelectListBuilder selectListBuilder, FormGroupDisplay display, string expressionText, Func<MvcHtmlString> hiddenField)
        {
            bool readOnlyMode = display == FormGroupDisplay.ReadOnly, labelWithHiddenFieldMode = display == FormGroupDisplay.LabelWithHiddenField;

            if (readOnlyMode || labelWithHiddenFieldMode)
            {
                var builder = new HtmlTagBuilder("div");

                builder.Attr(selectListBuilder.HtmlAttributes);

                IEnumerable<SelectListItem> selectList = SelectListHelper.GetSelectListItems(html, selectListBuilder, expressionText);

                builder.InternalBuilder.InnerHtml = GetDisplayText(selectList);

                if (labelWithHiddenFieldMode)
                {
                    builder.InternalBuilder.InnerHtml += hiddenField();
                }

                return MvcHtmlString.Create(builder.ToHtmlString());
            }

            return selectListBuilder.AddClass("form-control");
        }

        private static string GetDisplayText(IEnumerable<SelectListItem> selectList)
        {
            var stringBuilder = new StringBuilder();

            foreach (SelectListItem selectListItem in selectList.Where(x => x.Selected))
            {
                var builder = new HtmlTagBuilder("p");
                builder.AddClass("form-control-static");
                builder.InternalBuilder.SetInnerText(selectListItem.Text);
                stringBuilder.Append(builder.ToHtmlString());
            }

            return stringBuilder.ToString();
        }
    }
}