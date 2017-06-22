using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EnergyManager : MonoBehaviour {

	public Image energyAmount;

	public Text energyText;

//	public static float inactiveEnergy;

//	public GameObject eneUnitObject;
//
//	GameObject eneUnitHolder;

//
//	public Color activeColor;
//	public Color inactiveColor;
//

//	Image eneUnitImg;

//	public List<GameObject> engSegments = new List<GameObject>();


//	float energy;
//

//	void Start (){
//
//		inactiveEnergy = 0;
//
//		eneUnitHolder = GameObject.Find ("Energy Segments Holder");
//		eneUnitImg = eneUnitObject.GetComponent<Image>();
//
//		for (int i = 0; i < GameManager.energy; i++) {
//			float mod = -1f;
//
//			Vector3 pos = new Vector3 ((eneUnitImg.rectTransform.rect.width * mod) * i, 0,0);
//
//			GameObject image = Instantiate (eneUnitObject, pos, Quaternion.identity) as GameObject;
//
//
//			image.transform.SetParent (eneUnitHolder.transform,false);
//			image.name = i.ToString (); 
//
//			Image img = image.GetComponent<Image> ();
//			img.color = inactiveColor;
//
//			engSegments.Add (image);
//		}
//
//
//	}
//
	// Update is called once per frame
	void Update () {


		float energyFill = UtilScript.remapRange (GameManager.energy, 0, 10, 0, 1);
		energyAmount.fillAmount = energyFill;

		float energyNum = GameManager.energy * 10;

		energyText.text = energyNum.ToString ();

//		float eneFill = UtilScript.remapRange (GameManager.energy, 0, 10, 0, (float)engSegments.Count);
//
//
//		int num = Mathf.FloorToInt (eneFill);
//		inactiveEnergy = engSegments.Count - num;
//
//		print (num);
//
//		energy = GameManager.energy-1;
//
//		for (int i = 0; i < energy; i++) {
//			Image img = engSegments [i].GetComponent<Image> ();
//			img.color = activeColor;
//		}

	}


//	public void RemoveSegment (int n){
//
//		for (int i = 0; i < n; i++) {
//			energy = (float)engSegments.Count - 1;
//
//			GameObject seg = engSegments[(int)energy];
//			engSegments.Remove (seg);
//			Destroy (seg);
//
//
//
//		}
//	}
//
//	public void AddSegment (int n){
//		for (int i = 0; i < n; i++) {
//			energy = GameManager.energy-1;
//
//
//			float mod = -1f;
//			Vector3 pos = new Vector3 ((eneUnitImg.rectTransform.rect.width * mod) * (engSegments.Count), 0, 0);
//			GameObject image = Instantiate (eneUnitObject, pos, Quaternion.identity) as GameObject;
//			image.transform.SetParent (eneUnitHolder.transform,false);
//
//			image.name = (engSegments.Count).ToString();
//
//			engSegments.Add (image);
//		}
//	}
//

}
