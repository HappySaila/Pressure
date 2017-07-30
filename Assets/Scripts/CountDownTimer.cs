using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour {
	public static CountDownTimer Instance;
	Text text;
	Animator anim;
	int count = 3;
	public bool gameStarted;

	void Awake(){
		Instance = this;
	}


	// Use this for initialization
	void Start () {
		text = GetComponent <Text> ();
		anim = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartCountDownTimer(){
		text.enabled = true;
		text.text = count+"";
		anim.SetTrigger ("StartCountDown");
	}

	public void Tick(){
		count--;
		if (count == 0){
			text.text = "GO";
			anim.SetTrigger ("Done");
			gameStarted = true;
		} else {
			text.text = count+"";
		}
			
	}
}
