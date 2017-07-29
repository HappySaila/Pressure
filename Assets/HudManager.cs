using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour {
	public static HudManager Instance;

	public Image Player1Source;
	public Image Player2Source;


	void Awake(){
		Instance = this;
	}

	public void UpdatePowerSource(bool PlayerOne, float amount){
		if (PlayerOne){
			Player1Source.fillAmount = amount;
		} else {
			Player2Source.fillAmount = amount;
		}
	}
}
