namespace Build.Mvc.Html
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    /// <summary>
    /// 
    /// </summary>
    public static class ExtensionsForIListSelectListItem
    {
        /// <summary>
        /// Adds a <seealso cref="T:System.Web.Mvc.SelectListItem"/> to the list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="text">The text.</param>
        /// <param name="value">Sets the value to <c>null</c> if the value is null, otherwise the resulting value from <see cref="System.Convert.ToString()"/> is used.</param>
        /// <param name="selected">if set to <c>true</c> [selected].</param>
        public static void Add(this IList<SelectListItem> list,
                               string text,
                               object value,
                               bool selected = false)
        {
            Add(list, text, value == null ? null : Convert.ToString(value), selected);
        }

        /// <summary>
        /// Adds a <seealso cref="T:System.Web.Mvc.SelectListItem"/> to the list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="text">The text.</param>
        /// <param name="value">The value.</param>
        /// <param name="selected">if set to <c>true</c> [selected].</param>
        public static void Add(this IList<SelectListItem> list,
                               string text,
                               string value = null,
                               bool selected = false)
        {
            list.Add(new SelectListItem {Text = text, Value = value, Selected = selected});
        }
    }
}
