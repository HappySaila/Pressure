using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresurePlateScript : MonoBehaviour {


	public int plateNumberType;


	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D(Collider2D blobTouched){
		if (blobTouched.tag == "Blob") {
			sittingBlobScript blobTouchedScript = blobTouched.gameObject.GetComponentInChildren<sittingBlobScript> ();
			blobTouchedScript.setState(plateNumberType);
		}

	}


}
