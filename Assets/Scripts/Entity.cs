using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

	public int health;
	private Animator particleAnim;
	private Animator entityAnim;
	bool dead;
	float animTimer;

	// Use this for initialization
	void Start () {
		particleAnim = GetComponent<Transform> ().GetChild (0).GetComponent<Animator> ();
		entityAnim = GetComponent<Animator> ();
		dead = false;
	}

	// Update is called once per frame
	void Update () {
		if (dead) {
			animTimer -= Time.deltaTime;
			if (animTimer <= 0)
				Destroy (gameObject);
		}
	}

	public void Damage(int damage) {
		if (dead)
			return;
		health -= damage;
		particleAnim.Play ("blood");
		if (health <= 0) {
			Kill ();
		}
	}

	public void Kill() {
		entityAnim.Play ("Death");
		dead = true;
		foreach (AnimationClip c in entityAnim.runtimeAnimatorController.animationClips) {
			if (c.name == "Death") {
				animTimer = c.length;
				break;
			}
		}
	}

	public bool IsDead() {
		return dead;
	}
}
