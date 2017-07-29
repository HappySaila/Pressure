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
		if(c.tag=="Blob"){
			
		GameObject newBlob = (GameObject)GameObject.Instantiate (thingToSpawn,transform.position,transform.rotation);

		FollowerMainScript newBlobScript=newBlob.GetComponentInChildren<FollowerMainScript>();
		FollowerMainScript oldBlobScript=c.gameObject.GetComponent<FollowerMainScript>();
		newBlobScript.setOwner (oldBlobScript.getOwner());
		newBlobScript.callStartMoving ();
	
		//yes more effent 
		//newBlob.GetComponentInChildren<FollowerMainScript>().setOwner (c.gameObject.GetComponent<FollowerMainScript>().owner);
		
		Destroy (gameObject);
		}
	}

}