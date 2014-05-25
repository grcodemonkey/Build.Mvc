using Build.Mvc.Html;

namespace Build.Mvc.TwitterBootstrap
{
    public static class ExtensionsForIHorizontalFormSizing
    {
        public static T ScreenReaderOnly<T>(this T builder, string className) where T : ILabelBuilder
        {
            return builder.AddClass("sr-only");
        }

        public static T SetColOffset<T>(this T formSizing, int size, string template = "col-md-offset-{0}") where T : IHorizontalFormSizing
        {
            return SetColOffset(formSizing, string.Format(template, size));
        }

        public static T SetColOffset<T>(this T formSizing, string className) where T : IHorizontalFormSizing
        {
            formSizing.ColOffset = className;
            return formSizing;
        }

        public static T SetControlSize<T>(this T formSizing, int size, string template = "col-md-{0}") where T : IHorizontalFormSizing
        {
            return SetControlSize(formSizing, string.Format(template, size));
        }

        public static T SetControlSize<T>(this T formSizing, string className) where T : IHorizontalFormSizing
        {
            formSizing.ControlSize = className;
            return formSizing;
        }

        public static T SetLabelSize<T>(this T formSizing, int size, string template = "col-md-{0}") where T : IHorizontalFormSizing
        {
            return SetLabelSize(formSizing, string.Format(template, size));
        }

        public static T SetLabelSize<T>(this T formSizing, string className) where T : IHorizontalFormSizing
        {
            formSizing.LabelSize = className;
            return formSizing;
        }
    }
}