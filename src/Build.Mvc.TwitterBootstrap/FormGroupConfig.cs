using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Build.Mvc.Html;
using Build.Mvc.TwitterBootstrap.Helpers;

namespace Build.Mvc.TwitterBootstrap
{
    public abstract class FormGroupConfig<TModel, TProperty> : FormGroupConfig
    {
        protected FormGroupConfig(HtmlHelper<TModel> html)
            : base(html)
        {
            Html = html;
        }

        public new HtmlHelper<TModel> Html { get; set; }

        public new Expression<Func<TModel, TProperty>> InitExpression { get; set; }

        public new FormGroupConfig<TModel, TProperty> Label(Action<ILabelBuilder> labelModifier)
        {
            LabelModifier = labelModifier;
            return this;
        }
        public override IHtmlString RenderLabel()
        {
            return Html.BuildLabelFor(InitExpression).
                AddClass("control-label").
                AddClassWhen(!string.IsNullOrEmpty(LabelSize), LabelSize).
                BuildWith(LabelModifier);
        }
    }

    public abstract class FormGroupConfig : HtmlBuilderState, IHorizontalFormSizing
    {
        protected FormGroupConfig(HtmlHelper html)
        {
            Html = html;
            this.UpdateSize(FormBuilderContext.HorizontalFormSizing);
        }

        public string ColOffset { get; set; }

        public string ControlSize { get; set; }

        public FormBuilderContext FormBuilderContext
        {
            get { return Html.GetFormBuilderContext(); }
        }

        public HtmlHelper Html { get; set; }

        public string InitExpression { get; set; }

        public string LabelSize { get; set; }

        protected Action<ILabelBuilder> LabelModifier { get; set; }

        public virtual FormGroupConfig Label(Action<ILabelBuilder> labelModifier)
        {
            LabelModifier = labelModifier;
            return this;
        }

        public abstract IHtmlString RenderControl(FormGroupDisplay display);

        public virtual IHtmlString RenderLabel()
        {
            return Html.BuildLabel(InitExpression).
                AddClass("control-label").
                AddClassWhen(!string.IsNullOrEmpty(LabelSize), LabelSize).
                BuildWith(LabelModifier);
        }
    }
}