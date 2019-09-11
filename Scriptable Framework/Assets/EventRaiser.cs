using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableFramework;

public class EventRaiser : MonoBehaviour
{
	public AppEvent thing;

    // Start is called before the first frame update
    void Start()
    {
		thing.RaiseEvent ();
    }
}
