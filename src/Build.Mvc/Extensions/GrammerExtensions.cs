namespace Build.Mvc
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public static class GrammerExtensions
    {
        /// <summary>
        /// Executes the specified <paramref name="conditionalAction"></paramref> only if the <paramref name="condition"></paramref> is <c>true</c>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="condition">if set to <c>true</c> the action is executed.</param>
        /// <param name="conditionalAction">The conditional action.</param>
        /// <returns></returns>
        public static T When<T>(this T instance,
                                bool condition,
                                Action<T> conditionalAction)
        {
            if (condition)
            {
                conditionalAction.Invoke(instance);
            }
            return instance;
        }
    }
}
