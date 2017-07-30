using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobManager : MonoBehaviour {
	public static BlobManager Instance;

	public int maxBlobs;
	public int currentBlobs;
	public GameObject blobInstance;
	public int spawnRate;
	[HideInInspector] public bool canSpawn;

	void Awake(){
		Instance = this;
	}

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnBlobs());
	}
	
	IEnumerator SpawnBlobs(){
			currentBlobs = GameObject.FindObjectsOfType <sittingBlobScript> ().Length;
			yield return new WaitForSeconds (Random.Range (spawnRate,spawnRate*2));
			float x = Random.Range (-7f,7f);
			float y = Random.Range (-4f,4f);
			Vector3 position = new Vector3 (x,y,0);
		if (canSpawn && currentBlobs < maxBlobs){
			Instantiate (blobInstance, position, transform.rotation);
		}
			StartCoroutine (SpawnBlobs());
	}
			
}
