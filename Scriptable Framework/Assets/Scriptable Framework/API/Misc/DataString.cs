using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ScriptableFramework
{
	/// <summary>
	/// A value type that encapsulates a regular string object. Can implicitly cast to and from a regular
	/// string and is compatible with the <c>ValueItem</c> and <c>ValueList</c> API.
	/// </summary>
	[System.Serializable]
	public struct DataString
	{
		/// <summary>
		/// The internal string that actually gets written to and read from.
		/// </summary>
		[SerializeField] private string text;

		/// <summary>
		/// Initialise this instance with a string.
		/// </summary>
		/// <param name="text">The string to store.</param>
		public DataString (string text)
		{
			this.text = text;
		}

		/// <summary>
		/// An implicit operator that allows this value to be read from as if it were a string.
		/// </summary>
		/// <param name="text">The value being read from.</param>
		public static implicit operator string (DataString text)
		{
			return text.text;
		}

		/// <summary>
		/// An implicit operator that allows this value to be written to as if it were a string.
		/// </summary>
		/// <param name="text">The string being written into this value.</param>
		public static implicit operator DataString (string text)
		{
			return new DataString (text);
		}

		/// <summary>
		/// An override to allow printing this value to simulate the effect of returning the internal string instead.
		/// </summary>
		/// <returns>The internal string.</returns>
		public override string ToString ()
		{
			return text;
		}
	}
}