namespace Build.Mvc.Html
{
    /// <summary>
    /// 
    /// </summary>
    public static class ExtensionsForIValidationMessageBuilder
    {
        /// <summary>
        /// Gets the modelName property
        /// </summary>
        public static string ModelName<TBuilder>(this TBuilder instance) where TBuilder : IValidationMessageBuilder
        {
            return instance.Prop<string>("modelName");
        }

        /// <summary>
        /// Sets the modelName property
        /// </summary>
        public static TBuilder ModelName<TBuilder>(this TBuilder instance,
                                                   string value) where TBuilder : IValidationMessageBuilder
        {
            return instance.Prop("modelName", value);
        }
    }
}