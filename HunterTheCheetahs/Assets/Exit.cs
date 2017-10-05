using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter(Collision col)
		{
		Application.Quit ();
		
	}
	// Update is called once per frame
	void Update () {

	}
}
