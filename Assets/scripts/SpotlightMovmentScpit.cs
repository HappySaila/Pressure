
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightMovmentScpit	 : MonoBehaviour {


	public float currentSpeed;
	public float currentPowerLevel;
	public bool player1;

	Vector2 movement;

	private Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		
		UpdatePlayerMovement ();
	}
	void UpdatePlayerMovement(){
		if (player1) {//player true
			if (Input.GetKey ("up")) {
				movement.y = 1;
			} else if (Input.GetKey ("down")) {
				movement.y = -1;
			} else {
				movement.y = 0;
			}

			if (Input.GetKey ("left")) {
				movement.x = -1;
			} else if (Input.GetKey ("right")) {
				movement.x = 1;
			} else {
				movement.x = 0;
			}

		} else {//player false
			if (Input.GetKey (KeyCode.W)) {
				movement.y = 1;
			} else if (Input.GetKey (KeyCode.S)) {
				movement.y = -1;
			} else {
				movement.y = 0;
			}

			if (Input.GetKey (KeyCode.A)) {
				movement.x = -1;

			} else if (Input.GetKey (KeyCode.D)) {
				movement.x = 1;
			} else {
				movement.x = 0;
			}

		}

		rb.velocity = movement.normalized * currentSpeed * Time.deltaTime;
		if (movement.magnitude != 0){
			float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

			transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 5);
		}
	}

	public void addpower(float amount){
		currentPowerLevel += amount;
	}

	void OnTriggerStay2D(Collider2D c){
		
		if (c.tag == "Blob") {

			sittingBlobScript CaptureBlobScript=c.gameObject.GetComponent<sittingBlobScript>();
			if(player1){
				CaptureBlobScript.Captured (1);
			}
			else{
				CaptureBlobScript.Captured (2);
			}

		}
	}


}

