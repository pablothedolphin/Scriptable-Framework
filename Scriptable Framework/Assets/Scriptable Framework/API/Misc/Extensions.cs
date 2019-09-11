using System;
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
	}
}