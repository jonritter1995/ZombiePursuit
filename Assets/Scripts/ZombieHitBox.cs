using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHitBox : MonoBehaviour {

	ZombieController zc;

	// Use this for initialization
	void Start () {
		zc = GetComponent<Transform> ().parent.GetComponent<ZombieController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		
	}

	void OnTriggerStay2D(Collider2D other) {
		
	}

	void OnTriggerExit2D(Collider2D other) {
		if (zc.IsAttacking ()) {
			if (other.gameObject.tag == "Player") {
				zc.AttackRangeExited ();
			}
		}
	}
}
