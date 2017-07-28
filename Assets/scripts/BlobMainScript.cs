using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobMainScript : MonoBehaviour {

	public float startSpeed;
	public float currentSpeed;
	public int pointAdder;

	//public int pointmultiplyer;//usefull pickup

	public float startSize;
	public float currentSize;

	public bool playerOwnedBy=true;//true1 false2 players

	Vector2 movement;

	public Rigidbody2D rb;
	//Debug.Log ("A");
	void Start () {
		rb = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		UpdateMovementInput ();
	}

	void UpdateMovementInput(){
		if (playerOwnedBy) {//player 
			if (Input.GetKey ("up")) {
				movement.y= 1;
			} 
			else if (Input.GetKey ("down")) {
				movement.y = -1;
			} else {
				movement.y = 0;
			}

			if (Input.GetKey ("left")) {
				movement.x = -1;
			} 
			else if (Input.GetKey ("right")) {
				movement.x = 1;
			} else {
				movement.x = 0;
			}

		} else {//player false
			if (Input.GetKey (KeyCode.W)) {
				movement.y= 1;
			} 
			else if (Input.GetKey (KeyCode.S)) {
				movement.y = -1;
			} else {
				movement.y = 0;
			}

			if (Input.GetKey (KeyCode.A)) {
				movement.x = -1;

			} 
			else if (Input.GetKey (KeyCode.D)) {
				movement.x = 1;
			} else {
				movement.x = 0;
			}

		}

		rb.AddForce(movement*currentSpeed);
	}

}
