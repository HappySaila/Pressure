using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobManager : MonoBehaviour {
	public int maxBlobs;
	public int currentBlobs;
	public GameObject blobInstance;
	public int spawnRate;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnBlobs());
	}
	
	IEnumerator SpawnBlobs(){
		yield return new WaitUntil (() => currentBlobs < maxBlobs);
		yield return new WaitForSeconds (Random.Range (spawnRate,spawnRate*2));
		float x = Random.Range (-7f,7f);
		float y = Random.Range (-4f,4f);
		Vector3 position = new Vector3 (x,y,0);
		Instantiate (blobInstance, position, transform.rotation);
		StartCoroutine (SpawnBlobs());
	}
}
