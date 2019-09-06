using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// 
	/// </summary>
	public static class Extensions
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="parent"></param>
		public static void DestroyChildren (this Transform parent)
		{
			for (int i = parent.childCount - 1; i >= 0; i--)
			{
				GameObject.DestroyImmediate (parent.GetChild (i).gameObject);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetName<T> (this T value) where T : struct, IConvertible => Enum.GetName (typeof (T), value);
	}
}