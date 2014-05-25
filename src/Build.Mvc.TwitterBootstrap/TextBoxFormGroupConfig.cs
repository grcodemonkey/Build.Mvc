using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Build.Mvc.Helpers;
using Build.Mvc.Html;
using Build.Mvc.TwitterBootstrap.Helpers;

namespace Build.Mvc.TwitterBootstrap
{
    public class TextBoxFormGroupConfig<TModel, TProperty> : FormGroupConfig<TModel, TProperty>
    {
        public TextBoxFormGroupConfig(HtmlHelper<TModel> html)
            : base(html)
        {
        }

        public new TextBoxFormGroupConfig<TModel, TProperty> Label(Action<ILabelBuilder> labelModifier)
        {
            LabelModifier = labelModifier;
            return this;
        }

        public TextBoxFormGroupConfig<TModel, TProperty> TextBox(Action<ITextBoxBuilder> textBoxModifier)
        {
            TextBoxModifier = textBoxModifier;
            return this;
        }

        protected Action<ITextBoxBuilder> TextBoxModifier { get; set; }

        public override IHtmlString RenderControl(FormGroupDisplay display)
        {
            ITextBoxBuilder textBoxBuilder = Html.BuildTextBoxFor(InitExpression).BuildWith(TextBoxModifier);

            return TextBoxGroupHelper.Render(Html, textBoxBuilder, display, () => Html.GetInputValue(textBoxBuilder, InitExpression), () => Html.HiddenFor(InitExpression));
        }
    }

    public class TextBoxFormGroupConfig : FormGroupConfig
    {
        public TextBoxFormGroupConfig(HtmlHelper html) : base(html)
        {
        }

        public new TextBoxFormGroupConfig Label(Action<ILabelBuilder> labelModifier)
        {
            LabelModifier = labelModifier;
            return this;
        }

        public TextBoxFormGroupConfig TextBox(Action<ITextBoxBuilder> textBoxModifier)
        {
            TextBoxModifier = textBoxModifier;
            return this;
        }

        protected Action<ITextBoxBuilder> TextBoxModifier { get; set; }

        public override IHtmlString RenderControl(FormGroupDisplay display)
        {
            ITextBoxBuilder textBoxBuilder = Html.BuildTextBox(InitExpression).BuildWith(TextBoxModifier);

            return TextBoxGroupHelper.Render(Html, textBoxBuilder, display, () => Html.GetInputValue(textBoxBuilder, InitExpression, textBoxBuilder.Val(), true), () => Html.Hidden(InitExpression));
        }
    }
}