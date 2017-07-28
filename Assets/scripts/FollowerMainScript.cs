using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerMainScript : MonoBehaviour {


	public float currentSpeed;

	public int pointAdder;
	public float currentSize;

	public GameObject owner;
	public float idleDistance;

	public float turnspeed;


	private Rigidbody2D rb;

	public float RandumRangeMultiplyer;
	private Vector3 RandumVectorToAddToOwnerPosition;
	private Vector3 RandumVectorPositionIdle;
	bool isidle=false;

	bool canMove ;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
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

	public void callStartMoving(){
		StartCoroutine (startMoving());
	}

	IEnumerator startMoving(){
		yield return new WaitForSeconds (1);
		canMove = true;
	}
}
