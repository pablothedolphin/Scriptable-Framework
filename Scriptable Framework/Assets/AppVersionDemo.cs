using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ScriptableFramework;

public class AppVersionDemo : MonoBehaviour
{
	public Text versionLabel;
	public AppVersion versionNumber;

    void Start()
    {
		versionLabel.text = versionNumber;
    }
}
