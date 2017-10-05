using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HunterQuest : MonoBehaviour {

	public Text _left;
	public int riptos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (riptos > 0) {
			_left.text = "Осталось: " + riptos.ToString ();
		} else {
			_left.text = "Победа!";
		}
		
	}
}
