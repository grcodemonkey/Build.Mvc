using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Build.Mvc
{
    /// <summary>
    /// </summary>
    public class HtmlWriter : HtmlTextWriter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlWriter"/> class.
        /// </summary>
        public HtmlWriter()
            : this(new StringWriter {NewLine = string.Empty}, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlWriter"/> class.
        /// </summary>
        /// <param name="writer"> The <see cref="T:System.IO.TextWriter"/> instance that renders the markup content. </param>
        public HtmlWriter(TextWriter writer)
            : base(writer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlWriter"/> class.
        /// </summary>
        /// <param name="writer"> The <see cref="T:System.IO.TextWriter"/> that renders the markup content. </param>
        /// <param name="tabString"> The string to use to render a line indentation. </param>
        public HtmlWriter(TextWriter writer, string tabString)
            : base(writer, tabString)
        {
        }

        /// <summary>
        /// Returns an MvcHtmlString wrapped result.
        /// </summary>
        public HtmlString ToHtml()
        {
            return MvcHtmlString.Create(ToString());
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the inner writer.
        /// </summary>
        public override string ToString()
        {
            return InnerWriter.ToString();
        }
    }
}