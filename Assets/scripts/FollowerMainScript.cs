using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerMainScript : MonoBehaviour {

	public GameObject owner;

	public float currentSpeed;
	public float turnspeed;
	public float currentSize;
	public float idleDistance;
	public float RandumRangeMultiplyer;

	public Color purple;
	public Color green;
	public Color white;

	private SpriteRenderer sr;
	private Rigidbody2D rb;
	private Vector3 RandumVectorToAddToOwnerPosition;
	private Vector3 RandumVectorPositionIdle;

	bool isidle = false;
	bool canMove;


	public int State;
	public GameObject particleToSpawn;



	void Start () {
		sr = GetComponentInChildren <SpriteRenderer>();
		rb = GetComponentInChildren<Rigidbody2D>();

		//for inumererator
		canMove = false;
		callStartMoving ();

		if (owner != null) {
			RandumVectorToAddToOwnerPosition = new Vector3 (Random.Range (-1.0f * RandumRangeMultiplyer, 1.0f * RandumRangeMultiplyer), Random.Range (-1.0f * RandumRangeMultiplyer, 1.0f * RandumRangeMultiplyer), 0.0f);
		}
	}
	

	void Update () {
		if (canMove) {
			UpdateMovementAndOrientation ();
		}
		Behave ();


	}

	void UpdateMovementAndOrientation(){
		if (owner != null) {
			if (idleDistance > Vector2.Distance (transform.position, owner.transform.position)) {//idle
				isidle = true;
				rb.velocity = Vector2.zero;
			} else {
				isidle = false;
				rb.velocity = transform.right * Time.deltaTime * currentSpeed;
			}
			JamesLookAt ();
		}
	}



	void Behave(){
		switch (State) {
		case 0://LightState.WHITE:
			SendParticle();
			break;
		case 1://LightState.GREEN:
			
			break;
		case 2://LightState.PURPLE:

			break;
		}
	}


	public int getType(){
		return State;
	}


	//uses the googled look at 
	void JamesLookAt(){
		Vector3 vectorToTarget = owner.transform.position - transform.position;
		float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

		transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * turnspeed);
	}

	public void setOwner(GameObject newOwner){
		
		if (owner == null) {
			RandumVectorToAddToOwnerPosition = new Vector3 (Random.Range (-1.0f * RandumRangeMultiplyer, 1.0f * RandumRangeMultiplyer), Random.Range (-1.0f * RandumRangeMultiplyer, 1.0f * RandumRangeMultiplyer), 0.0f);
		}
		owner = newOwner;
	}
	public GameObject getOwner(){
		return owner;
	}




	public void setColourAndType(int InState){
		State = InState;
		switch (State) {
		case 0:///LightState.PURPLE:
			sr.color = purple;

			break;
		case 1://LightState.GREEN:
			sr.color = green;
			break;
		case 2:
			sr.color = white;
			break;
		}

	}



	public void callStartMoving(){
		canMove = true;
	}

	float DeltaTimeCount=0;
	public float particleSpawnRate;

	public void SendParticle(){
		DeltaTimeCount += Time.deltaTime;

		if(DeltaTimeCount > particleSpawnRate){
			GameObject newParticle = (GameObject)GameObject.Instantiate (particleToSpawn,transform.position,transform.rotation);
			powerParticleMoveScript newParticleScript = newParticle.GetComponent<powerParticleMoveScript> ();
			newParticleScript.setTarget (owner);
			DeltaTimeCount = 0;
		}

	}




}
