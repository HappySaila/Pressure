using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	//managers the flow of the game
	public GameObject Player1;
	public GameObject Player2;
	public Transform Player1SpawnPosition;
	public Transform Player2SpawnPosition;

	// Use this for initialization
	void Start () {
		StartCoroutine (SetUp());
	}

	IEnumerator SetUp(){
		//get the players
		SpotlightMovmentScpit[] players = GameObject.FindObjectsOfType <SpotlightMovmentScpit> ();
		if (players[0].player1){
			Player1 = players [0].gameObject;
			Player2 = players [1].gameObject;
		} else {				 
			Player1 = players [1].gameObject;
			Player2 = players [0].gameObject;
		}

		//spawn the players
		Player1.transform.position = Player1SpawnPosition.position;
		Player2.transform.position = Player2SpawnPosition.position;

		Player1.GetComponent <Animator>().SetTrigger ("Revive");
		yield return new WaitForSeconds (0.5f);

		Player2.GetComponent <Animator>().SetTrigger ("Revive");
		Player2.transform.rotation = Quaternion.Euler (new Vector3 (0,0,180));
		yield return new WaitForSeconds (1);

		//start count down
		CountDownTimer.Instance.StartCountDownTimer ();
		yield return new WaitUntil (() => CountDownTimer.Instance.gameStarted);

		Player1.GetComponent <SpotlightMovmentScpit>().canMove = true;
		Player2.GetComponent <SpotlightMovmentScpit>().canMove = true;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void btnQuitClicked(){
		SceneManager.LoadScene (0);
	}
}
