using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Build.Mvc.Html;
using Build.Mvc.TwitterBootstrap.Helpers;

namespace Build.Mvc.TwitterBootstrap
{
    public class SelectListFormGroupConfig<TModel, TProperty> : FormGroupConfig<TModel, TProperty>
    {
        public SelectListFormGroupConfig(HtmlHelper<TModel> html)
            : base(html)
        {
        }

        public new SelectListFormGroupConfig<TModel, TProperty> Label(Action<ILabelBuilder> labelModifier)
        {
            LabelModifier = labelModifier;
            return this;
        }

        public SelectListFormGroupConfig<TModel, TProperty> Select(Action<ISelectListBuilder> selectListModifier)
        {
            SelectListModifier = selectListModifier;
            return this;
        }

        protected Action<ISelectListBuilder> SelectListModifier { get; set; }

        public override IHtmlString RenderControl(FormGroupDisplay display)
        {
            ISelectListBuilder selectListBuilder = Html.BuildDropDownListFor(InitExpression).BuildWith(SelectListModifier);

            return SelectListGroupHelper.Render(Html, selectListBuilder, display, ExpressionHelper.GetExpressionText(InitExpression), () => Html.HiddenFor(InitExpression));
        }
    }

    public class SelectListFormGroupConfig : FormGroupConfig
    {
        public SelectListFormGroupConfig(HtmlHelper html)
            : base(html)
        {
        }

        public new SelectListFormGroupConfig Label(Action<ILabelBuilder> labelModifier)
        {
            LabelModifier = labelModifier;
            return this;
        }

        public SelectListFormGroupConfig Select(Action<ISelectListBuilder> selectListModifier)
        {
            SelectListModifier = selectListModifier;
            return this;
        }

        protected Action<ISelectListBuilder> SelectListModifier { get; set; }

        public override IHtmlString RenderControl(FormGroupDisplay display)
        {
            ISelectListBuilder selectListBuilder = Html.BuildDropDownList(InitExpression).BuildWith(SelectListModifier);

            return SelectListGroupHelper.Render(Html, selectListBuilder, display, ExpressionHelper.GetExpressionText(InitExpression), () => Html.Hidden(InitExpression));
        }
    }
}