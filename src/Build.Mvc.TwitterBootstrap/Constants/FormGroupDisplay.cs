namespace Build.Mvc.TwitterBootstrap
{
    public enum FormGroupDisplay
    {
        /// <summary>
        /// Renders normally
        /// </summary>
        Normal = 0,
        /// <summary>
        /// Renders nothing
        /// </summary>
        None,
        /// <summary>
        /// Renders form-group with style="diplay:none"
        /// </summary>
        Hidden,
        /// <summary>
        /// Renders input's value as as static label
        /// </summary>
        ReadOnly,
        /// <summary>
        /// Renders the input's value as a static label with an hidden HTML input for the value.
        /// </summary>
        LabelWithHiddenField
    }
}