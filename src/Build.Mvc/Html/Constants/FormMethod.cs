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
    /// Defines the HTTP method for sending data to the action URL.
    /// </summary>
    public enum FormMethod
    {
        /// <summary>
        /// Sends the form-data as an HTTP post transaction
        /// </summary>
        Post = 0,

        /// <summary>
        /// Appends the form-data to the URL: URL?name=value&amp;name=value
        /// </summary>
        Get = 1,

        /// <summary>
        /// Sends the form-data as an HTTP put transaction
        /// </summary>
        Put = 2,

        /// <summary>
        /// Sends the form-data as an HTTP delete transaction
        /// </summary>
        Delete = 3
    }
}