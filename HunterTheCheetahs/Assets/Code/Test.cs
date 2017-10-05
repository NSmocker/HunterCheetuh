using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey (KeyCode.Space)) 
		{
			Debug.Log ("Global pos:" + gameObject.transform.position);
			Debug.Log ("Global Rotation:" + gameObject.transform.eulerAngles.y.ToString());
			Debug.Log ("Global Scale:" + gameObject.transform.lossyScale);
			Debug.Log ("/////////////////////////////////////////////");
			Debug.Log ("Local pos:" + gameObject.transform.localPosition);
			Debug.Log ("Local Rotation:" + gameObject.transform.localEulerAngles.y.ToString());
			Debug.Log ("Local Scale:" + gameObject.transform.localScale);


		}

		if (Input.GetKey (KeyCode.G)) 
		{

			var angle = transform.eulerAngles;
	//		angle += new Vector3 (0, 50, 0);
			transform.eulerAngles = angle;

		}

	}
}
