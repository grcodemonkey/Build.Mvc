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
using System.Text;
using System.Web.Mvc;
using Build.Mvc.Html;

namespace Build.Mvc.TwitterBootstrap
{
	/// <summary>
	///     A builder for creating TwitterBootstrap button markup.
	/// </summary>
	public class BtnBuilder : FormInputBuilder, IBtnBuilder
	{
		public BtnStyles BtnStyle
		{
			get { return this.Prop<BtnStyles>(MagicStrings.BtnStyle); }
			set { this.Prop(MagicStrings.BtnStyle, value); }
		}

		public string GlyphLeft
		{
			get { return this.Prop<string>(MagicStrings.GlyphLeft); }
			set { this.Prop(MagicStrings.GlyphLeft, value); }
		}

		public string GlyphRight
		{
			get { return this.Prop<string>(MagicStrings.GlyphRight); }
			set { this.Prop(MagicStrings.GlyphRight, value); }
		}

		public bool DropDownToggle
		{
			get { return this.Prop<bool>(MagicStrings.DropDownToggle); }
			set { this.Prop(MagicStrings.DropDownToggle, value); }
		}

		public static string ButtonTextSpace = " ";

		public override string ToHtmlString()
		{
			BtnStyles style = BtnStyle;

			this.Aria("disabled", "false");

			this.AddClass("btn");
			this.AddClassWhen(style.HasFlag(BtnStyles.Default), "btn-default");
			this.AddClassWhen(style.HasFlag(BtnStyles.Large), "btn-large");
			this.AddClassWhen(style.HasFlag(BtnStyles.Small), "btn-small");
			this.AddClassWhen(style.HasFlag(BtnStyles.Mini), "btn-mini");
			this.AddClassWhen(style.HasFlag(BtnStyles.Primary), "btn-primary");
			this.AddClassWhen(style.HasFlag(BtnStyles.Success), "btn-success");
			this.AddClassWhen(style.HasFlag(BtnStyles.Info), "btn-info");
#pragma warning disable 612,618
			this.AddClassWhen(style.HasFlag(BtnStyles.Inverse), "btn-inverse");
#pragma warning restore 612,618
			this.AddClassWhen(style.HasFlag(BtnStyles.Danger), "btn-danger");
			this.AddClassWhen(style.HasFlag(BtnStyles.Warning), "btn-warning");
			this.AddClassWhen(style.HasFlag(BtnStyles.Link), "btn-link");
			this.AddClassWhen(style.HasFlag(BtnStyles.Block), "btn-block");
			this.AddClassWhen(style.HasFlag(BtnStyles.Active), "active");

			this.BuildWhen(style.HasFlag(BtnStyles.Disabled),
						   x =>
						   {
							   x.Attr("disabled", "disabled");
							   x.AddClass("disabled");
							   x.Aria("disabled", "true");
						   });

			this.DefaultAttr("aria-role", "button");
			this.DefaultProp("tagName", "button");

			var tagName = this.Prop<string>("tagName");

			if ( tagName.Equals("a", StringComparison.CurrentCultureIgnoreCase) )
			{
				this.DefaultAttr("href", "#");
			}
			else
			{
				this.DefaultAttr("type", "button");
			}

			if ( DropDownToggle )
			{
				this.AddClass("dropdown-toggle");
				this.DefaultAttr("data-toggle", "dropdown");
			}

			var tagBuilder = new TagBuilder(tagName)
				{
					InnerHtml = BuildInnerHtml()
				};

			tagBuilder.MergeAttributes(HtmlAttributes, true);

			return tagBuilder.ToString(TagRenderMode.Normal);
		}

		private string BuildInnerHtml()
		{
			var sb = new StringBuilder();

			string glyphLeft = GlyphLeft, glyphRight = GlyphRight, buttonText = Convert.ToString(this.Val());

			bool hasButtonText = !string.IsNullOrEmpty(buttonText);

			if ( !string.IsNullOrEmpty(glyphLeft) )
			{
				sb.AppendFormat(MagicStrings.IconTemplate, glyphLeft);
				AppendSpacer(hasButtonText, sb);
			}

			if ( hasButtonText )
			{
				sb.Append(buttonText);
			}

			if ( DropDownToggle )
			{
				AppendSpacer(hasButtonText, sb);
				sb.Append("<span class=\"caret\"></span>");
			}

			if ( !string.IsNullOrEmpty(glyphRight) )
			{
				AppendSpacer(hasButtonText, sb);
				sb.AppendFormat(MagicStrings.IconTemplate, glyphRight);
			}

			return sb.ToString();
		}

		private static void AppendSpacer(bool hasButtonText, StringBuilder sb)
		{
			if ( hasButtonText )
			{
				sb.Append(ButtonTextSpace);
			}
		}
	}
}