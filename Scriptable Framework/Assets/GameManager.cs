using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Start()
    {
		DontDestroyOnLoad (gameObject);
    }

	private void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) SceneManager.LoadScene (1);
	}

	public void Response ()
	{
		GetComponent<MeshRenderer> ().material.color = Color.red;
	}
}
