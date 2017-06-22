using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour {

	float flicker;

	public float modX = 5f;
	public float modY = 3.5f;

	public float baseMod = 1;

	public Light lg;



	void Update () {
		
		flicker = baseMod + Mathf.PerlinNoise (Time.time * modX, Time.time * modY);

		lg.intensity = flicker;

//		Debug.Log (" Intensity is: " + flicker);

	}
}
