using System.Web.Mvc;
using System.Web.UI;
using Build.Mvc.TwitterBootstrap.Helpers;

namespace Build.Mvc.TwitterBootstrap
{
    public class BootstrapCheckBoxFormGroupBuilder : BootstrapFormGroupBuilder<CheckBoxFormGroupConfig>
    {
        public BootstrapCheckBoxFormGroupBuilder(HtmlHelper html, CheckBoxFormGroupConfig config)
            : base(html, config)
        {
        }

        protected override void RenderFormGroupContents(HtmlTextWriter writer, FormGroupDisplay display)
        {
            CheckBoxGroupHelper.Render(writer, Config);
        }
    }

    public class BootstrapCheckBoxFormGroupBuilder<TModel> : BootstrapFormGroupBuilder<CheckBoxFormGroupConfig<TModel>>
    {
        public BootstrapCheckBoxFormGroupBuilder(HtmlHelper html, CheckBoxFormGroupConfig<TModel> config)
            : base(html, config)
        {
        }

        protected override void RenderFormGroupContents(HtmlTextWriter writer, FormGroupDisplay display)
        {
            CheckBoxGroupHelper.Render(writer, Config);
        }
    }
}