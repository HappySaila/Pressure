using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightManager : MonoBehaviour {
	public static SpotLightManager Instance;
	public GameObject spotLightPrefab;
	public Transform Origin;
	public float spawnDistance;
	[HideInInspector] public bool canSpawn = true;

	// Use this for initialization
	void Awake(){
		Instance = this;
	}

	void Start () {
		StartCoroutine (StartSpawning());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnSpotLight(){
		Vector3 spawnPosition = new Vector3 (Random.Range (-1f, 1f), Random.Range (-1f, 1f), 0).normalized;
		spawnPosition += Origin.position;
		spawnPosition = ((Origin.position - spawnPosition) * spawnDistance) + Origin.position;
		GameObject spotLight = (GameObject)Instantiate (spotLightPrefab, spawnPosition, transform.rotation);
	}

	IEnumerator StartSpawning(){
		SpawnSpotLight ();
		yield return new WaitForSeconds (Random.Range (3, 6));
		if (canSpawn){
			StartCoroutine (StartSpawning ());
		}
	}



}
