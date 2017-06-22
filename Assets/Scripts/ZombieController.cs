using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {

	public float speed;				// How fast the zombie moves.

	private Transform playerTransform;		// The player that the zombies will follow.
	private Transform zombieTransform;		// The zombie's Transform.
	private Rigidbody2D zombieBody;			// The zombie's RigidBody2d
	private Animator zombieAnimator;		// The Animator attached to the zombie.

	private float attackCoolDown;			// The time it takes the zombie to attack

	// Use this for initialization
	void Start () {
		playerTransform = GameObject.Find ("Player").GetComponent<Transform> ();
		zombieTransform = GetComponent<Transform> ();
		zombieBody = GetComponent<Rigidbody2D> ();
		zombieAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {

		if (GetComponent<Entity> ().IsDead ())
			return;

		if (attackCoolDown > 0) {
			attackCoolDown -= Time.fixedDeltaTime;
			return;
		}

		zombieTransform.up = playerTransform.position - zombieTransform.position;		// Look at the player.

		if (Vector3.Distance (playerTransform.position, zombieTransform.position) > .75f) {
			zombieAnimator.Play ("Walk");
			Vector2 move = new Vector2 ();
			move.x = -1 * Mathf.Sin (zombieTransform.rotation.eulerAngles.z * Mathf.Deg2Rad) * speed;// * Time.fixedDeltaTime;
			move.y = Mathf.Cos (zombieTransform.rotation.eulerAngles.z * Mathf.Deg2Rad) * speed;// * Time.fixedDeltaTime;
			zombieBody.velocity = Vector2.ClampMagnitude (move, speed);
		} else {
			attackCoolDown = 1f;
			zombieBody.velocity = new Vector2 (0, 0);
			zombieAnimator.Play ("Attack");
		}
	}
		
}
