using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

	public int health;
	public int speed;
	protected Animator particleAnim;
	protected Animator entityAnim;
	protected bool dead;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

	}

	public virtual void Damage(int damage) {
		if (dead)
			return;
		
		health -= damage;

		if (health <= 0) {
			Kill ();
		}
	}

	public virtual void Kill() {
		dead = true;
		GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, 0, 0);
		//entityAnim.Play ("Death");
	}

	public bool IsDead() {
		return dead;
	}
}
