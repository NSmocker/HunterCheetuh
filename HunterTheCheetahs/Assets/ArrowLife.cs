using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLife : MonoBehaviour {
	public HunterController controller;
	public bool _fixed;
	// Use this for initialization
	void Start () {
		controller = GameObject.Find ("Hunter").GetComponent<HunterController> ();
	}

	public void OnCollisionEnter(Collision col){
		Destroy (gameObject);
	}
	// Update is called once per frame
	void Update () {
		Debug.Log (transform.localEulerAngles);
		if(transform.parent!=null)transform.localEulerAngles = new Vector3 (-10, -90, 0);
		if (transform.parent == null) {
			if (!_fixed) {_fixed = true;
				transform.LookAt (controller.hit_position);
				GetComponent<Rigidbody> ().AddRelativeForce (new Vector3 (0, 0, 250), ForceMode.Impulse);
			}
		}
	}
}
