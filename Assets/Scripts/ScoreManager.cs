using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
	public static ScoreManager instance;
	public int score1;
	public int score2;

	void Awake(){
		if (instance == null){
			instance = this;
			Reset ();
		} else {
			Destroy (gameObject);
		}
	}

	public void Reset(){
		score1 = score2 = 0;
	}

	public bool isWinner(){
		return (score1 == 3 || score2 == 3);
	}
}
