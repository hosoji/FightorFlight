using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKilling : MonoBehaviour {

	// Use this for initialization
	SceneChanger sceneChanger;
	void Start () {
		GameObject gameManager =GameObject.FindGameObjectWithTag ("GameManager");
		sceneChanger = gameManager.GetComponent<SceneChanger> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider coll){
		if (coll.tag == "Player") {
			if (coll.gameObject != null) {
				Debug.Log ("Player hit " + gameObject.name);
				Destroy (coll.gameObject);
				sceneChanger.ReloadScene (1f);
			}
		}
	}
}
