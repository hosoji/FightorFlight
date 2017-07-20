using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour {

	SceneChanger sceneChanger;
	// Use this for initialization
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
				Debug.Log ("Player Reached " + gameObject.name);
				sceneChanger.ReloadScene (5f);
			}
		}
	}
}
