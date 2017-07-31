using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

	public static MusicManager INSTANCE;

	public AudioMixerSnapshot[] Tracks;

	// Use this for initialization
	void Awake () {
		if (INSTANCE == null){
			INSTANCE = this;
		} else {
			Destroy (gameObject);
		}			
	}

	public void SetMusic(bool menu){
		if (menu){
			PlayMenuMusic ();
		} else {
			PlayGameMusic ();
		}
	}

	void Start(){
		DontDestroyOnLoad (gameObject);
	}

	void Update(){
		
	}

	public void PlayGameMusic(){
		Tracks [0].TransitionTo (0);
	}

	public void PlayMenuMusic(){
		Tracks [1].TransitionTo (0);
	}

	public void PlayMuteMusic(){
		Tracks [2].TransitionTo (0);
	}
}
