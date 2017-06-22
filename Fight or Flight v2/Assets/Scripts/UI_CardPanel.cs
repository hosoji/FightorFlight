using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CardPanel : MonoBehaviour {

	public static int slotNum;

	public Image img;


	public void SetPanelImage(Sprite image){
		img.sprite = image;
	}

	public void ClearPanel(){
		Button[] buttons = gameObject.GetComponents<Button> ();

		for (int i = 0; i < buttons.Length; i++) {
			Destroy (buttons [i]);
		}

	}

	public void DisablePanel(){
		ClearPanel();
		gameObject.SetActive (false);
	}

	public void SetSlot(int num){
		slotNum = num;
		print (slotNum);
	}
}
