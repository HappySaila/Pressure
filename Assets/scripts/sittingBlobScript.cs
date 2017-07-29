using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sittingBlobScript : MonoBehaviour {


	public GameObject player1;
	public GameObject player2;

	public Image Player1Bar;
	public Image Player2Bar;

	public Color white;//0
	public Color green;//1
	public Color purple;//2

	private SpriteRenderer sr;
	private Rigidbody2D rb;

	bool isidle = false;

	private int State;
	//0=white
	//1=green
	//2=purple
	public GameObject particleToSpawn;


	public float particleSpawnRate;

	public float percentONE;//%owned by
	public float percentTWO;


	// Use this for initialization
	void Start () {
		sr = GetComponentInChildren <SpriteRenderer>();
		rb = GetComponentInChildren<Rigidbody2D>();

		setState (0);

	}
	
	// Update is called once per frame
	void Update () {
		JamesLookAt ();
		Behave ();
	}

	void JamesLookAt(){
		GameObject owner;
		if (percentONE > percentTWO) {
			owner = player1;
		} else if(percentONE < percentTWO){
			owner = player2;
		}else{
			owner=null;
		}



		if(	owner != null){
			Vector3 vectorToTarget = owner.transform.position - transform.position;
			float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

			transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 5);
		}

	}


	void Behave(){
		//0=white
		//1=green
		//2=purple

		switch (State) {
		case 0://.WHITE:
			 SendParticles() ;
			break;
		case 1://.GREEN:

			break;
		case 2://.PURPLE:

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
		switch (newState) {
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

	public void SendParticle(GameObject owner){
		GameObject newParticle = (GameObject)GameObject.Instantiate (particleToSpawn, transform.position, Random.rotation );//
				powerParticleMoveScript newParticleScript = newParticle.GetComponent<powerParticleMoveScript> ();
				newParticleScript.setTarget (owner);
				DeltaTimeCount = 0;
	}

	float DeltaTimeCount=0;

	void SendParticles(){
		
		DeltaTimeCount += Time.deltaTime;
		float particlesFor1=percentONE;
		float particlesFor2=percentTWO;


		if (DeltaTimeCount > particleSpawnRate) {
			while(particlesFor1>0.09f ||particlesFor2>0.09f){
				
				if(particlesFor1>0.09f){
					particlesFor1 -= 0.1f;
					SendParticle(player1);
				}
				if(particlesFor2>0.09f){
					particlesFor2 -= 0.1f;
					SendParticle(player2);
				}
			}
			DeltaTimeCount = 0;
		}
	}

	void OnTriggerStay2D(Collider2D c){

		if (c.tag == "PlayerSpotLight") {
			if(player1){
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

		Player1Bar.fillAmount = percentONE;
		Player2Bar.fillAmount = percentTWO;
	}



}
