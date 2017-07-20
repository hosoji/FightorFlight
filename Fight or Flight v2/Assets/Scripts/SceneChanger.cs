using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger: MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ReloadScene(float delay){
		StartCoroutine ("LoadActiveScene", delay);
		
	}

	IEnumerator LoadActiveScene(float delay){

		yield return new WaitForSeconds(delay);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
