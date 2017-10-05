using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inp : MonoBehaviour 
{

	public  float va ;
	public float  ha ;
 
	void 	FixedUpdate()
	{
		va = Input.GetAxis ("Vertical");
		ha = Input.GetAxis ("Horizontal");
	}


}
