using System.Web.Mvc;

namespace Build.Mvc.TwitterBootstrap
{
    public class BootstrapSelectListFormGroupBuilder : BootstrapFormGroupBuilder<SelectListFormGroupConfig>
    {
        public BootstrapSelectListFormGroupBuilder(HtmlHelper html, SelectListFormGroupConfig config)
            : base(html, config)
        {
        }
    }

    public class BootstrapSelectListFormGroupBuilder<TModel, TProperty> : BootstrapFormGroupBuilder<SelectListFormGroupConfig<TModel, TProperty>>
    {
        public BootstrapSelectListFormGroupBuilder(HtmlHelper html, SelectListFormGroupConfig<TModel, TProperty> config)
            : base(html, config)
        {
        }
    }
}