using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
	public Animator mainMenu;
	public Animator statsMenu;
	public Animator settingsMenu;

	// Use this for initialization
	void Start () {
		mainMenu.SetTrigger ("SwipeIn");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void btnPlayClicked(){
		SceneManager.LoadScene (1);
	}

	public void btnStatsClicked(){
		statsMenu.SetTrigger ("SwipeIn");
		mainMenu.SetTrigger ("SwipeOut");
	}

	public void btnStatsBackClicked(){
		statsMenu.SetTrigger ("SwipeOut");
		mainMenu.SetTrigger ("SwipeIn");
	}

	public void btnSettingsClicked(){
		settingsMenu.SetTrigger ("SwipeIn");
		mainMenu.SetTrigger ("SwipeOut");
	}

	public void btnSettingsBackClicked(){
		settingsMenu.SetTrigger ("SwipeOut");
		mainMenu.SetTrigger ("SwipeIn");
	}

	public void btnQuitClicked(){
		statsMenu.SetTrigger ("SwipeIn");
	}
}
