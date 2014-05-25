using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace Build.Mvc.Helpers
{
    public static class LabelHelper
    {
        public static string RenderCheckboxLabelHtml(HtmlHelper htmlHelper, string expression, string labelText, string checkBoxHtml, object htmlAttributes = null)
        {
            return RenderCheckboxLabelHtml(htmlHelper, expression, labelText, checkBoxHtml, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static string RenderCheckboxLabelHtml(HtmlHelper htmlHelper, string expression, string labelText, string checkBoxHtml, IDictionary<string, object> htmlAttributes = null)
        {
            var divBuilder = new TagBuilder("div")
            {
                InnerHtml = RenderLabel(htmlHelper, expression, String.Concat(checkBoxHtml, " ", htmlHelper.Encode(labelText)), htmlAttributes).ToHtmlStringSafe()
            };

            divBuilder.AddCssClass("checkbox");

            return divBuilder.ToString(TagRenderMode.Normal);
        }

        private static IHtmlString RenderLabel(
            HtmlHelper html,
            string htmlFieldName,
            string innerText = null,
            IDictionary<string, object> htmlAttributes = null)
        {
            var tagBuilder = new TagBuilder("label");
            tagBuilder.Attributes.Add("for", TagBuilder.CreateSanitizedId(html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName)));
            tagBuilder.InnerHtml = innerText;
            tagBuilder.MergeAttributes(htmlAttributes, true);
            return tagBuilder.ToMvcHtmlString(TagRenderMode.Normal);
        }
    }
}