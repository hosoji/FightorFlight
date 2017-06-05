using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl: MonoBehaviour {

	Vector3 pos, posTemp;
	public float speed;
	public float gridSize;
	public float turnAmount;


	bool isRotating;
	public static bool canMove = true;


	public KeyCode forward;
	public KeyCode turnRight;
	public KeyCode turnLeft;
	public KeyCode back;

	private const float ANGLE_ROTATION = 30;



	// Use this for initialization
	void Start () {
		pos = transform.position;   // For getting the initial position


	}

	// Update is called once per frame
	void Update () {

		Vector3 fwd = transform.TransformDirection(Vector3.forward);

		RaycastHit hit;

		if (Physics.Raycast (transform.position, fwd, out hit, gridSize + 1)) {
			canMove = false;
			//			Debug.Log ("Player movement is blocked in this direction by " + hit.transform.name);
		} else if (isRotating) {
			canMove = false;
		} else {
			canMove = true;
		}

		MovePlayer ();

		if (transform.position == pos) {


			if (Input.GetKeyDown (turnLeft)) {

				if (!isRotating) {
					StartCoroutine (RotatePlayer (-1));

				}

			}


			if (Input.GetKeyDown (turnRight)) {

				if (!isRotating) {
					StartCoroutine (RotatePlayer (1));

				}
			}

			if (Input.GetKeyDown (back)){
				if (canMove) {
					//					pos = posTemp; 
					//					GameManager.energy = GameManager.energy - 2;
					StartCoroutine (RotatePlayer (1));
					StartCoroutine (RotatePlayer (1));
				} else {

				}
			}

			if (GameManager.energy > 0) {

				if (Input.GetKey (forward)) {
					if (!isRotating) {
						if (canMove) {
							posTemp = pos;
							pos = pos + (transform.forward * gridSize); 
							GameManager.energy--;

						} else {

						}
					}
				}

				if (Input.GetKey (turnLeft)) {
					if (!isRotating && canMove) {
						pos = pos + ((transform.forward) * gridSize); 
						GameManager.energy--;
					}
				}

				if (Input.GetKey (turnRight)) {
					if (!isRotating && canMove) {
						pos = pos + (transform.forward * gridSize); 
						GameManager.energy--;
					}
				}
			}

		}

	}

	IEnumerator RotatePlayer(int mod){


		int i = 0;
		while (i < ANGLE_ROTATION) {
			isRotating = true;
			transform.RotateAround (transform.position, Vector3.up, turnAmount * mod); 
			i++;
			yield return 0;
			isRotating = false;
		}

	}

	public void MovePlayer(){
		transform.position = Vector3.MoveTowards (transform.position, pos, Time.deltaTime * speed);

	}


}

