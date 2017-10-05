using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiptoBihav : MonoBehaviour {
	public HunterQuest q;
	// Use this for initialization
	void Start () {
		q = GameObject.Find ("Hunter").GetComponent<HunterQuest> ();
	}


	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Arrow") 
		{
			q.riptos--;
			Destroy (gameObject, 2);
		}

	}

	// Update is called once per frame
	void Update () {
		
	}
}
