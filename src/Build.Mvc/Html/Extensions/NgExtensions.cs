namespace Build.Mvc.Html
{
    /// <summary>
    /// Extensions for Angular.js
    /// </summary>
    public static class NgExtensions
    {
        /// <summary>
        /// Sets the ng-model attribute
        /// </summary>
        public static TBuilder NgModel<TBuilder>(this TBuilder builder, string expression, NgBinding bindingStyle = NgBinding.AsAttribute) where TBuilder : IHtmlAttributes
        {
            return Apply(builder, "ng-model", expression, bindingStyle);
        }

        /// <summary>
        /// Sets the ng-click attribute
        /// </summary>
        public static TBuilder NgClick<TBuilder>(this TBuilder builder, string expression, NgBinding bindingStyle = NgBinding.AsAttribute) where TBuilder : IHtmlAttributes
        {
            return Apply(builder, "ng-click", expression, bindingStyle);
        }

        /// <summary>
        /// Sets the ng-checked attribute
        /// </summary>
        public static TBuilder NgChecked<TBuilder>(this TBuilder builder, string expression, NgBinding bindingStyle = NgBinding.AsAttribute) where TBuilder : ICheckableFormInputBuilder
        {
            return Apply(builder, "ng-checked", expression, bindingStyle);
        }

        /// <summary>
        /// Sets the ng-disabled attribute
        /// </summary>
        public static TBuilder NgDisabled<TBuilder>(this TBuilder builder, string expression, NgBinding bindingStyle = NgBinding.AsAttribute) where TBuilder : ICheckableFormInputBuilder
        {
            return Apply(builder, "ng-disabled", expression, bindingStyle);
        }

        /// <summary>
        /// Sets the ng-submit attribute
        /// </summary>
        public static TBuilder NgSubmit<TBuilder>(this TBuilder builder, string expression, NgBinding bindingStyle = NgBinding.AsAttribute) where TBuilder : IMvcFormBuilder
        {
            return Apply(builder, "ng-submit", expression, bindingStyle);
        }

        private static TBuilder Apply<TBuilder>(TBuilder builder, string label, string expression, NgBinding bindingStyle) where TBuilder : IHtmlAttributes
        {
            if ( bindingStyle.HasFlag(NgBinding.AsClass) )
            {
                builder.AddClass(string.Format("{0}:{1};", label, expression));
            }
            if ( bindingStyle.HasFlag(NgBinding.AsAttribute) )
            {
                builder.Attr(label, expression);
            }
            return builder;
        }
    }
}
