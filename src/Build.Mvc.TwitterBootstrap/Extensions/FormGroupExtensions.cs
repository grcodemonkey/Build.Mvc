using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Build.Mvc.TwitterBootstrap
{
    public static class FormGroupExtensions
    {
        /// <summary>
        /// Builds a Twitter Bootstrap style checkbox control group.
        /// </summary>
        public static BootstrapCheckBoxFormGroupBuilder BuildCheckBoxGroup(
            this HtmlHelper html,
            string expression,
            Action<CheckBoxFormGroupConfig> groupConfig = null)
        {
            var config = new CheckBoxFormGroupConfig(html) { InitExpression = expression };

            if (groupConfig != null)
            {
                groupConfig(config);
            }

            return new BootstrapCheckBoxFormGroupBuilder(html, config);
        }

        /// <summary>
        /// Builds a Twitter Bootstrap style checkbox control group.
        /// </summary>
        public static BootstrapCheckBoxFormGroupBuilder<TModel> BuildCheckBoxGroupFor<TModel>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, bool>> expression,
            Action<CheckBoxFormGroupConfig<TModel>> groupConfig = null)
        {
            var config = new CheckBoxFormGroupConfig<TModel>(html) { InitExpression = expression };

            if (groupConfig != null)
            {
                groupConfig(config);
            }

            return new BootstrapCheckBoxFormGroupBuilder<TModel>(html, config);
        }

        /// <summary>
        /// Builds a Twitter Bootstrap style text box control group.
        /// </summary>
        public static BootstrapSelectListFormGroupBuilder BuildDropDownGroup(
            this HtmlHelper html,
            string expression,
            Action<SelectListFormGroupConfig> groupConfig = null)
        {
            var config = new SelectListFormGroupConfig(html) { InitExpression = expression };

            if (groupConfig != null)
            {
                groupConfig(config);
            }

            return new BootstrapSelectListFormGroupBuilder(html, config);
        }

        /// <summary>
        /// Builds a Twitter Bootstrap style select control group.
        /// </summary>
        public static BootstrapSelectListFormGroupBuilder<TModel, TValue> BuildDropDownGroupFor<TModel, TValue>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression,
            Action<SelectListFormGroupConfig<TModel, TValue>> groupConfig = null)
        {
            var config = new SelectListFormGroupConfig<TModel, TValue>(html) { InitExpression = expression };

            if (groupConfig != null)
            {
                groupConfig(config);
            }

            return new BootstrapSelectListFormGroupBuilder<TModel, TValue>(html, config);
        }

        /// <summary>
        /// Builds a Twitter Bootstrap style text box control group.
        /// </summary>
        public static BootstrapTextboxFormGroupBuilder BuildTextBoxGroup(
            this HtmlHelper html,
            string expression,
            Action<TextBoxFormGroupConfig> groupConfig = null)
        {
            var config = new TextBoxFormGroupConfig(html) { InitExpression = expression };

            if (groupConfig != null)
            {
                groupConfig(config);
            }

            return new BootstrapTextboxFormGroupBuilder(html, config);
        }

        /// <summary>
        /// Builds a Twitter Bootstrap style text box control group.
        /// </summary>
        public static BootstrapTextboxFormGroupBuilder<TModel, TValue> BuildTextBoxGroupFor<TModel, TValue>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression,
            Action<TextBoxFormGroupConfig<TModel, TValue>> groupConfig = null)
        {
            var config = new TextBoxFormGroupConfig<TModel, TValue>(html) { InitExpression = expression };

            if (groupConfig != null)
            {
                groupConfig(config);
            }

            return new BootstrapTextboxFormGroupBuilder<TModel, TValue>(html, config);
        }
    }
}