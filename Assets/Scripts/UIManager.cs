﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
	public Animator mainMenu;
	public Animator instructionsMenu;

	// Use this for initialization
	void Start () {
		mainMenu.SetTrigger ("SwipeIn");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void btnPlayClicked(){
		SceneManager.LoadScene (1);
		MusicManager.INSTANCE.SetMusic (false);
	}

	public void btnStatsClicked(){
		instructionsMenu.SetTrigger ("SwipeIn");
		mainMenu.SetTrigger ("SwipeOut");
	}

	public void btnStatsBackClicked(){
		instructionsMenu.SetTrigger ("SwipeOut");
		mainMenu.SetTrigger ("SwipeIn");
	}

	public void btnQuitClicked(){
		instructionsMenu.SetTrigger ("SwipeIn");
		MusicManager.INSTANCE.SetMusic (true);
	}
}
