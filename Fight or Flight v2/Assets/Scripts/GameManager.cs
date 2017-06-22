﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static float energy;

	public static int composure;

	public int startValue = 20;
	public static int maxValue = 30;


	public float startEnergy = 7;
	public static float maxEnergy = 10;

	UI_MeterManager hud;



	// Use this for initialization
	void Awake () {
		energy = startEnergy;
		composure = startValue;

		hud = GetComponent<UI_MeterManager> ();
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
			int i = 3;
			if (composure + i <= startValue) {
				hud.AddSegment (i);
			}
		}
		
	}


}
