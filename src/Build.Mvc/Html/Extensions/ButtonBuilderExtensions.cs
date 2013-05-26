// -----------------------------------------------------------------------------
// Designed by geeks in Michigan.  Assembled by a compiler near you.
// -----------------------------------------------------------------------------
// 
// Copyright (c) 2011-2012 Jeremy Bell, Laurence Blackledge
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 
// It is pitch black. You are likely to be eaten by a grue.
// 
namespace Build.Mvc.Html
{
    /// <summary>
    /// 
    /// </summary>
    public static class ButtonBuilderExtensions
    {
        /// <summary>
        /// Sets the type for this button to "submit"
        /// </summary>
        /// <typeparam name="TBuilder"></typeparam>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static TBuilder Submit<TBuilder>(this TBuilder instance) where TBuilder : IButtonBuilder
        {
            return instance.Attr("type", "submit");
        }

        /// <summary>
        /// Adds a data-icon-primary or data-icon-scondary attribute to the control (for use with wiring up jquery-ui buttons)
        /// </summary>
        /// <typeparam name="TBuilder">The type of the builder.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="iconName">One of the <see cref="IconName"/> constants or a custom value</param>
        /// <param name="position">The position.</param>
        public static TBuilder Icon<TBuilder>(this TBuilder instance, string iconName, IconPosition position = IconPosition.Left) where TBuilder : ICanHasJQueryIcon
        {
            if (position.HasFlag(IconPosition.Left))
            {
                instance.Data("icon-primary", iconName);
            }
            if (position.HasFlag(IconPosition.Right))
            {
                instance.Data("icon-secondary", iconName);
            }
            return instance;
        }
    }
}