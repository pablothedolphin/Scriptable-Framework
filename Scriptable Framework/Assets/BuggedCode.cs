using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ScriptableFramework;

public class BuggedCode : MonoBehaviour
{
	public SceneAsset scene1;
	public SceneAsset scene2;

	// Start is called before the first frame update
	void Start()
    {

	}

	// Update is called once per frame
	void Update ()
	{

	}

	public void ErrorMethod ()
	{
		//string thing = null;

		//thing.Split ('.');
	}
}
