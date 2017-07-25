using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour {

	[SerializeField] GameObject warningObject;
	Vector3 pos;


	Vector3[] directions =  new Vector3[4] {Vector3.forward, Vector3.back, Vector3.left, Vector3.right};
	List <Vector3> availablePositions = new List <Vector3> ();

	void Start(){
	}

	public void SpreadWarning (){

		RaycastHit hit;

		for (int i = 0; i < directions.Length; i++) {
			Vector3 direction = transform.TransformDirection(directions[i]);
			if (Physics.Raycast(transform.position, direction, out hit, GameManager.gridSize)){
				if (hit.transform.tag != "Fire") {
					availablePositions.Add (direction);
				}
			}
		}

		Vector3 targetPos = availablePositions [Random.Range (0, availablePositions.Count)];
		pos = transform.position + targetPos * GameManager.gridSize; 
		Instantiate (warningObject, pos,Quaternion.identity);


	
		
	}




}
