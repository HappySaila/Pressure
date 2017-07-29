using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRandomSprite : MonoBehaviour {
	public Sprite[] sprites;
	// Use this for initialization
	void Start () {
		GetComponent <SpriteRenderer>().sprite = sprites[Random.Range (0, sprites.Length)];
		GetComponent <Animator>().speed = Random.Range (0.5f, 2f);
	}
	
}
