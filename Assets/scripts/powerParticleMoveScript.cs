﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerParticleMoveScript : MonoBehaviour {

	// Use this for initialization
	GameObject Target;

	public float particleSpeed;
	public float particleTurnSpeed;
	public float consumeDistance;
	public float amountOfPowerHeld;
	public bool IsConsumed;

	private Rigidbody2D rb;
	private SpriteRenderer sr;

	private SpotlightMovmentScpit TargetSpotlightMovmentScpit;
	bool canMove;
	float SizeTracker;

	public float waitTimeforMovment;//=0.001f

	private int chargeOfparticle; //1 or -1   

	public int timeToLiveFor;
	void Start () {
		rb = GetComponent<Rigidbody2D>();


		Invoke ("Die", timeToLiveFor);
		StartCoroutine (activateMovement());
		SizeTracker = transform.localScale.x;
	}

	void Die(){
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		UpdateMovementAndOrientation ();
		amountOfPowerHeld +=Time.deltaTime;
		SizeTracker += 0.001f;
		//Debug.Log (SizeTracker);

		//transform.localScale = new Vector3 (SizeTracker, SizeTracker, 0f);
	}

	void UpdateMovementAndOrientation(){
		if (Target != null) {
			if (consumeDistance > Vector2.Distance (transform.position, Target.transform.position)) {//idle
				IsConsumed = true;
				rb.velocity = Vector2.zero;
			} else {
				IsConsumed = false;
				rb.velocity = transform.right * Time.deltaTime * particleSpeed;
			}
		if (canMove) {
			JamesLookAt ();
			}
		}
	}

	//uses the googled look at 
	void JamesLookAt(){
		Vector3 vectorToTarget = Target.transform.position - transform.position;
		float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
	
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

		transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * particleTurnSpeed);
	}

	public void setTargetAndCharge(GameObject newTarget,int inCharge){
		Target = newTarget;
		TargetSpotlightMovmentScpit = Target.GetComponent<SpotlightMovmentScpit> ();
		chargeOfparticle = inCharge;
	}

	public GameObject getTarget(){
		return Target;
	}

	void OnTriggerEnter2D(Collider2D c){

		if (c.tag =="PlayerSpotLight") {
			IsConsumed = true;
			TargetSpotlightMovmentScpit.addpower (chargeOfparticle * amountOfPowerHeld);//increment power of player


			Destroy (gameObject);
		}
	}



	IEnumerator activateMovement(){
		yield return new WaitForSeconds (0.01f);
		transform.rotation = new Quaternion (0f, 0f, transform.rotation.z, transform.rotation.w);

		yield return new WaitForSeconds (waitTimeforMovment);
		canMove = true;
	}

	public void setColourOfParticle(Color newCol){
		sr = GetComponent<SpriteRenderer>();
		sr.color = newCol;
	}
}
