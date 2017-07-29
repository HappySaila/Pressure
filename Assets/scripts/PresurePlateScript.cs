using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresurePlateScript : MonoBehaviour {

	// Use this for initialization
	public int plateNumberType;
	public int numberOfChangePoints;//numberofblobs it can effect
	private SpriteRenderer sr;
	void Start () {
		sr = GetComponent <SpriteRenderer>();

		switch (plateNumberType) {
		case 0:
			sr.color = Color.white;
			break;
		case 1:
			sr.color = Color.green;
			break;

		case 2:
			sr.color = Color.blue;
			break;

		}

	}


	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D(Collider2D blobTouched){
		if (blobTouched.tag == "Blob") {
			FollowerMainScript blobTouchedScript = blobTouched.gameObject.GetComponentInChildren<FollowerMainScript> ();
			blobTouchedScript.setColourAndType (plateNumberType);
		}

	}


}
