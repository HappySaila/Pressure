using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideManager : MonoBehaviour {
	public static SlideManager instance;

	public GameObject[] slides;
	public Animator anim;
	int currentSlide;

	void Awake(){
		instance = this;
	}

	void Start(){
		currentSlide = 0;
		slides [0].SetActive (true);
		for (int i = 1; i < slides.Length; i++) {
			slides [i].SetActive (false);

		}
	}

	public void NextSlide (){
		slides [currentSlide].SetActive (false);
		currentSlide++;
		currentSlide = Mathf.Clamp (currentSlide, 0, slides.Length - 1);
		slides [currentSlide].SetActive (true);
	}

	public void PreviousSlide(){
		slides [currentSlide].SetActive (false);
		currentSlide--;
		currentSlide = Mathf.Clamp (currentSlide, 0, slides.Length - 1);
		slides [currentSlide].SetActive (true);
	}

	public void Back(){
		anim.SetTrigger ("SwipeOut");
		UIManager.instance.mainMenu.SetTrigger ("SwipeIn");
	}
}
