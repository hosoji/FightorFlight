﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour {

	SceneChanger sceneChanger;

	void Start () {
		GameObject gameManager =GameObject.FindGameObjectWithTag ("GameManager");
		sceneChanger = gameManager.GetComponent<SceneChanger> ();
		
	}


	void OnTriggerEnter(Collider coll){
		if (coll.tag == "Player") {
			if (coll.gameObject != null) {
				Debug.Log ("Player Reached " + gameObject.name);
				Destroy (coll.gameObject);
				sceneChanger.ReloadScene (5f);
			}
		}
	}
}
