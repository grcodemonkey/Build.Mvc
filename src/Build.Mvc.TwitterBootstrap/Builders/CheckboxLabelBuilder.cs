using System;
using System.Web.Mvc;
using Build.Mvc.Helpers;
using Build.Mvc.Html;

namespace Build.Mvc.TwitterBootstrap
{
    public class CheckboxLabelBuilder<TModel> : FormInputBuilder<TModel, bool>, ILabelBuilder, ICheckBoxBuilder
    {
        public Action<ICheckBoxBuilder> CheckBoxModifier { get; set; }

        public override string ToHtmlString()
        {
            string expression = ExpressionHelper.GetExpressionText(InitExpression);

            string labelText = Html.GetLabelText(InitExpression, this.LabelText());

            string checkBoxHtml = Html.BuildCheckBoxFor(InitExpression).BuildWith(CheckBoxModifier).ToHtmlStringSafe();

            return LabelHelper.RenderCheckboxLabelHtml(Html, expression, labelText, checkBoxHtml, HtmlAttributes);
        }
        public CheckboxLabelBuilder<TModel> WithCheckbox(Action<ICheckBoxBuilder> checkBoxModifier)
        {
            CheckBoxModifier = checkBoxModifier;
            return this;
        }
    }

    public class CheckboxLabelBuilder : FormInputBuilder, ILabelBuilder, IExpressionBuilder, ICheckBoxBuilder
    {
        public Action<ICheckBoxBuilder> CheckBoxModifier { get; set; }

        public override string ToHtmlString()
        {
            string expression = this.Name();

            string labelText = Html.GetLabelText(expression, this.LabelText());

            var checkBox = Html.BuildCheckBox(expression, this.IsChecked().GetValueOrDefault()).BuildWith(CheckBoxModifier);

            string checkboxId = checkBox.Id();
            string checkboxName = checkBox.Name();

            string checkboxHtml = checkBox.ToHtmlStringSafe();

            PreventCheckboxNameAndIdFromBeingCopiedToLabel(checkboxName, checkboxId);

            return LabelHelper.RenderCheckboxLabelHtml(Html, expression, labelText, checkboxHtml, HtmlAttributes);
        }

        public CheckboxLabelBuilder WithCheckbox(Action<ICheckBoxBuilder> checkBoxModifier)
        {
            CheckBoxModifier = checkBoxModifier;
            return this;
        }

        private void PreventCheckboxNameAndIdFromBeingCopiedToLabel(string checkboxName, string checkboxId)
        {
            if (HtmlAttributes.Get<string>("name") == checkboxName)
            {
                HtmlAttributes.Remove("name");
            }

            if (HtmlAttributes.Get<string>("id") == checkboxId)
            {
                HtmlAttributes.Remove("id");
            }
        }
    }
}