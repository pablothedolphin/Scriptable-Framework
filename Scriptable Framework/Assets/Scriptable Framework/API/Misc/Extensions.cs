using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// A collection of useful extension methods that probably should've already existed in 
	/// the base .NET/Unity APIs.
	/// </summary>
	public static class Extensions
	{
		/// <summary>
		/// Call <c>DestroyImmediate ()</c> on each direct child of this Transform.
		/// </summary>
		/// <param name="parent">The parent of the objects to destroy.</param>
		public static void DestroyChildren (this Transform parent)
		{
			for (int i = parent.childCount - 1; i >= 0; i--)
			{
				GameObject.DestroyImmediate (parent.GetChild (i).gameObject);
			}
		}

		/// <summary>
		/// Converts the current enum value into a string.
		/// </summary>
		/// <typeparam name="T">The enum type.</typeparam>
		/// <param name="value">The current instance of the enum value.</param>
		/// <returns>The enum value converted into a string.</returns>
		public static string GetName<T> (this T value) where T : struct, IConvertible => Enum.GetName (typeof (T), value);

		/// <summary>
		/// Allows direct conversion of a <c>DateTime</c> value to a string that goes from years to seconds in decending order.
		/// </summary>
		/// <param name="dateTime">The value to convert.</param>
		/// <returns>A new standard format string of the value.</returns>
		public static string ToStandardFormat (this DateTime dateTime) => dateTime.ToString ("yyyy-MM-dd HH:mm:ss");

		/// <summary>
		/// Allows direct conversion of a <c>string</c> which happens to represent a time or date into a <c>DateTime</c> value.
		/// </summary>
		/// <param name="dateTimeString">The string to convert</param>
		/// <returns>A new <c>DateTime</c> value derived from the string.</returns>
		public static DateTime ToDateTime (this string dateTimeString)
		{
			if (DateTime.TryParseExact (dateTimeString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime timeStampResult))
			{
				return timeStampResult;
			}
			else
			{
				DateTime tempDate = DateTime.Parse (dateTimeString);
				string sYear = tempDate.ToString ("yyyy");
				string sMonth = tempDate.Month.ToString ().PadLeft (2, '0');
				string sDay = tempDate.Day.ToString ().PadLeft (2, '0');
				string sTime = tempDate.TimeOfDay.ToString ();
				string date = string.Format ("{0}-{1}-{2} {3}", sYear, sMonth, sDay, sTime);
				return DateTime.ParseExact (date, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
			}
		}
	}
}