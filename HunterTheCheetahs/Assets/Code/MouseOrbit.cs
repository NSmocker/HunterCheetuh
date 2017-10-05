using UnityEngine;
using System.Collections;

public class MouseOrbit : MonoBehaviour
{
	public Transform Target;
	public float Distance = 5.0f;
    public float PermamentDistance;
	public float xSpeed = 250.0f;
	public float ySpeed = 120.0f;
	public float yMinLimit = -20.0f;
	public float yMaxLimit = 80.0f;
	public GameObject VisualBody;

	private float x;
	private float y;

	void Start()
	{
		Vector3 angles = transform.eulerAngles;
		x = angles.x;
		y = angles.y;
        PermamentDistance = Distance;
    }

	void FixedUpdate()
	{

	}
	void LateUpdate()
	{
		if(Input.GetKey(KeyCode.LeftAlt))
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;	

		}
		else 
			{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			}


        if (Distance < 2.9f)
        {
         var components =   VisualBody.GetComponentsInChildren<Renderer>();
            foreach (var component in components)
            {
                component.enabled = false;
            }
        }
        else
        {
            var components = VisualBody.GetComponentsInChildren<Renderer>();
            foreach (var component in components)
            {
                component.enabled = true;
            }
        }


		if(Cursor.visible ==false)
		{
			x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
			y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;



			//x += Input.GetAxis("JoyRightStick_X") * xSpeed * 0.02f;
			//y += Input.GetAxis("JoyRightStick_Y") * ySpeed * 0.02f;
            


			y = ClampAngle(y, yMinLimit, yMaxLimit);

			Quaternion q_rotation = Quaternion.Euler(y, x, 0);
			Vector3 rotation = new Vector3(y, x, 0);
			Vector3 position;
			RaycastHit info;
			Target.transform.LookAt (transform.position);
			transform.LookAt (Target.transform.position);
			if (Physics.Raycast (Target.transform.position, Target.transform.forward, out info, PermamentDistance))
			{if (info.collider.tag !="Player")Distance = info.distance;}else{Distance = PermamentDistance;}
			position = q_rotation * new Vector3 (0.0f, 0.0f, -Distance) + Target.position;
			transform.localEulerAngles = rotation;
			transform.position = position;
		}
	}

	private float ClampAngle(float angle, float min, float max)
	{
		if(angle < -360)
		{
			angle += 360;
		}
		if(angle > 360)
		{
			angle -= 360;
		}
		return Mathf.Clamp (angle, min, max);
	}
}
