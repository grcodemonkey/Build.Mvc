using System;
using System.Threading;

namespace Build.Mvc.Html
{
    public class HorizontalFormSizing : IHorizontalFormSizing
    {
        private static Func<HorizontalFormSizing> _defaultHorizontalFormSizingValueFactory;

        public static Func<HorizontalFormSizing> DefaultHorizontalFormSizingValueFactory
        {
            get
            {
                return LazyInitializer.EnsureInitialized(ref _defaultHorizontalFormSizingValueFactory, () => () => new HorizontalFormSizing
                {
                    ControlSize = "col-md-10",
                    LabelSize = "col-md-2",
                    ColOffset = "col-md-offset-2"
                });
            }
            set { _defaultHorizontalFormSizingValueFactory = value; }
        }

        public static HorizontalFormSizing Default()
        {
            return DefaultHorizontalFormSizingValueFactory.Invoke();
        }

        public string ControlSize { get; set; }

        public string LabelSize { get; set; }

        public string ColOffset { get; set; }
    }
}