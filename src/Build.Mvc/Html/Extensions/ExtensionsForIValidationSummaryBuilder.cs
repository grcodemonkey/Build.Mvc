namespace Build.Mvc.Html
{
    /// <summary>
    /// 
    /// </summary>
    public static class ExtensionsForIValidationSummaryBuilder
    {
        /// <summary>
        /// Gets the ExcludePropertyErrors property
        /// </summary>
        public static bool ExcludePropertyErrors<TBuilder>(this TBuilder instance) where TBuilder : IValidationSummaryBuilder
        {
            return instance.Prop<bool>("excludePropertyErrors");
        }

        /// <summary>
        /// Sets the ExcludePropertyErrors property
        /// </summary>
        public static TBuilder ExcludePropertyErrors<TBuilder>(this TBuilder instance,
                                                               bool value) where TBuilder : IValidationSummaryBuilder
        {
            return instance.Prop("excludePropertyErrors", value);
        }
    }
}