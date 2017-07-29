using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnOBJwithTarget : MonoBehaviour {

	public GameObject thingToSpawn;

	void Start () {
			
	}

	void Update () {

	}

	void OnTriggerEnter2D(Collider2D c){
		if(c.tag == "Blob"){
			GameObject newBlob = (GameObject)GameObject.Instantiate (thingToSpawn,transform.position,transform.rotation);

			sittingBlobScript newBlobScript=newBlob.GetComponentInChildren<sittingBlobScript>();
			sittingBlobScript oldBlobScript=c.gameObject.GetComponent<sittingBlobScript>();


			
			Destroy (gameObject);
		}
	}

}