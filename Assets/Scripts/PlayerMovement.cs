using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public int PlayerNumber = 1;

	public GameObject MyThrowobject;
	public Transform ThrowOffset;
	public float ThrowPower = 5;

	public float MoveForce = 50;
	public float JumpForce = 12;

	private string L_X_AXIS;
	private string L_Y_AXIS;

	private string R_X_AXIS;
	private string R_Y_AXIS;
	
	private string A_BUTTON;
	private string TRIGGERS;

	private Vector3 facingDir;

	private float CamRotation;

	bool pressed = false;

	// Use this for initialization
	void Start () {	
		L_X_AXIS = "L_XAxis_" + PlayerNumber.ToString();
		L_Y_AXIS = "L_YAxis_" + PlayerNumber.ToString();

		R_X_AXIS = "R_XAxis_" + PlayerNumber.ToString();
		R_Y_AXIS = "R_YAxis_" + PlayerNumber.ToString();
		
		A_BUTTON = "A_" + PlayerNumber.ToString();
		TRIGGERS = "Triggers_" + PlayerNumber.ToString();
	}

	void Update() {

	}

	// Update is called once per frame
	void FixedUpdate () {

		//	Check if the player is grounded
		bool grounded = GetComponentInChildren<Grounded> ().ground;
		if (grounded == true) {			
			rigidbody.drag = 2;
		}

		//	Rotate the player based on the Right Stick
		if (Input.GetAxis (R_X_AXIS) != 0 || Input.GetAxis (R_Y_AXIS) != 0) {
			facingDir = new Vector3 (Input.GetAxis (R_X_AXIS), 0, -Input.GetAxis (R_Y_AXIS));
			facingDir = Quaternion.AngleAxis(CamRotation, Vector3.up) * facingDir;
		}
		//	Set the players facing direction
		if (facingDir != Vector3.zero)
			transform.forward = facingDir;


		//	Move the player
		float force = (grounded) ? MoveForce : MoveForce * 0.25f;
		Vector3 moveDir = new Vector3 (Input.GetAxis (L_X_AXIS), 0, -Input.GetAxis (L_Y_AXIS));
		moveDir = Quaternion.AngleAxis (CamRotation, Vector3.up) * moveDir;
		rigidbody.AddForce (moveDir * force * Time.fixedDeltaTime, ForceMode.VelocityChange);


		//	Jump
		if (Input.GetButtonDown(A_BUTTON) && grounded) {
			rigidbody.AddForce(new Vector3(0,1,0) * JumpForce, ForceMode.Impulse);
		}

		//	Spawn box
		if (Input.GetAxis (TRIGGERS) != 0) 
		{
			if (MyThrowobject != null && pressed == false) 
			{
				(Instantiate (MyThrowobject, ThrowOffset.position, ThrowOffset.rotation) as GameObject).rigidbody.AddForce (ThrowOffset.forward * ThrowPower, ForceMode.Impulse);
				pressed = true;
			}
		} 
		else 
		{
			pressed = false;
		}

		//	Adjust for camera rotation
		CamRotation = Camera.main.transform.localRotation.eulerAngles.y;
		int y = (int)transform.localRotation.eulerAngles.y / 45;
		transform.localEulerAngles = new Vector3(0, y * 45.0f, 0);
	}
}



















