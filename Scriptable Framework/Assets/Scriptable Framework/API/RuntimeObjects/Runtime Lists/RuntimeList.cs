using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
    /// <summary>
    /// An abstract generic RuntimeObject which encapsulates the List class.
    /// Inherit from this class to create your own RuntimeList sub class.
    /// Give your class the CreateAssetMenu attribute to serialize an instance of it.
    /// </summary>
    /// <typeparam name="T">The type that will be stored in this object's internal
    /// generic <c>List</c></typeparam>
    public abstract class RuntimeList<T> : RuntimeObject, IList<T>
    {
		/// <summary>
		/// A list of the elements in this object to be accessed externally via square bracket operator.
		/// </summary>
		[Space]
        [SerializeField]
        protected List<T> items = new List<T> ();

		/// <summary>
		/// A square bracket operator for all RuntimeLists to easily access an element at a given
		/// index. Behaves just like any other list or array type.
		/// </summary>
		/// <param name="index">The index of the element to be accessed where
		/// <c>index >= 0 && index < this.Count</c></param>
		/// <returns>The element found at the given index.</returns>
		/// <value>The element found at the given index.</value>
		public T this[int index]
        {
            get => GetItem (index);
            set => SetItem (index, value);
        }

        /// <summary>
        /// Returns the number of elements currently in the list.
        /// </summary>
        public int Count => items.Count;

        /// <summary>
        /// Will always return false.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Append an object to the end of this list.
        /// </summary>
        /// <param name="item">The object to be added as an element.</param>
        public virtual void Add (T item) => items.Add (item);

		/// <summary>
		/// Append objects to the end of this list.
		/// </summary>
		/// <param name="items">A collection of objects to be appended to this list.</param>
		public virtual void AddRange (IEnumerable<T> items) => this.items.AddRange (items);

		/// <summary>
		/// Shorthand for calling <c>Clear ()</c> and then <c>AddRange (items)</c>.
		/// </summary>
		/// <param name="items">A collection of objects to be appended to this list.</param>
		public virtual void Initialise (IEnumerable<T> items)
		{
			Clear ();
			AddRange (items);
		}

		/// <summary>
		/// If the item exists as an element in this list, remove it and shift the index of the
		/// elements after it down by one.
		/// </summary>
		/// <param name="item">The element to remove.</param>
		public virtual void Remove (T item)
        {
            if (items.Contains (item)) items.Remove (item);
        }

        /// <summary>
        /// Read an element at a given index from this list. Called when the list is read from via square brackets.
        /// </summary>
        /// <param name="index">The index of the element to be returned.</param>
        /// <returns>The element object at the given index.</returns>
        protected virtual T GetItem (int index) => items[index];

        /// <summary>
        /// Pass an object back into the list and raise an event if an event was set 
        /// in the inspector. Called when the list is written to via square brackets.
        /// </summary>
        /// <param name="index">The index of the element being written to.</param>
        /// <param name="newItem">The new value to set in place of the previous value in the given index.</param>
        protected virtual void SetItem (int index, T newItem) => items[index] = newItem;

        /// <summary>
        /// Empty this list of all elements.
        /// </summary>
        public override void Clear () => items.Clear ();

        /// <summary>
        /// Calls <c>Clear ()</c>.
        /// </summary>
        public override void Reset () => Clear ();

        /// <summary>
        /// Get the index of a given item if it exists as an element in this list.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual int IndexOf (T item) => items.IndexOf (item);

        public virtual void Insert (int index, T item) => items.Insert (index, item);

        public virtual void RemoveAt (int index) => items.RemoveAt (index);

        public virtual bool Contains (T item) => items.Contains (item);

        public virtual void CopyTo (T[] array, int arrayIndex) => items.CopyTo (array, arrayIndex);

        bool ICollection<T>.Remove (T item) => items.Remove (item);

        public IEnumerator<T> GetEnumerator () => items.GetEnumerator ();

        IEnumerator IEnumerable.GetEnumerator () => items.GetEnumerator ();

		public virtual T[] ToArray () => items.ToArray ();

		public virtual List<T> ToList () => items;
	}
}
