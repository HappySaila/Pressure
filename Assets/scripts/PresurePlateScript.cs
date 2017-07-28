using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresurePlateScript : MonoBehaviour {

	// Use this for initialization
	public int plateNumberType;
	private SpriteRenderer sr;
	void Start () {
		sr = GetComponent (SpriteRenderer);


		if(plateNumberType==null){
			plateNumberType=Random.Range(0,5);
		}
		switch (plateNumberType) {
		case 1:
			sr.color = Color.red;
			break;

		case 2:
			sr.color = Color.blue;
			break;

		case 3:
			sr.color = Color.green;
			break;

		case 4:
			sr.color = Color.black;
			break;

		case 5:
			sr.color = Color.magenta;
			break;

		}
			


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
