using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticles : MonoBehaviour {
	public int numberOfParticles;
	public GameObject blob;

	// Use this for initialization
	void Start () {
		float radius = GetComponent <CircleCollider2D> ().radius;
		for (int i = 0; i < Random.Range (0,numberOfParticles); i++) {
			float xOffset = Random.Range (-radius/2, radius/2);
			float yOffset = Random.Range (-radius/2, radius/2);
			GameObject blobInstance = (GameObject)Instantiate (blob, transform.position + new Vector3(xOffset, yOffset, 0), transform.rotation);
			blobInstance.transform.parent = transform;
			blobInstance.transform.localScale = new Vector3 (radius / 2, radius / 2, 1);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
