using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {
	public Text Winner;
	public Animator panelAnim;

	void Start(){
		Winner.text = "Player " + ScoreManager.instance.GetWinner() + "\nwins!";
	}

	public void btnBackClicked(){
		StartCoroutine (BackClicked());
	}

	IEnumerator BackClicked(){
		panelAnim.SetTrigger ("SwipeOut");
		yield return new WaitForSeconds (1f);
		SceneManager.LoadScene (0);
	}
}
