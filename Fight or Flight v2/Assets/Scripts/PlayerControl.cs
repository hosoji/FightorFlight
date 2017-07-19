using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Alternative Physics Based Movement Script start - NOT THE ACTUAL PLAYER CONTROLLER USED
//FIRST PERSON MOVEMENT

public class PlayerControl : MonoBehaviour {

	public float moveSpeed = 10f; 
	public float mouseSensitivity = 180f;

	float mouseY;

	Vector3 inputVector;
	Rigidbody rb;

	void Start () {
		rb.GetComponent<Rigidbody> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		inputVector.x = Input.GetAxis ("Horizontal");
		inputVector.z = Input.GetAxis ("Vertical");
		inputVector.y = -0.5f;


		//Mouse look 
		transform.Rotate (0f, Input.GetAxis ("Mouse X") * Time.deltaTime * mouseSensitivity, 0f);
		mouseY -= Input.GetAxis ("Mouse Y") * Time.deltaTime * mouseSensitivity;
		mouseY = Mathf.Clamp (mouseY, -50f, -50f);
		Camera.main.transform.localEulerAngles = new Vector3 (mouseY, 0f, 0f);


		//Hiding mouse cursor

		if (Input.GetMouseButtonDown (0)) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		
	}

	void FixedUpdate(){
		Vector3 worldVector = transform.right * inputVector.x + transform.forward * inputVector.x + transform.up * inputVector.y;

		// rb.AddForce (worldVector * moveSpeed);

		//set velocity directly = good for walking in games

		rb.velocity = worldVector * moveSpeed;
	}
}
