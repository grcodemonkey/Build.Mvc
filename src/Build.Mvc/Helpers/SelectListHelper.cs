using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Build.Mvc.Html;

namespace Build.Mvc.Helpers
{
    public static class SelectListHelper
    {
        public static IEnumerable<SelectListItem> GetSelectListItemsFromViewData(this HtmlHelper htmlHelper, string name)
        {
            IEnumerable<SelectListItem> selectList = null;
            if (htmlHelper.ViewData != null)
            {
                selectList = htmlHelper.ViewData.Eval(name) as IEnumerable<SelectListItem>;
            }
            return selectList ?? Enumerable.Empty<SelectListItem>();
        }

        public static IEnumerable<SelectListItem> GetSelectListItems(HtmlHelper html, ISelectListBuilder dropDownList, string expressionText)
        {
            string fullHtmlFieldName = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(expressionText);

            bool flag = false;

            IEnumerable<SelectListItem> selectList = dropDownList.SelectList();
            bool allowMultiple = dropDownList.Attr("multiple") == "multiple";

            if (selectList == null)
            {
                selectList = html.GetSelectListItemsFromViewData(expressionText);
                flag = true;
            }
            object defaultValue = allowMultiple ? html.GetModelStateValue(fullHtmlFieldName, typeof(string[])) : html.GetModelStateValue(fullHtmlFieldName, typeof(string));
            if (!flag && defaultValue == null && !String.IsNullOrEmpty(expressionText))
            {
                defaultValue = html.ViewData.Eval(expressionText);
            }
            if (defaultValue != null)
            {
                selectList = GetSelectListWithDefaultValue(selectList, defaultValue, allowMultiple);
            }
            return selectList;
        }

        public static IEnumerable<SelectListItem> GetSelectListWithDefaultValue(IEnumerable<SelectListItem> selectList, object defaultValue, bool allowMultiple)
        {
            IEnumerable source;
            if (allowMultiple)
            {
                source = defaultValue as IEnumerable;
                if (source == null || source is string)
                {
                    throw new InvalidOperationException("defaultValue must be an IEnumerable type when allowMultiple is enabled");
                }
            }
            else
            {
                source = new[] { defaultValue };
            }
            var hashSet = new HashSet<string>(source.Cast<object>().Select(value => Convert.ToString(value, CultureInfo.CurrentCulture)), StringComparer.OrdinalIgnoreCase);
            var list = new List<SelectListItem>();
            foreach (SelectListItem selectListItem in selectList)
            {
                selectListItem.Selected = selectListItem.Value != null ? hashSet.Contains(selectListItem.Value) : hashSet.Contains(selectListItem.Text);
                list.Add(selectListItem);
            }
            return list;
        }

        internal static string ListItemToOption(SelectListItem item)
        {
            var tagBuilder = new TagBuilder("option")
            {
                InnerHtml = HttpUtility.HtmlEncode(item.Text)
            };
            if (item.Value != null)
            {
                tagBuilder.Attributes["value"] = item.Value;
            }
            if (item.Selected)
            {
                tagBuilder.Attributes["selected"] = "selected";
            }
            return tagBuilder.ToString(TagRenderMode.Normal);
        }
    }
}