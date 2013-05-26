namespace Build.Mvc.Helpers
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public static class SurroundWithTemplateHelper
    {
        private const string key = "SurroundWithTemplate";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static string ApplySurroundWithTemplate(this IInstanceData instance, string result)
        {
            return instance.InstanceData.ContainsKey(key) ? String.Format(instance.InstanceData.Get<string>(key), result) : result;
        }
    }
}