using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CardLoader : MonoBehaviour {

	public static GameObject [] slots = new GameObject[3];

	public GameObject placeholder;

	GameObject[] cards = new GameObject[3];

	public int loadTime = 3;
	bool isLoading = false;

	void Start(){
		for (int i = 0; i < slots.Length; i++) {
			int n = i + 1;
			string g = "Card Slot " + n.ToString ();
			slots [i] = GameObject.Find (g);
		}
		
	}


	public void DrawNewCards(){
		if (!isLoading) {
			StartCoroutine ("LoadCards");
		} else {
			Debug.Log ("Still Loading...");

			//Insert else code
		}
	}

	IEnumerator LoadCards(){


		for (int i = 0; i < slots.Length; i++) {

			Card card = slots [i].GetComponentInChildren<Card> ();
			if (card != null) {
				Destroy (card.gameObject);
			}

		}

		Debug.Log ("Loading");
		isLoading = true;

		//Insert Loading code

		yield return new WaitForSeconds (loadTime);

		isLoading = false;

		for (int i = 0; i < slots.Length; i++) {

			cards [i] = Instantiate(placeholder,slots [i].transform.position,Quaternion.identity)  as GameObject;
			RectTransform rectTransform = cards[i].GetComponent<RectTransform>();
			cards[i].transform.SetParent(slots[i].transform, false);
//			if (rectTransform != null) {
//				rectTransform.localPosition = new Vector3(0f, 0f, 0f);
//				rectTransform.localRotation = Quaternion.identity;
//				rectTransform.localScale = new Vector3(1f, 1f, 1f);
//			}
		}


		Debug.Log ("Loaded");

		//Insert New cards code

	}

	public void LoadInfoPanel(){
		Debug.Log ("panel loaded");
	}

	public void UnloadInfoPanel(){
		Debug.Log ("panel unloaded");
	}
}
