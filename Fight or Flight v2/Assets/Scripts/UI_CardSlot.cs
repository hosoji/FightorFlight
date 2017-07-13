using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CardSlot : MonoBehaviour {

	UI_CardPanel panel;
	public GameObject infoPanel;

	// Use this for initialization
	void Start () {
		panel = infoPanel.GetComponent<UI_CardPanel> ();	
	}


	public void GetCardInfo(){
		Card info = GetComponentInChildren<Card> ();
		if (info != null) {
			Debug.Log ("Card Name is: " + info.gameObject.name);
			infoPanel.SetActive (true);
		} else {
			Debug.Log ("No Card Selected");
			infoPanel.SetActive (false);
		}
	}


}
