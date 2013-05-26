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

namespace Build.Mvc
{
    /// <summary>
    /// </summary>
    public static class PropExtensions
    {
        /// <summary>
        ///     Sets the specified data name/value pair only when it does not already exist.
        /// </summary>
        public static TBuilder DefaultProp<TBuilder>(this TBuilder instance,
                                                     string name,
                                                     object value) where TBuilder : IInstanceData
        {
            if ( !instance.InstanceData.ContainsKey(name) )
            {
                instance.Prop(name, value);
            }
            return instance;
        }

        /// <summary>
        ///     Sets the specified instance data name/value pair.
        /// </summary>
        public static TBuilder Prop<TBuilder>(this TBuilder instance,
                                              string name,
                                              object value) where TBuilder : IInstanceData
        {
            if ( string.IsNullOrEmpty(name) )
            {
                return instance;
            }

            if ( value == null )
            {
                instance.InstanceData.Remove(name);
            }
            else
            {
                instance.InstanceData.Set(name, value);
            }
            return instance;
        }

        /// <summary>
        ///     Props the specified instance.
        /// </summary>
        /// <typeparam name="TBuilder">The type of the builder.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static TBuilder Prop<TBuilder>(this TBuilder instance,
                                              object value) where TBuilder : IInstanceData
        {
            if ( value == null )
            {
                return instance;
            }

            return instance.Prop(value.GetType().TypeNameKey(), value);
        }

        /// <summary>
        ///     Props the specified instance.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static TValue Prop<TValue>(this IInstanceData instance,
                                          string name)
        {
            return instance.InstanceData.Get<TValue>(name);
        }

        /// <summary>
        ///     Props the specified instance.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        public static TValue Prop<TValue>(this IInstanceData instance)
        {
            return instance.Prop<TValue>(typeof (TValue).TypeNameKey());
        }

        /// <summary>
        ///     Props the when.
        /// </summary>
        /// <typeparam name="TBuilder">The type of the builder.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="condition">
        ///     if set to <c>true</c> [condition].
        /// </param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static TBuilder PropWhen<TBuilder>(this TBuilder instance,
                                                  bool condition,
                                                  string name,
                                                  object value) where TBuilder : IInstanceData
        {
            if ( condition )
            {
                return instance.Prop(name, value);
            }
            return instance;
        }

        /// <summary>
        ///     Removes the specified data from the instance data collection.
        /// </summary>
        public static TBuilder RemoveProp<TBuilder>(this TBuilder instance,
                                                    string name) where TBuilder : IHtmlBuilder
        {
            if ( instance.InstanceData.ContainsKey(name) )
            {
                instance.InstanceData.Remove(name);
            }
            return instance;
        }

        /// <summary>
        ///     Remove the specified data name/value pair only when the specified <paramref name="condition"></paramref> is <c>true</c>.
        /// </summary>
        public static TBuilder RemovePropWhen<TBuilder>(this TBuilder instance,
                                                        bool condition,
                                                        string name) where TBuilder : IHtmlBuilder
        {
            if ( condition )
            {
                return instance.RemoveProp(name);
            }
            return instance;
        }
    }
}