using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Searchable : MonoBehaviour {

	public GameObject searchPrefab;
	GameObject searchObject;

	Vector3 tempPosition;

	float scaleX = 0.26f;
	float scaleY = 0.15f;

	float posX = -0.07f;
	float posY = 1.62f;
	float posZ = 0.025f;

	void Start(){
		searchObject = Instantiate (searchPrefab, transform.position, Quaternion.identity);

		searchObject.transform.SetParent (transform, false);
		searchObject.transform.localScale = new Vector3 (scaleX, scaleY, 0f);
		searchObject.transform.position = new Vector3 (transform.position.x + posX, transform.position.y+ posY, transform.position.z+ posZ);

	}

	public void DisableSearchable(){
		Destroy (searchObject);
		Destroy (this);
	}


}
