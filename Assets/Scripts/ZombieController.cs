using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {

	private Zombie zombie;					// The zombie that this controller controls. 
	private Transform playerTransform;		// The player that the zombies will follow.
	private Transform zombieTransform;		// The zombie's Transform.
	private Rigidbody2D zombieBody;			// The zombie's RigidBody2d
	private Animator zombieAnimator;		// The Animator attached to the zombie.

	private float attackCoolDown;			// The time it takes the zombie to attack
	private bool attacking;
	private bool inAttackRange;				// Whether or not the zombie is close enough to hit the player.

	// Use this for initialization
	void Start () {
		playerTransform = GameObject.Find ("Player").GetComponent<Transform> ();
		zombieTransform = GetComponent<Transform> ();
		zombieBody = GetComponent<Rigidbody2D> ();
		zombieAnimator = GetComponent<Animator> ();
		zombie = GetComponent<Zombie> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {

		if (GetComponent<Zombie> ().IsDead ()) {
			zombieBody.velocity = new Vector3 (0, 0, 0);
			return;
		}

		if (attackCoolDown > 0) {
			attackCoolDown -= Time.fixedDeltaTime;
			return;
		}

		zombieTransform.up = playerTransform.position - zombieTransform.position;		// Look at the player.

		if (Vector3.Distance (playerTransform.position, zombieTransform.position) > .75f) {
			zombieAnimator.Play ("Walk");
			Vector2 move = new Vector2 ();
			move.x = -1 * Mathf.Sin (zombieTransform.rotation.eulerAngles.z * Mathf.Deg2Rad) * zombie.speed;// * Time.fixedDeltaTime;
			move.y = Mathf.Cos (zombieTransform.rotation.eulerAngles.z * Mathf.Deg2Rad) * zombie.speed;// * Time.fixedDeltaTime;
			zombieBody.velocity = Vector2.ClampMagnitude (move, zombie.speed);
		} else {
			attackCoolDown = 1f;
			attacking = true;
			inAttackRange = true;
			zombieBody.velocity = new Vector2 (0, 0);
			zombieAnimator.Play ("Attack");
		}
	}

	public bool IsAttacking() {
		return attacking;
	}

	public bool InAttackRange() {
		return inAttackRange;
	}

	public void AttackRangeExited() {
		inAttackRange = false;
	}

	public void AttackPlayer() {
		Player p = playerTransform.GetComponent<Player> ();
		p.Damage (zombie.damage);
	}

	public void Log(string message) {
		print (message);
	}
}
