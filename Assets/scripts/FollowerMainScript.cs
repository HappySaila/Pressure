using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerMainScript : MonoBehaviour {

	public float startSpeed;
	public float currentSpeed;

	public int pointAdder;

	public float startSize;
	public float currentSize;

	public GameObject owner;
	public float idleDistance;



	private Rigidbody2D rb;

	public float RandumRangeMultiplyer;
	private Vector3 RandumVectorToAddToOwnerPosition;
	private Vector3 RandumVectorPositionIdle;
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		RandumVectorToAddToOwnerPosition = new Vector3 ( Random.Range (-1.0f * RandumRangeMultiplyer, 1.0f * RandumRangeMultiplyer), Random.Range (-1.0f * RandumRangeMultiplyer, 1.0f * RandumRangeMultiplyer),0.0f);

	}
	

	void Update () {
		//RandumVectorToAddToOwnerPositionCHANGER = new Vector3 ( Random.Range (-0.1f * RandumRangeMultiplyer, 0.1f * RandumRangeMultiplyer), Random.Range (-0.1f * RandumRangeMultiplyer, 0.1f * RandumRangeMultiplyer),0.0f);
	//	RandumVectorToAddToOwnerPosition = RandumVectorToAddToOwnerPosition + RandumVectorToAddToOwnerPositionCHANGER;
		//Debug.Log (RandumVectorToAddToOwnerPosition);
		if (idleDistance > Vector2.Distance (transform.position, owner.transform.position)) {
			//idle
			RandumVectorPositionIdle = new Vector3 ( Random.Range (-1.0f * RandumRangeMultiplyer, 1.0f * RandumRangeMultiplyer), Random.Range (-1.0f * RandumRangeMultiplyer, 1.0f * RandumRangeMultiplyer),0.0f);

			//transform.position = Vector2.Lerp(transform.position ,(transform.position + RandumVectorToAddToOwnerPosition),0.01f);
			//rb.velocity=Vector2.Lerp(transform.position ,(transform.position + RandumVectorToAddToOwnerPosition),Time.deltaTime*0.01f);

		} else {

			//transform.position = Vector2.Lerp(transform.position ,(owner.transform.position + RandumVectorToAddToOwnerPosition),0.01f);
			//rb.velocity=Vector2.Lerp(transform.position ,(owner.transform.position + RandumVectorToAddToOwnerPosition),0.01f);
		}

		//transform.LookAt (Vector3.Lerp(transform.up,(owner.transform.up-transform.up),Time.deltaTime*0.1f));
		transform.LookAt(owner.transform,Vector2.left);
		//Vector2 td = (owner.transform.up-transform.up);
		//Vector2 lerp= Vector2.Lerp(transform.up,td,Time.deltaTime*0.1f);
		//transform.LookAt(
	}
}
