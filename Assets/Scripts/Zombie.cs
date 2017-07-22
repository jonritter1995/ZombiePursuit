using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Entity {

	public int damage;					// How much damage this zombie's attacks do.

	// Use this for initialization
	void Start () {
		entityAnim = GetComponent<Animator> ();
		particleAnim = GetComponent<Transform> ().GetChild (0).GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	public override void Damage(int damage) {
		base.Damage (damage);

		if (!dead) {
			particleAnim.Play ("blood");
		}
			
	}

	public override void Kill() {
		GetComponent<CircleCollider2D> ().enabled = false;
		base.Kill ();
	}
}
