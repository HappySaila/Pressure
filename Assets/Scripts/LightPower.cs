using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPower : MonoBehaviour {
	public float moveSpeed;
	public float fadeSpeed;
	public int timeToDie;

	Vector3 destination;
	Rigidbody2D rigid;
	SpriteRenderer sprite;

	public Color WhiteColor;
	public Color GreenColor;
	public Color PurpleColor;


	int state;


	// Use this for initialization
	void Start () {
		rigid = GetComponent <Rigidbody2D> ();
		sprite = GetComponent <SpriteRenderer> ();

		moveSpeed = Random.Range (moveSpeed, moveSpeed * 2);
		rigid.velocity = destination - transform.position;
		rigid.velocity = rigid.velocity.normalized * moveSpeed;
		timeToDie = Random.Range (timeToDie, timeToDie * 2);
		Invoke ("Die", timeToDie);

		SetDestination (SpotLightManager.Instance.Origin.position);
		SetState (Random.Range (1, 3));
	}

	void Die(){
		//light must fade out and dissappear
		StartCoroutine (FadeOut ());
	}

	IEnumerator FadeOut(){
		yield return new WaitForSeconds (0.01f);
		sprite.color = new Color (sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a - fadeSpeed * Time.deltaTime);
		if (sprite.color.a <= 0){
			Destroy (gameObject); 
		} else {
			StartCoroutine (FadeOut ());
		}
	}

	public void SetState(int state){
		this.state = state;
		switch (this.state) {
		case 2:
			sprite.color = new Color (PurpleColor.r, PurpleColor.g, PurpleColor.b, sprite.color.a);
			gameObject.tag = "purplePlate";
			break;
		case 1:
			sprite.color = new Color(GreenColor.r, GreenColor.g, GreenColor.b, sprite.color.a);
			gameObject.tag = "greanPlate";
			break;
		
		}
	}

	public void SetDestination(Vector3 destination){
		Vector3 velocityDirection = destination - transform.position;
		velocityDirection = Quaternion.AngleAxis(Random.Range (-45, 45), Vector3.forward) * velocityDirection;
		rigid.velocity = velocityDirection;
		rigid.velocity = rigid.velocity.normalized * moveSpeed;
	}

	//effects blobs
	void OnTriggerEnter2D(Collider2D blobTouched){
		if (blobTouched.tag == "Blob") {
			sittingBlobScript blobTouchedScript = blobTouched.gameObject.GetComponentInChildren<sittingBlobScript> ();
			blobTouchedScript.setState (state);
		}
	}
}
