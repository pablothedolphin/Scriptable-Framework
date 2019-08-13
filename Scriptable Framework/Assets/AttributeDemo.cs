using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableFramework;

public class AttributeDemo : MonoBehaviour
{
	public KeyCode keyInput;

	[SearchableEnum]
	public KeyCode searchableKeyInput;

	[Foldout ("String variables", true)]
	public string text1;
	public string text2;

	[Foldout ("Foldout for one")]
	public string text3;
}