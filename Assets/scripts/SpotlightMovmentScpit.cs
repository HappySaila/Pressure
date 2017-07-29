
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightMovmentScpit	 : MonoBehaviour {


	public float currentSpeed;
	public int pointAdder;

	public float currentSize;

	public bool playerOwnedBy=true;//true1 false2 players

	Vector2 movment;

	public Rigidbody2D rb;
	//Debug.Log ("A");
	void Start () {
		rb = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		
		if (playerOwnedBy) {//player true
			if (Input.GetKey ("up")) {
				movment.y= 1;
			} 
			else if (Input.GetKey ("down")) {
				movment.y = -1;
			} else {
				movment.y = 0;
			}

			if (Input.GetKey ("left")) {
				movment.x = -1;

			} 
			else if (Input.GetKey ("right")) {
				movment.x = 1;
			} else {
				movment.x = 0;
			}

		} else {//player false
			if (Input.GetKey (KeyCode.W)) {
				movment.y= 1;
			} 
			else if (Input.GetKey (KeyCode.S)) {
				movment.y = -1;
			} else {
				movment.y = 0;
			}

			if (Input.GetKey (KeyCode.A)) {
				movment.x = -1;

			} 
			else if (Input.GetKey (KeyCode.D)) {
				movment.x = 1;
			} else {
				movment.x = 0;
			}

		}

		rb.AddForce(movment*Time.deltaTime*currentSpeed);
	}
}

