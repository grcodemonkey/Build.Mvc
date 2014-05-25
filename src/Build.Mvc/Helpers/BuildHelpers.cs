namespace Build.Mvc.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    internal static class BuildHelpers
    {
        /// <summary>
        /// Creates the label HTML.
        /// </summary>
        public static MvcHtmlString LabelHelper(HtmlHelper html,
                                                ModelMetadata metadata,
                                                string htmlFieldName,
                                                string labelText,
                                                IDictionary<string, object> htmlAttributes)
        {
            string str = labelText ?? (metadata.DisplayName ?? (metadata.PropertyName ?? htmlFieldName.Split(new[] {'.'}).Last()));
            if ( String.IsNullOrEmpty(str) )
            {
                return MvcHtmlString.Empty;
            }
            var tagBuilder = new TagBuilder("label") {InnerHtml = html.Encode(str)};
            tagBuilder.Attributes.Add("for", TagBuilder.CreateSanitizedId(html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName)));
            tagBuilder.MergeAttributes(htmlAttributes, true);
            return tagBuilder.ToMvcHtmlString(TagRenderMode.Normal);
        }

        /// <summary>
        /// Invokes the private static "FormHelper" method of the <see cref="T:System.Web.Mvc.Html.FormExtensions" /> class via reflection.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="formAction">The form action.</param>
        /// <param name="method">The method.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcForm FormHelper(HtmlHelper htmlHelper,
                                         string formAction,
                                         FormMethod method,
                                         IDictionary<string, object> htmlAttributes)
        {
            return (MvcForm) typeof (FormExtensions).InvokeMember("FormHelper",
                                                                  BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.InvokeMethod,
                                                                  null,
                                                                  null,
                                                                  new object[] {htmlHelper, formAction, method, htmlAttributes});
        }
    }
}