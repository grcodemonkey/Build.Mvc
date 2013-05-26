namespace Build.Mvc.Html
{
    /// <summary>
    /// The Angular.js expression binding syntax
    /// </summary>
    public enum NgBinding
    {
        /// <summary>
        /// Uses the ng-attr="{expression}" style binding
        /// </summary>
        AsAttribute = 0x00,
        /// <summary>
        /// Uses the class="ng-attr:{expression};" style binding
        /// </summary>
        AsClass = 0x01,
        /// <summary>
        /// Sets the binding using both syntaxes.
        /// </summary>
        Both = AsAttribute | AsClass
    }
}
