using Build.Mvc.Html;

namespace Build.Mvc.TwitterBootstrap.Helpers
{
    public static class ExtensionsForIColumnSizing
    {
        public static void UpdateSize(this IHorizontalFormSizing target, IHorizontalFormSizing source)
        {
            target.ControlSize = source.ControlSize;
            target.LabelSize = source.LabelSize;
            target.ColOffset = source.ColOffset;
        }
    }
}