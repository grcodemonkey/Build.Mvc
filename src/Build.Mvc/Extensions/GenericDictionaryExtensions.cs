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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;

namespace Build.Mvc
{
    /// <summary>
    /// 
    /// </summary>
    public static class GenericDictionaryExtensions
    {
        /// <summary>
        /// Adds the specified entry to the dictionary
        /// </summary>
        public static void Add<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
                                             KeyValuePair<TKey, TValue> entry)
        {
            Contract.Assume(dictionary != null, "dictionary is null.");
            dictionary.Add(entry.Key, entry.Value);
        }

        /// <summary>
        /// Iteratively adds values from the source dictionary to the target dictionary.  If the target dictionary already contains a key specified by an entry, it will be ignored.
        /// </summary>
        public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
                                                  IEnumerable<KeyValuePair<TKey, TValue>> entries)
        {
            const bool replaceExisting = false;
            AddRange(dictionary, entries, replaceExisting);
        }

        /// <summary>
        /// Iteratively adds values from the source dictionary to the target dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="entries">The entries.</param>
        /// <param name="replaceExisting">when <c>true</c>, an entry in the target dictionary will be replaced by the one from the source dictionary</param>
        public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
                                                  IEnumerable<KeyValuePair<TKey, TValue>> entries,
                                                  bool replaceExisting)
        {
            if ( entries == null )
            {
                return;
            }
            foreach (var entry in entries)
            {
                if ( replaceExisting )
                {
                    dictionary.Set(entry.Key, entry.Value);
                }
                else if ( !dictionary.ContainsKey(entry.Key) )
                {
                    dictionary.Add(entry);
                }
            }
        }

        /// <summary>
        /// Adds values to the target dictionary by iterating over the source object's properties.  Property names such as "data_icon" are not modified by this method.
        /// </summary>
        public static void AddValues(this IDictionary<string, object> dictionary,
                                     object value)
        {
            if ( value == null )
            {
                return;
            }
            foreach (PropertyDescriptor desc in TypeDescriptor.GetProperties(value))
            {
                dictionary.Add(desc.Name, desc.GetValue(value));
            }
        }

        /// <summary>
        /// Gets the value of the specified key cast as type of TValue
        /// </summary>
        public static TValue Get<TValue>(this IDictionary<string, object> dictionary, string key)
        {
            Contract.Assume(dictionary != null, "dictionary is null.");
            Contract.Assume(!String.IsNullOrEmpty(key), "key is null or empty.");
            object value;
            if ( dictionary.TryGetValue(key, out value) )
            {
                return (TValue) value;
            }
            return default(TValue);
        }

        public static TValue GetOrAdd<TValue>(this IDictionary<string, object> dictionary,
                                              string key,
                                              Func<string, TValue> valueFactory)
        {
            return dictionary.GetOrAdd(key, valueFactory.Invoke(key));
        }

        public static TValue GetOrAdd<TValue>(this IDictionary<string, object> dictionary,
                                              string key,
                                              Func<TValue> valueFactory)
        {
            return dictionary.GetOrAdd(key, valueFactory.Invoke());
        }

        public static TValue GetOrAdd<TValue>(this IDictionary<string, object> dictionary,
                                              string key,
                                              TValue defaultValue)
        {
            Contract.Assume(dictionary != null, "dictionary is null.");
            Contract.Assume(!String.IsNullOrEmpty(key), "key is null or empty.");
            lock (dictionary)
            {
                if ( !dictionary.ContainsKey(key) )
                {
                    dictionary.Set(key, defaultValue);
                }
                return (TValue) dictionary[key];
            }
        }

        /// <summary>
        /// Adds or replaces the specified key/value pair in the target dictionary.
        /// </summary>
        public static IDictionary<TKey, TValue> Set<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
                                                                  TKey key,
                                                                  TValue value)
        {
            Contract.Assume(dictionary != null, "dictionary is null.");
            dictionary[key] = value;
            return dictionary;
        }
    }
}