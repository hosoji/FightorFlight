using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static float energy;

	public static int composure;

	public int startValue;

	UI_HUDManager hud;

	// Use this for initialization
	void Awake () {
		energy = 20;
		composure = startValue;

		hud = GetComponent<UI_HUDManager> ();
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log("Energy: " + energy);
//		Debug.Log("Composure: " + composure);

		if (Input.GetKeyDown (KeyCode.C)) {
			int i = 5;
			if (i < composure + 1) {
				hud.RemoveSegment (i);
			}
		}

		if (Input.GetKeyDown (KeyCode.X)) {
			if (composure <= startValue) {
				hud.AddSegment (3);
			}
		}
		
	}
}
