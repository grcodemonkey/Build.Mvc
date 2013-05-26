using System;

namespace Build.Mvc.Html
{
	/// <summary>
	/// 
	/// </summary>
	public static class BuilderExtensions
	{
		/// <summary>
		/// Applies the specified <paramref name="withAction"/> and returns the resulting builder.
		/// </summary>
		public static T BuildWith<T>(this T builder, Action<T> withAction) where T : class
		{
			if ( withAction != null )
			{
				withAction(builder);
			}
			return builder;
		}

		/// <summary>
		/// Conditionally applies the specified <paramref name="whenAction"/> and returns the resulting builder.
		/// </summary>
		public static T BuildWhen<T>(this T builder, bool whenCondition, Action<T> whenAction) where T : class
		{
			if ( whenCondition && whenAction != null )
			{
				whenAction(builder);
			}
			return builder;
		}
	}
}
