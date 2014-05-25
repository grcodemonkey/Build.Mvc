using System;
using System.Web.UI;

namespace Build.Mvc.TwitterBootstrap.Helpers
{
    internal static class CheckBoxGroupHelper
    {
        public static void Render(
            HtmlTextWriter writer,
            IFormGroupConfig config)
        {
            string className = String.Join(" ", new[] {config.ColOffset, config.ControlSize});

            if (!String.IsNullOrWhiteSpace(className))
            {
                writer.AddAttribute("class", className);
                writer.RenderBeginTag("div");
            }

            writer.Write(config.RenderLabel());

            if (!String.IsNullOrWhiteSpace(className))
            {
                writer.RenderEndTag(); // div
            }
        }
    }
}