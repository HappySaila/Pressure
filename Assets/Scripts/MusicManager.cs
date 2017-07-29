﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

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

	void Start(){
		DontDestroyOnLoad (gameObject);
	}

	public void PlayGameMusic(){
		Tracks [0].TransitionTo (2f);
	}

	public void PlayMenuMusic(){
		Tracks [1].TransitionTo (2f);
	}

	public void PlayMuteMusic(){
		Tracks [2].TransitionTo (2f);
	}
}