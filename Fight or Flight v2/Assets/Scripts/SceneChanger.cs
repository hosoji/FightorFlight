using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger: MonoBehaviour {



	public void ReloadScene(float delay){
		StartCoroutine ("LoadActiveScene", delay);
		
	}

	IEnumerator LoadActiveScene(float delay){

		yield return new WaitForSeconds(delay);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
