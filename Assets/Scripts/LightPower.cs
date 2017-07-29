using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPower : MonoBehaviour {
	public float moveSpeed;
	public float fadeSpeed;
	[Range(3,6)]public float size;
	public int timeToDie;
	Vector3 destination;
	CircleCollider2D collider;
	Rigidbody2D rigid;
	Light spotLight;
	public Color WhiteColor;
	public Color GreenColor;
	public Color PurpleColor;

	public enum LightState{
		GREEN, PURPLE, WHITE
	};
	LightState state;


	// Use this for initialization
	void Start () {
		rigid = GetComponent <Rigidbody2D> ();
		collider = GetComponent <CircleCollider2D> ();
		moveSpeed = Random.Range (moveSpeed, moveSpeed * 2);
		rigid.velocity = destination - transform.position;
		rigid.velocity = rigid.velocity.normalized * moveSpeed;
		timeToDie = Random.Range (timeToDie, timeToDie * 2);
		Invoke ("Die", timeToDie);
		spotLight = GetComponentInChildren <Light> ();
		SetColor ();
		SetDestination (SpotLightManager.Instance.Origin.position);
		transform.position += -Vector3.forward * (size - 5);
		collider.radius = (float) (size * System.Math.Tan (Mathf.Deg2Rad * spotLight.spotAngle/2));
		spotLight.intensity = size/2;
	}

	void SetColor(){
		switch (Random.Range (0, 3)) {
		case 0:
			SetState (LightState.WHITE);
			break;
		case 1:
			SetState (LightState.GREEN);
			break;
		case 2:
			SetState (LightState.PURPLE);
			break;
		}
	}

	void Update(){
		
	}


	void Die(){
		//light must fade out and dissappear
		StartCoroutine (FadeOut ());
	}

	IEnumerator FadeOut(){
		yield return new WaitForSeconds (0.01f);
		spotLight.intensity -= fadeSpeed * Time.deltaTime;
		if (spotLight.intensity <= 0){
			Destroy (gameObject); 
		} else {
			StartCoroutine (FadeOut ());
		}
	}

	public void SetState(LightState state){
		this.state = state;
		switch (this.state) {
		case LightState.WHITE:
			spotLight.color = WhiteColor;
			break;
		case LightState.GREEN:
			spotLight.color = GreenColor;
			break;
		case LightState.PURPLE:
			spotLight.color = PurpleColor;
			break;
		}
	}

	public void SetDestination(Vector3 destination){
		Vector3 velocityDirection = destination - transform.position;
		velocityDirection = Quaternion.AngleAxis(Random.Range (-45, 45), Vector3.forward) * velocityDirection;
		rigid.velocity = velocityDirection;
		rigid.velocity = rigid.velocity.normalized * moveSpeed;
	}
			

	
}
