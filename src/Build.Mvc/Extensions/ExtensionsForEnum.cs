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

using Build.Mvc.Html;

namespace Build.Mvc
{
	/// <summary>
	/// </summary>
	public static class ExtensionsForEnum
	{
		/// <summary>
		///     Gets the string value for the specified
		/// </summary>
		/// <param name="value">The value.</param>
		public static string ConvertToString(this AutocompleteMode value)
		{
			switch (value)
			{
				case AutocompleteMode.Off:
					return "off";
				case AutocompleteMode.On:
					return "on";
				default:
					return "";
			}
		}

		/// <summary>
		///     Gets the string value for the specified
		/// </summary>
		/// <param name="value">The value.</param>
		public static string ConvertToString(this DraggableMode value)
		{
			switch (value)
			{
				case DraggableMode.On:
					return "true";
				case DraggableMode.Off:
					return "false";
				default:
					return "auto";
			}
		}

		/// <summary>
		///     Gets the string value for the specified
		/// </summary>
		/// <param name="value">The value.</param>
		public static string ConvertToString(this FormEncType value)
		{
			switch (value)
			{
				case FormEncType.FormUrlEncoded:
					return "application/x-www-form-urlencoded";
				case FormEncType.MultipartData:
					return "multipart/form-data";
				case FormEncType.TextPlain:
					return "text/plain";
				default:
					return "";
			}
		}

		/// <summary>
		///     Gets the string value for the specified
		/// </summary>
		/// <param name="value">The value.</param>
		public static string ConvertToString(this SpellcheckMode value)
		{
			switch (value)
			{
				case SpellcheckMode.On:
					return "true";
				case SpellcheckMode.Off:
					return "false";
				default:
					return "";
			}
		}

		/// <summary>
		///     Gets the string value for the specified
		/// </summary>
		/// <param name="value">The value.</param>
		public static string ConvertToString(UrlTarget value)
		{
			switch (value)
			{
				case UrlTarget.Blank:
					return "_blank";
				case UrlTarget.Parent:
					return "_parent";
				case UrlTarget.Self:
					return "_self";
				case UrlTarget.Top:
					return "_top";
				default:
					return null;
			}
		}

		/// <summary>
		///     Gets the string value for the specified
		/// </summary>
		/// <param name="value">The value.</param>
		public static string ConvertToString(this ContentEditableOption value)
		{
			switch (value)
			{
				case ContentEditableOption.Inherit:
					return "inherit";
				case ContentEditableOption.On:
					return "true";
				case ContentEditableOption.Off:
					return "false";
				default:
					return null;
			}
		}
	}
}