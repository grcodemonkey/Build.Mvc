using System;
using System.Web;
using System.Web.Mvc;
using Build.Mvc.Html;

namespace Build.Mvc.TwitterBootstrap
{
    public class CheckBoxFormGroupConfig<TModel> : FormGroupConfig<TModel, bool>, IFormGroupConfig
    {
        public CheckBoxFormGroupConfig(HtmlHelper<TModel> html)
            : base(html)
        {
        }

        public new CheckBoxFormGroupConfig<TModel> Label(Action<ILabelBuilder> labelModifier)
        {
            LabelModifier = labelModifier;
            return this;
        }

        public CheckBoxFormGroupConfig<TModel> CheckBox(Action<ICheckBoxBuilder> checkBoxModifier)
        {
            CheckBoxModifier = checkBoxModifier;
            return this;
        }

        protected Action<ICheckBoxBuilder> CheckBoxModifier { get; set; }

        public override IHtmlString RenderControl(FormGroupDisplay display)
        {
            return MvcHtmlString.Empty;
        }

        public override IHtmlString RenderLabel()
        {
            return new CheckboxLabelBuilder<TModel> {Html = Html, InitExpression = InitExpression}.
                WithCheckbox(CheckBoxModifier).
                BuildWith(LabelModifier);
        }
    }

    public class CheckBoxFormGroupConfig : FormGroupConfig, IFormGroupConfig
    {
        public CheckBoxFormGroupConfig(HtmlHelper html)
            : base(html)
        {
        }

        public new CheckBoxFormGroupConfig Label(Action<ILabelBuilder> labelModifier)
        {
            LabelModifier = labelModifier;
            return this;
        }

        public CheckBoxFormGroupConfig CheckBox(Action<ICheckBoxBuilder> checkBoxModifier)
        {
            CheckBoxModifier = checkBoxModifier;
            return this;
        }

        protected Action<ICheckBoxBuilder> CheckBoxModifier { get; set; }

        public override IHtmlString RenderControl(FormGroupDisplay display)
        {
            return MvcHtmlString.Empty;
        }

        public override IHtmlString RenderLabel()
        {
            return new CheckboxLabelBuilder {Html = Html}.
                Named(InitExpression).
                WithCheckbox(CheckBoxModifier).
                BuildWith(LabelModifier);
        }
    }
}