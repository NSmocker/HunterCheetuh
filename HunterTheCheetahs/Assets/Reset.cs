using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Reset : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	void OnCollisionEnter(Collision col)
	{
		SceneManager.LoadScene (0);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
