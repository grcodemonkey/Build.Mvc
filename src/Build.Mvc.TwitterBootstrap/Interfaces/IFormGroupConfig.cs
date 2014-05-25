using System.Web;
using Build.Mvc.Html;

namespace Build.Mvc.TwitterBootstrap
{
    public interface IFormGroupConfig : IHorizontalFormSizing
    {
        IHtmlString RenderLabel();
    }
}