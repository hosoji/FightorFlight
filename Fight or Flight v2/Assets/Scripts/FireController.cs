using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour {

	public GameObject prefab;
	GameObject movingGameObject;

	Vector3 spiralPos;

	public float myWidth;

	public float speed;

	public float gridSize;

	List<Vector3> wayPoints = new List<Vector3>();

	// Use this for initialization
	void Start () {

		SetWayPoints ();

		Vector3 pos = transform.position + (Vector3.forward * gridSize);

		movingGameObject = Instantiate (prefab, transform.position, Quaternion.identity);


		for (int i = 1; i <= myWidth; i++) {
			Vector3 width = new Vector3(transform.position.x + (gridSize * i),transform.position.y,transform.position.z);
			GameObject g = Instantiate (prefab, width, Quaternion.identity);
			g.gameObject.transform.SetParent (movingGameObject.transform);

		}

	

		spiralPos = movingGameObject.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

		MoveTransform ();


		if (movingGameObject.transform.position == spiralPos) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				spiralPos = spiralPos + (transform.forward * gridSize);
			}
		}

	





	}
		

	void MoveTransform(){ 
		movingGameObject.transform.position = Vector3.MoveTowards (movingGameObject.transform.position, spiralPos, Time.deltaTime * speed); 

	} 

	void SetWayPoints(){
		wayPoints.Add (transform.position);
		wayPoints.Add(transform.position + (transform.forward * gridSize));

		for (int w = 0; w < wayPoints.Count; w++) {
			print (wayPoints[w]);
		}

			
	}



}
