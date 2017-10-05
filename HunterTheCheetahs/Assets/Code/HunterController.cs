using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterController : MonoBehaviour {


	public Animator anim,bow_anim;
	public GameObject cam;
	public GameObject isGroundedCheker;
	public Rigidbody rb;
	public float JumpForce,moveSpeed;
	public bool collided,aiming,grounded;
	public GameObject Arrow,hand,temp_arrow;
	private float GroundDist;

	public Vector3 hit_position;



	public float Rotation_Speed;
	public float Rotation_Friction; //The smaller the value, the more Friction there is. [Keep this at 1 unless you know what you are doing].
	public float Rotation_Smoothness; //Believe it or not, adjusting this before anything else is the best way to go.
	private float Resulting_Value_from_Input;
	private Quaternion Quaternion_Rotate_From;
	private Quaternion Quaternion_Rotate_To;






	public void GenerateArrow()
	{		transform.eulerAngles = GetRotationFromCamera();
		Quaternion arrow_rot = Arrow.transform.localRotation;
		arrow_rot.eulerAngles = new Vector3 (0, 0, 0);
			

		temp_arrow = Instantiate (Arrow, hand.transform.position,Quaternion.identity,hand.transform);
	}
	public void Shoot()
	{
	//	sdfgsdgsdftemp_arrow = Instantiate (Arrow, hand.transform.position, Quaternion.identity, hand.transform);
	//	Destroy(temp_arrow);
		temp_arrow.transform.parent = null;
		temp_arrow.GetComponent<Rigidbody> ().isKinematic = false;

	}



	// Use this for initialization
	void Start () {
		GroundDist = GetComponent<Collider> ().bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update () {
	
	

		if (!aiming) {
			Vector3 NextDir = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
			if (NextDir != Vector3.zero) {
				Quaternion_Rotate_From = transform.rotation;
				var lol = Quaternion.LookRotation (cam.transform.TransformDirection (NextDir));
				var eLol = lol.eulerAngles;
				eLol.x = 0;
				eLol.z = 0;

				Quaternion_Rotate_To = Quaternion.Euler (eLol);
				transform.rotation = Quaternion.Lerp (Quaternion_Rotate_From, Quaternion_Rotate_To, Time.deltaTime * Rotation_Smoothness);
			}
		}



	}


	Vector3 GetRotationFromCamera()
	{

		var thisRotation = transform.localEulerAngles;
		thisRotation.y = cam.transform.localEulerAngles.y;
		return thisRotation;
	}

	bool GroundCheck()
	{
		RaycastHit hit;
		var temp =	Physics.SphereCast (isGroundedCheker.transform.position,2.5f, -transform.up, out hit,3);
		try{Debug.Log (hit.collider.name);}
		catch{}
		return temp;
	}


	public void OnCollisionEnter(){
		collided =true;
	}

	public void OnCollisionExit(){
		collided =false;
	}


	void FixedUpdate()
	  {

		grounded = GroundCheck ();
		if (grounded)aiming = Input.GetButton ("Fire2");
		anim.SetBool("isGrounded",grounded);

	
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
	



		RaycastHit aim_hit;
		Physics.Raycast (ray, out aim_hit);
		Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.green);
		hit_position = aim_hit.point;




		if (aiming) {
			cam.GetComponent<MouseOrbit> ().xSpeed = 50f;
			cam.GetComponent<MouseOrbit> ().ySpeed = 50f;

			anim.SetFloat ("Run", 0);
			Camera.main.fieldOfView = 15f;
			anim.SetBool ("DrowedArrow", Input.GetButton ("Fire1"));
			bow_anim.SetBool ("DrowedArrow", Input.GetButton ("Fire1"));
			transform.eulerAngles = GetRotationFromCamera();


		} 
		else 
		{
			Camera.main.fieldOfView = 60f;
			cam.GetComponent<MouseOrbit> ().xSpeed = 250f;
			cam.GetComponent<MouseOrbit> ().ySpeed = 120f;
		}

		var h = Input.GetAxis ("Horizontal") * moveSpeed;
		var v = Input.GetAxis ("Vertical") * moveSpeed;


		if (grounded && !aiming)
		{
			anim.SetBool ("DrowedArrow", Input.GetButton ("Fire1"));
			bow_anim.SetBool ("DrowedArrow", Input.GetButton ("Fire1"));
				if (Input.GetButton ("Jump")) {
					rb.AddRelativeForce ((Vector3.up * JumpForce));
		}}
	


		else 
		{if (collided) { rb.velocity = new Vector3 (0,rb.velocity.y,0); } else {	rb.velocity = transform.TransformDirection (new Vector3 (rb.velocity.x, rb.velocity.y, 25));}}
		anim.SetBool("Jump",Input.GetButton("Jump"));

		var temp = 0.0f;
		if (Mathf.Abs(Input.GetAxis ("Horizontal")) >= Mathf.Abs(Input.GetAxis ("Vertical"))) {temp = Mathf.Abs(Input.GetAxis ("Horizontal"));}
		else{temp =Mathf.Abs(Input.GetAxis ("Vertical")) ;}

		if(!aiming)anim.SetFloat ("Run", temp);


	}

}
