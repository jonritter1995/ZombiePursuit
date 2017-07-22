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
		if (other.gameObject.name.ToLower ().Contains ("zombie"))
			other.GetComponent<Zombie> ().Damage (damage);
		else if (other.GetComponent<Transform> ().parent.gameObject.name.ToLower ().Contains ("zombie"))
			return;
		else if (other.gameObject != this.gameObject)
			Instantiate (spark, GetComponent<Transform> ().position, GetComponent<Transform>().rotation);
		
		Destroy (gameObject);
	}

	void OnTriggerStay2D(Collider2D other) {

	}

	void OnTriggerExit2D(Collider2D other) {

	}
}
