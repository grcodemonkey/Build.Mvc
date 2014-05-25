using System.Web.Mvc;

namespace Build.Mvc.TwitterBootstrap
{
    public class BootstrapTextboxFormGroupBuilder : BootstrapFormGroupBuilder<TextBoxFormGroupConfig>
    {
        public BootstrapTextboxFormGroupBuilder(HtmlHelper html, TextBoxFormGroupConfig config) : base(html, config)
        {
        }
    }

    public class BootstrapTextboxFormGroupBuilder<TModel, TProperty> : BootstrapFormGroupBuilder<TextBoxFormGroupConfig<TModel, TProperty>>
    {
        public BootstrapTextboxFormGroupBuilder(HtmlHelper html, TextBoxFormGroupConfig<TModel, TProperty> config) : base(html, config)
        {
        }
    }
}