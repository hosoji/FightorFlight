using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatCounter : MonoBehaviour {



	public static int thinkCounter;
	public static int totalThinkCount;

	public static int deckReloadCounter;
	public static int totalDeckReloadCount;

	public int thinkCountLimit;
	public int reloadCountLimit;



	void Update () {

		if (thinkCounter > thinkCountLimit) {
			// Insert function call - what this condition is supposed to do
			thinkCounter = 0;

		}

		if (deckReloadCounter > reloadCountLimit) {
			// Insert function call - what this condition is supposed to do
			deckReloadCounter = 0;

		}

//		Debug.Log (deckReloadCounter + " times Reloaded");

			
		
	}

	public static void IncrementTotalThink(){
		thinkCounter++;
		totalThinkCount++;
	}

	public static void IncrementTotalDeckReload(){
		deckReloadCounter++;
		totalDeckReloadCount++;
	}
}
