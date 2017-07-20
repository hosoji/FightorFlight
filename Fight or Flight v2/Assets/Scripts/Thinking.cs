using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thinking : MonoBehaviour {

	Image image;
	UI_CardLoader loader;

	public float mod = 0;
	float amountLoaded;
	bool buttonPressed = false;
	float loadingTime = 0;

	// Use this for initialization
	void Start () {
		GameObject cardManager = GameObject.FindGameObjectWithTag ("CardManager");
		loader = cardManager.GetComponent<UI_CardLoader> ();
		image = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {

		loadingTime = loader.loadTime;
		float newLoadingTime;


		if (buttonPressed) {
			amountLoaded = amountLoaded + Time.deltaTime; 
			newLoadingTime = Mathf.Clamp01(UtilScript.remapRange (amountLoaded, 0, loadingTime, 0,1 ));


			image.fillAmount = newLoadingTime;
//			Debug.Log (newLoadingTime);

			if (newLoadingTime == 1) {
				buttonPressed = false;
			}

		}



		
		
	}

	public void FillSprite(){
		if (!buttonPressed) {
			amountLoaded = 0;
			buttonPressed = true;
			print ("Button pressed");
		}
	}

}
