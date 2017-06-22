using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_EquipSlot : MonoBehaviour {


	public bool SlotAvailable(){
		Card info = GetComponentInChildren<Card> ();

		if (info != null) {
			return false;
		} else {
			return true;
		}
	}

	public void ActivateSlotFunction(){
		Card info = GetComponentInChildren<Card> ();
		if (info != null) {
			Debug.Log ("Card Name is: " + info.gameObject.name);

		} else {
			Debug.Log ("No Card Selected");

		}


	}
}
