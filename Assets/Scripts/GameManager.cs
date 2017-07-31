using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	//managers the flow of the game
	GameObject Player1;
	GameObject Player2;
	public Transform Player1SpawnPosition;
	public Transform Player2SpawnPosition;
	public Text player1Score;
	public Text player2Score;

	public int moveCost;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		StartCoroutine (SetUp());
	}

	IEnumerator SetUp(){
		//load scores into UI
		player1Score.text = ScoreManager.instance.score1 + "";
		player2Score.text = ScoreManager.instance.score2 + "";

		//get the players
		moveCost = 1;
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

		Player1.GetComponent <SpotlightMovmentScpit> ().StartUp ();
		Player2.GetComponent <SpotlightMovmentScpit> ().StartUp ();
		BlobManager.Instance.canSpawn = true;
	}

	public void btnQuitClicked(){
		SceneManager.LoadScene (0);
		MusicManager.INSTANCE.SetMusic (true);
	}

	public void PlayerDied(bool Player1Died){
		moveCost = 0;
		SoundManager.INSTANCE.PlayDie ();
		StartCoroutine (RestartRound(Player1Died));
	}

	IEnumerator RestartRound(bool Player1Died){
		//save players scores
		if (Player1Died){
			ScoreManager.instance.score2++;
		} else {
			ScoreManager.instance.score1++;
		}

		if (ScoreManager.instance.isWinner()){
			//player has won - go to win screen
			SceneManager.LoadScene (2);
		} else {
			yield return new WaitForSeconds (3);
			
			SceneManager.LoadScene (1);
		}
			
	}
}
