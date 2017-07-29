using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour {
	public float size;
	CircleCollider2D collider;
	public Light spotLight;
	public Light spotLightPointer;
	// Use this for initialization
	void Start () {
		collider = GetComponent <CircleCollider2D> ();

		float ratio = 1.5f / Mathf.Abs((spotLightPointer.transform.position.x - spotLight.transform.position.x ));

		transform.position += -Vector3.forward * (size - 5);
		collider.radius = (float) (size * System.Math.Tan (Mathf.Deg2Rad * spotLight.spotAngle/2));

		collider.radius -= collider.radius * 0.2f;
		float newX = collider.radius / ratio;

		spotLightPointer.transform.position = spotLight.transform.position + new Vector3 (newX,0,0);
			
		spotLight.intensity = size/2;
	}
	
}
