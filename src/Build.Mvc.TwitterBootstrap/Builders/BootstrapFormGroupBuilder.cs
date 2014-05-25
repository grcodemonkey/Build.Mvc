using System;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Build.Mvc.Html;

namespace Build.Mvc.TwitterBootstrap
{
    public abstract class BootstrapFormGroupBuilder<TFormGroupConfig> : HtmlBuilder where TFormGroupConfig : FormGroupConfig
    {
        protected BootstrapFormGroupBuilder(HtmlHelper html, TFormGroupConfig config)
        {
            Html = html;
            Config = config;
        }

        protected HtmlHelper Html { get; set; }

        protected TFormGroupConfig Config { get; set; }

        public override string ToHtmlString()
        {
            return Render(FormGroupDisplay.Normal).ToHtmlStringSafe();
        }

        public IHtmlString Render(FormGroupDisplay display)
        {
            HtmlAttributes.AddRange(Config.HtmlAttributes);
            InstanceData.AddRange(Config.InstanceData);

            switch (display)
            {
                case FormGroupDisplay.None:
                    return MvcHtmlString.Empty;

                case FormGroupDisplay.Normal:
                    break;

                case FormGroupDisplay.Hidden:
                    this.Css("display", "none");
                    break;
            }

            using (var writer = new HtmlWriter())
            {
                RenderFormGroup(writer, display);
                return writer.ToHtml();
            }
        }

        protected virtual void RenderFormGroup(HtmlTextWriter writer, FormGroupDisplay display)
        {
            this.AddClass("form-group");
            foreach (var htmlAttribute in HtmlAttributes)
            {
                writer.AddAttribute(htmlAttribute.Key, Convert.ToString(htmlAttribute.Value));
            }
            writer.RenderBeginTag("div");

            RenderFormGroupContents(writer, display);

            writer.RenderEndTag(); // div
        }

        protected virtual void RenderFormGroupContents(HtmlTextWriter writer, FormGroupDisplay display)
        {
            writer.Write(Config.RenderLabel());

            bool shouldRenderControlSizeDiv = !string.IsNullOrWhiteSpace(Config.ControlSize);

            if (shouldRenderControlSizeDiv)
            {
                writer.AddAttribute("class", Config.ControlSize);
                writer.RenderBeginTag("div");
            }

            writer.Write(Config.RenderControl(display));

            if (shouldRenderControlSizeDiv)
            {
                writer.RenderEndTag(); // div
            }
        }
    }
}