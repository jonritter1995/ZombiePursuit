using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public int damage;
	public GameObject spark;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		try {
			other.GetComponent<Entity> ().Damage (damage);
		}
		catch (Exception ex) {
			GameObject toDestroy = Instantiate (spark, GetComponent<Transform> ().position, GetComponent<Transform>().rotation);
			Destroy (gameObject);
		}
		Destroy (gameObject);
	}

	void OnTriggerStay2D(Collider2D other) {

	}

	void OnTriggerExit2D(Collider2D other) {

	}
}
