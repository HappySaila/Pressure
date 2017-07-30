using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sittingBlobScript : MonoBehaviour {


	GameObject player1;
	GameObject player2;

	public Image Player1Bar;
	public Image Player2Bar;

	public Color white;//0
	public Color green;//1
	public Color purple;//2

	private SpriteRenderer sr;
	private Rigidbody2D rb;

	bool isidle = false;
	public float spawnDelay;
		
	private int State;
	//0=white
	//1=green
	//2=purple
	public GameObject particleToSpawn;
	public GameObject particleToSpawnNoDirection;

	public float particleSpawnRate;

	float percentONE;//%owned by
	float percentTWO;

	float DeltaTimeCount=0;

	// Use this for initialization
	void Start () {
		sr = GetComponentInChildren <SpriteRenderer>();
		rb = GetComponentInChildren<Rigidbody2D>();

		setState (0);
		SetPlayers ();

		percentONE = 0.02f;
		percentTWO = 0.02f;
		updateOwnerShipBars ();
		GetComponent<Animator> ().speed = 1/spawnDelay;
	}

	void SetPlayers(){
		SpotlightMovmentScpit[] players = GameObject.FindObjectsOfType <SpotlightMovmentScpit> ();
		if (players[0].player1){
			player1 = players [0].gameObject;
			player2 = players [1].gameObject;
		} else {				 
			player1 = players [1].gameObject;
			player2 = players [0].gameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Behave(){
		//0=white
		//1=green
		//2=purple

		switch (State) {
		case 0://.WHITE:
			StartCoroutine (SendParticles(particleToSpawn));
			break;
		case 1://.GREEN:
			StartCoroutine (SendParticles(particleToSpawn));

			break;
		case 2://.PURPLE:
			StartCoroutine (SendParticles(particleToSpawnNoDirection));
			break;
		}
	}


	public int getState(){
		
		return State;
	}
	public void setState(int newState){
		//0=white
		//1=green
		//2=purple


		State = newState;
		switch (State) {
		case 0:
			sr.color = white;
			break;
		case 1:
			sr.color = green;
			break;
		case 2:
			sr.color = purple;
			break;
		}

	}

	void SendParticle(GameObject owner,GameObject sendParticle){
		
			GameObject newParticle = (GameObject)GameObject.Instantiate (sendParticle, transform.position, Random.rotation );
			powerParticleMoveScript newParticleScript = newParticle.GetComponent<powerParticleMoveScript> ();
			newParticleScript.setTarget (owner);
		if (State == 0) {
			newParticleScript.setColourOfParticle (green);//white blobs shoot gree particles
		} else {
			newParticleScript.setColourOfParticle (sr.color);
		}
			
	}
	//for sendParticle methor
	float cutoff=0.18f;
	float step= 0.2f;
	//

	IEnumerator SendParticles(GameObject sendParticle){
		//sendsparticle burst
		float particlesFor1 = percentONE;
		float particlesFor2 = percentTWO;

		switch (State) {
		case 0://white
			cutoff=0.18f;
			step= 0.2f;
			break;
		case 1://green
			cutoff=0.09f;
			step= 0.1f;
			break;
		case 2://purp
			cutoff=0.0135f;
			step= 0.015f;
			break;
		}


		while (particlesFor1 > cutoff || particlesFor2 > cutoff) {
			yield return new WaitForSeconds (step);
			if (particlesFor1 > cutoff) {
				particlesFor1 -= step;
				SendParticle (player1, sendParticle);
			}
			if (particlesFor2 > cutoff) {
				particlesFor2 -= step;
				SendParticle (player2, sendParticle);
			}
		}
	}

	void OnTriggerStay2D(Collider2D c){

		if (c.tag == "PlayerSpotLight") {
			if(c.gameObject.GetComponent <SpotlightMovmentScpit>().player1){
				Captured (1);
			}
			else{
				Captured (2);
			}

		}
	}


	public void Captured(int player){
		
		if (player == 1 && (percentONE<1.0f)) {
			if(1.0f-percentONE>percentTWO){
				percentONE += 0.01f;
			}else{
				percentTWO -= 0.01f;
				percentONE += 0.01f;
			}
		} else if (player == 2 &&(percentTWO<1.0f)){//2
			if (1.0f - percentTWO > percentONE) {
				percentTWO += 0.01f;
			} else {
				percentONE -= 0.01f;
				percentTWO += 0.01f;
			}
		}

		updateOwnerShipBars ();

	}

	void updateOwnerShipBars (){
		Player1Bar.fillAmount = percentONE;
		Player2Bar.fillAmount = percentTWO;
	}



}
