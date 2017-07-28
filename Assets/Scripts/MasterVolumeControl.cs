using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MasterVolumeControl : MonoBehaviour {
	public static MasterVolumeControl INSTANCE;

	public AudioMixer audioMixer;
	public Slider SFXSlider;
	public Slider MusicSlider;

	void Awake(){
		INSTANCE = this;
	}

	// Update is called once per frame
	public void UpdateMixer () {
		//-80 to account for decibels
		float SFXVal = (1-SFXSlider.value)*-80;
		float MusicVal = (1-MusicSlider.value)*-80;
		//calculate set value
		SFXVal = (SFXSlider.value <= 0.7f) ? -80 : SFXVal;
		MusicVal = (MusicSlider.value <= 0.7f) ? -80 : MusicVal;
		//set volume 
		audioMixer.SetFloat ("MusicVolume", MusicVal);
		audioMixer.SetFloat ("SFXVolume", SFXVal);
	}
}
