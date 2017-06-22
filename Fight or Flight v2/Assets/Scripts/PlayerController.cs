using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 


public class PlayerController: MonoBehaviour { 

	Vector3 pos;
	public float speed; 
	public float gridSize; 
	public float turnAmount; 

	public float energyCost = 1;

	bool isRotating; 
	public static bool canMove = true; 

	public static bool actionSuccessful = false;

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


	// Use this for initialization 
	void Start () { 
		myOrientation = Orientation.NORTH;

		pos = transform.position;   // For getting the initial position 


	} 

	// Update is called once per frame 
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


		MovePlayer (); 

		if (transform.position == pos) { 

			Vector3 fwd = transform.TransformDirection(Vector3.forward); 

			//		RaycastHit hit; 

			if (Physics.Raycast (transform.position, fwd, out hit, gridSize)) { 
				canMove = false; 
				//      Debug.Log ("Player movement is blocked in this direction by " + hit.transform.name); 
			} else if (isRotating) { 
				canMove = false; 
			} else { 
				canMove = true; 
			} 



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
					} 
			} 

			if (GameManager.energy - energyCost >= 0) { 

				if (Input.GetKey (forward)) { 

					if (!isRotating) { 
						if (canMove) { 
							pos = pos + (transform.forward * gridSize);  
							GameManager.energy = GameManager.energy - energyCost; 

						} else { 

						} 
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

	void AssignControls(KeyCode left, KeyCode down, KeyCode right, KeyCode up){
		forward = up;
		turnRight = right;
		turnLeft = left;
		back = down;

	} 

	public void MoveMultipleUnits(int units){


		Vector3 fwd = transform.TransformDirection(Vector3.forward); 

		if (Physics.Raycast (transform.position, fwd, out hit, gridSize)) {
			GameObject tempHit = hit.transform.gameObject;
			tempHit.layer = 2;
			if (Physics.Raycast (transform.position, fwd, out hit, gridSize * units)) {
				print ("Can't Climb Over");
				tempHit.layer = 0;
			} else {
				actionSuccessful = true;
				for (int i = 0; i < units; i++) {

					if (!isRotating) { 
						pos = pos + (transform.forward * gridSize);  
						//					print (endPlace.transform.name);

					}

				}

				tempHit.layer = 0;
			}

		} else {
			actionSuccessful = true;
			for (int i = 0; i < units; i++) {

				if (!isRotating) { 
					pos = pos + (transform.forward * gridSize);  
					//					print (endPlace.transform.name);

				}

			}
			
		}
			
	}
			


} 