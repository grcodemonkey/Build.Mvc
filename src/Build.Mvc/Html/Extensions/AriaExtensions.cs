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
    using System;

    /// <summary>
    /// Adds extensions shortcurs for "aria-" prefixed attributes.
    /// </summary>
    public static class AriaExtensions
    {
        /// <summary>
        /// Sets an ARIA- (Accessible Rich Internet Applications) prefixed HTML attribute
        /// </summary>
        /// <typeparam name="TBuilder">The type of the builder.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="name">One of the <see cref="AriaAttribute" /> constants or a custom value (This method will add the aria- prefix for you)</param>
        /// <param name="value">The value</param>
        public static TBuilder Aria<TBuilder>(this TBuilder instance,
                                              string name,
                                              object value) where TBuilder : IHtmlBuilderState
        {
            FormatName(ref name);
            return instance.Attr(name, value);
        }

        /// <summary>
        /// Gets the ARIA- (Accessible Rich Internet Applications) prefixed HTML attribute value as a string.
        /// </summary>
        /// <typeparam name="TBuilder">The type of the builder.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="name">One of the <see cref="AriaAttribute" /> constants or a custom value (This method will add the aria- prefix for you)</param>
        public static string Aria<TBuilder>(this TBuilder instance,
                                            string name) where TBuilder : IHtmlBuilderState
        {
            return Aria<string>(instance, name);
        }


        /// <summary>
        /// Gets the ARIA- (Accessible Rich Internet Applications) prefixed HTML attribute value.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="name">One of the <see cref="AriaAttribute" /> constants or a custom value (This method will add the aria- prefix for you)</param>
        public static TValue Aria<TValue>(this IHtmlBuilderState instance,
                                          string name)
        {
            FormatName(ref name);
            return instance.Attr<TValue>(name);
        }

        private static void FormatName(ref string name)
        {
            if (name.StartsWith("aria-", StringComparison.InvariantCultureIgnoreCase)) return;
            name = "aria-" + name;
        }
    }
}