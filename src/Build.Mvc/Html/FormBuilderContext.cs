using System.Threading;

namespace Build.Mvc.Html
{
    public class FormBuilderContext : IHorizontalFormSizing
    {
        private IHorizontalFormSizing _horizontalFormSizing;

        public FormRenderStyle FormRenderStyle { get; set; }

        public IHorizontalFormSizing HorizontalFormSizing
        {
            get
            {
                return LazyInitializer.EnsureInitialized(ref _horizontalFormSizing,
                    () => FormRenderStyle == FormRenderStyle.Horizontal ? Html.HorizontalFormSizing.Default() : new HorizontalFormSizing());
            }
        }

        string IHorizontalFormSizing.ControlSize
        {
            get { return HorizontalFormSizing.ControlSize; }
            set { HorizontalFormSizing.ControlSize = value; }
        }

        string IHorizontalFormSizing.LabelSize
        {
            get { return HorizontalFormSizing.LabelSize; }
            set { HorizontalFormSizing.LabelSize = value; }
        }

        string IHorizontalFormSizing.ColOffset
        {
            get { return HorizontalFormSizing.ColOffset; }
            set { HorizontalFormSizing.ColOffset = value; }
        }

        public bool RenderValidationMessages { get; set; }
    }
}