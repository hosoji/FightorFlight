using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EnergyManager : MonoBehaviour {

	public Image energyAmount;

	public Text energyText;

	void Update () {


		float energyFill = UtilScript.remapRange (GameManager.energy, 0, 100, 0, 1);
		energyAmount.fillAmount = energyFill;

		float energyNum = GameManager.energy;

		energyText.text = energyNum.ToString ();
	}

}
