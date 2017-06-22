using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl: MonoBehaviour {

	Vector3 pos;
	Transform tr;


	public float speed;
	public float gridSize;
	public float turnAmount;

	public int energyCost = 1;


	bool isRotating;
	public static bool canMove = true;
	public RaycastHit hit;

	KeyCode forward = KeyCode.W;
	KeyCode turnRight = KeyCode.D;
	KeyCode turnLeft = KeyCode.A;
	KeyCode back = KeyCode.S;

	private const float ANGLE_ROTATION = 30;

	enum Orientation{
		NORTH,
		EAST,
		SOUTH,
		WEST
	}

	Orientation myOrientation;


	void Start () {
		myOrientation = Orientation.NORTH;

		tr = transform;
		pos = transform.position;   // For getting the initial position

	}


	void Update () {


		// Assign Controls based on Orientation State
		if (myOrientation == Orientation.NORTH) {
			AssignControls (KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.W);	
		} else if (myOrientation == Orientation.WEST) {
			AssignControls (KeyCode.S, KeyCode.D, KeyCode.W, KeyCode.A);
		} else if (myOrientation == Orientation.SOUTH) {
			AssignControls (KeyCode.D, KeyCode.W, KeyCode.A, KeyCode.S);
		} else {
			AssignControls (KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D);
		}


		if (transform.position == pos) {


			// Check for Colliders Blocking Path
			Vector3 fwd = transform.TransformDirection(Vector3.forward);


			if (Physics.Raycast (transform.position, fwd, out hit, gridSize)) {
				canMove = false;
				//			Debug.Log ("Player blocked by: " + hit.transform.parent.name + "-" + hit.transform.name);
			} else if (isRotating) {
				canMove = false;
			} else {
				if (GameManager.energy - energyCost >= 0) {
					canMove = true;
				} else {
					canMove = false;
				}
			}

//			Debug.DrawRay (transform.position, fwd, Color.white, gridSize);


			// Adjust Player Position


			if (Input.GetKeyDown (turnLeft)) {

				if (!isRotating) {
					StartCoroutine (RotatePlayer (-1));

					if (myOrientation == Orientation.NORTH) {
						myOrientation = Orientation.WEST;	
					} else if (myOrientation == Orientation.WEST) {
						myOrientation = Orientation.SOUTH;	
					} else if (myOrientation == Orientation.SOUTH) {
						myOrientation = Orientation.EAST;	
					} else {
						myOrientation = Orientation.NORTH;
					}

				}
	
			}
				
			if (Input.GetKeyDown (turnRight)) {

				if (!isRotating) {
					StartCoroutine (RotatePlayer (1));

					if (myOrientation == Orientation.NORTH) {
						myOrientation = Orientation.EAST;	
					} else if (myOrientation == Orientation.EAST) {
						myOrientation = Orientation.SOUTH;	
					} else if (myOrientation == Orientation.SOUTH) {
						myOrientation = Orientation.WEST;	
					} else {
						myOrientation = Orientation.NORTH;
					}

				}
			}

			if (Input.GetKeyDown (back)){

				if (!isRotating) {
					//					pos = posTemp; 
					//					GameManager.energy = GameManager.energy - 2;
					StartCoroutine (RotatePlayer (1));
					StartCoroutine (RotatePlayer (1));


					if (myOrientation == Orientation.NORTH) {
						myOrientation = Orientation.SOUTH;	
					} else if (myOrientation == Orientation.EAST) {
						myOrientation = Orientation.WEST;	
					} else if (myOrientation == Orientation.SOUTH) {
						myOrientation = Orientation.NORTH;	
					} else {
						myOrientation = Orientation.EAST;
					}

				} else {

				}
			}


			if (Input.GetKeyDown (forward)) {
				if (!isRotating) {
					if (canMove) {
						pos = pos + (transform.forward * gridSize);
						GameManager.energy = GameManager.energy - energyCost;



					} else {

					}
				}
			}

//				else if (Input.GetKey (turnLeft)) {
//					if (!isRotating && canMove) {
//						pos = pos + ((transform.forward) * gridSize); 
//						GameManager.energy = GameManager.energy - energyCost;
//					}
//				}
//
//				else if (Input.GetKey (turnRight)) {
//					if (!isRotating && canMove) {
//						pos = pos + (transform.forward * gridSize); 
//						GameManager.energy = GameManager.energy - energyCost;
//					}
//				}
//
//				else if (Input.GetKey (back)) {
//					if (!isRotating && canMove) {
//						pos = pos + (transform.forward * gridSize); 
//						GameManager.energy = GameManager.energy - energyCost;
//					}
//				}
				

			MovePlayer ();
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

	void AssignControls(KeyCode left, KeyCode down, KeyCode right, KeyCode up){
		forward = up;
		turnRight = right;
		turnLeft = left;
		back = down;
		
	}

	void KeepMoving(KeyCode key){
		if (Input.GetKey(key)){
			if (canMove && !isRotating){
				pos = pos + (transform.forward * gridSize);
				GameManager.energy = GameManager.energy - energyCost;
			}
		}
	}



}

