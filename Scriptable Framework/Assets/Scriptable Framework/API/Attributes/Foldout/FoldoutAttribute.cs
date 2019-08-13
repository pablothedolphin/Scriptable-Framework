/*===============================================================
Product:    ActorBasedBehaviors
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       5/17/2018 6:31 AM
================================================================*/


using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// Use this to organise your public properties in the inspector into collapsable groups.
	/// </summary>
    public class FoldoutAttribute : PropertyAttribute
    {
		/// <summary>
		/// The name of the group.
		/// </summary>
	    public string name;

		/// <summary>
		/// Whether to encapsulate the property this attribute is on or cascade down on all other properties.
		/// </summary>
	    public bool foldEverything;
 
	    /// <summary>Adds the property to the specified foldout group.</summary>
	    /// <param name="name">Name of the foldout group.</param>
	    /// <param name="foldEverything">Toggle to put all properties to the specified group</param>
	    public FoldoutAttribute(string name, bool foldEverything = false)
	    {
		    this.foldEverything = foldEverything;
		    this.name = name;
	    }
    }
}
