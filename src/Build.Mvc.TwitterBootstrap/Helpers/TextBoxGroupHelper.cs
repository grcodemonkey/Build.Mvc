using System;
using System.Web;
using System.Web.Mvc;
using Build.Mvc.Html;

namespace Build.Mvc.TwitterBootstrap.Helpers
{
    internal static class TextBoxGroupHelper
    {
        public static IHtmlString Render(HtmlHelper html, ITextBoxBuilder textBoxBuilder, FormGroupDisplay display, Func<object> valueFactory, Func<MvcHtmlString> hiddenField)
        {
            bool readOnlyMode = display == FormGroupDisplay.ReadOnly, labelWithHiddenFieldMode = display == FormGroupDisplay.LabelWithHiddenField;

            if (readOnlyMode || labelWithHiddenFieldMode)
            {
                var value = valueFactory();

                var builder = new HtmlTagBuilder("p");
                builder.Attr(textBoxBuilder.HtmlAttributes);
                builder.AddClass("form-control-static");
                builder.InternalBuilder.SetInnerText(html.FormatValue(value, textBoxBuilder.Format()));

                if (labelWithHiddenFieldMode)
                {
                    builder.InternalBuilder.InnerHtml += hiddenField();
                }

                return builder;
            }

            return textBoxBuilder.AddClass("form-control");
        }
    }
}