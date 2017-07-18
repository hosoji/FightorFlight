using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CardPanel : MonoBehaviour {

	public static int slotNum;

	public Image img;

	INTRCTN_Carry equip;
	INTRCTN_Discard discard;
	INTRCTN_Energize energize;
	INTRCTN_Use use;

	void Awake(){
		equip = GetComponentInChildren<INTRCTN_Carry> ();
		discard = GetComponentInChildren<INTRCTN_Discard> ();
		energize = GetComponentInChildren<INTRCTN_Energize> ();
		use = GetComponentInChildren<INTRCTN_Use> ();
	}

	public void SetPanelImage(Sprite image){
		img.sprite = image;
	}



	public void DisablePanel(){
//		ClearPanel();
		gameObject.SetActive (false);
	}

	public void SetSlot(int num){
		slotNum = num;
		print (slotNum);
	}

	public void EnableUse(bool b){
		use.gameObject.SetActive (b);
	}

	public void EnableCarry(bool b){
		equip.gameObject.SetActive (b);
	}

	public void EnableDiscard(bool b){
		discard.gameObject.SetActive (b);
	}

	public void EnableEnergize(bool b){
		energize.gameObject.SetActive (b);
	}
		
}
