using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// A <c>ValueList</c> which can hold a list of DataStrings which can be used in place of regular Strings.
	/// </summary>
	[CreateAssetMenu (menuName = "Runtime Objects/Value/List/Strings")]
    public class StringList : ValueList<DataString>
    {
		/// <summary>
		/// Append objects to the end of this list.
		/// </summary>
		/// <param name="items">A collection of objects to be appended to this list.</param>
		public virtual void AddRange (IEnumerable<string> items)
		{
			foreach (string item in items)
			{
				this.items.Add (item);
			}
		}

		/// <summary>
		/// Shorthand for calling <c>Clear ()</c> and then <c>AddRange (items)</c>.
		/// </summary>
		/// <param name="items">A collection of objects to be appended to this list.</param>
		public virtual void Initialise (IEnumerable<string> items)
		{
			Clear ();
			AddRange (items);
		}

		/// <summary>
		/// Converts the internal list of <c>DataString</c>s into a new list of regular stirngs.
		/// </summary>
		/// <returns>A list of strings with the same values.</returns>
		public new virtual List<string> ToList ()
		{
			List<string> strings = new List<string> (Count);

			for (int i = 0; i < Count; i++)
			{
				strings.Add (items[i]);
			}

			return strings;
		}

		/// <summary>
		/// Converts the internal list of <c>DataString</c>s into a new array of regular stirngs.
		/// </summary>
		/// <returns>An array of strings with the same values.</returns>
		public new virtual string[] ToArray ()
		{
			string[] strings = new string[Count];

			for (int i = 0; i < strings.Length; i++)
			{
				strings[i] = items[i];
			}

			return strings;
		}
	}
}