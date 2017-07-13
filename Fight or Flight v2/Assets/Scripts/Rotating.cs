using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour {

	public float speed =100f;

	public GameObject prefab;
	GameObject movingGameObject;

	public float gridSize;
	public float myHeight;

	// Use this for initialization
	void Start () {

		movingGameObject = Instantiate (prefab, transform.position, Quaternion.identity);
		movingGameObject.transform.SetParent (this.transform);

		for (int i = 1; i <= myHeight; i++) {
			Vector3 height = new Vector3(transform.position.x+ (gridSize * i),transform.position.y + (gridSize * i),transform.position.z);
			GameObject g = Instantiate (prefab, height, Quaternion.identity);
			g.transform.SetParent (movingGameObject.transform);

		}
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * (Time.deltaTime * speed), Space.World);
	}
		
}
