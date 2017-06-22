using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

	public const int PISTOL = 0, RIFLE = 1, SHOTGUN = 2;	// id's for weapons.
	public readonly int[] CLIP_SIZES = { 7, 30, 5 }; 		// max ammo per clip.
	public readonly int[] FIRE_RATES = { 20, 10, 45 };		// min # of frames between shots.
	public const int WEAPON_CHANGE_SPEED = 60;				// min # of frames it takes to switch weapons.
	public readonly int[] RELOAD_SPEEDS = { 60, 100, 140 };

	public int currentGun;									// The gun the player is currently using.
	public int[] currentAmmo;								// The ammount of ammo in the current clip.
	public int[] totalAmmo;									// The amount of ammo not in the current clip.

	private bool firing;
	private int cdCounter;
	private int reloadCounter;

	public GameObject[] bullets;
	public GameObject[] bulletLocations;
	private Transform playerTransform;

	private Animator muzzleAnim;


	// Use this for initialization
	void Start () {
		playerTransform = GetComponent<Transform> ();
		cdCounter = 1000;
		reloadCounter = 1000;
	}
	
	// Update is called once per frame
	void Update () {
			
	}

	void FixedUpdate() {
		
		// Stop incrementing to avoid overflow.
		if (cdCounter < 10000)
			cdCounter++;

		if (reloadCounter < 10000)
			reloadCounter++;

		if (reloadCounter < RELOAD_SPEEDS [currentGun]) {
			return;
		}

		// Clip empty.
		if (firing && currentAmmo[currentGun] <= 0) {
			Reload ();
			return;
		}

		// Inbetween shots - not enough time since last bullet fired.
		if (firing && cdCounter < FIRE_RATES [currentGun])
			return;
		
		// fire projectile based on weapon
		if (firing) {
			cdCounter = 0;
			currentAmmo [currentGun]--;

			Quaternion bulletRot = Quaternion.Euler (new Vector3 (playerTransform.rotation.eulerAngles.x, playerTransform.rotation.eulerAngles.y, playerTransform.eulerAngles.z - 90));
			Vector3 bulletLoc = bulletLocations [currentGun].GetComponent<Transform> ().position;
			GameObject[] projectiles = (currentGun == SHOTGUN) ? new GameObject[3] : new GameObject[1];

			for (int i = 0; i < projectiles.Length; i++) {
				projectiles[i] = Instantiate (bullets [currentGun], bulletLoc, bulletRot ) as GameObject;
				if (i > 0) {
					projectiles [i].GetComponent<Transform> ().position = projectiles [0].GetComponentsInChildren<Transform> () [i].position;
					projectiles [i].GetComponent<Transform> ().rotation = projectiles [0].GetComponentsInChildren<Transform> () [i].rotation;
				}
				projectiles[i].GetComponent<Rigidbody2D> ().velocity = projectiles[i].transform.up * 10;
			}

			muzzleAnim = GetComponent<Transform> ().GetChild (currentGun).GetChild (0).GetComponent<Animator> ();
			muzzleAnim.Play ("Muzzle Flash");
		}
	}

	private void Reload() {
		reloadCounter = 0;
		if (totalAmmo [currentGun] >= CLIP_SIZES [currentGun]) {
			totalAmmo [currentGun] -= CLIP_SIZES [currentGun];
			currentAmmo [currentGun] = CLIP_SIZES [currentGun];
		} else if (totalAmmo [currentGun] > 0) {
			currentAmmo [currentGun] = totalAmmo[currentGun];
			totalAmmo [currentGun] = 0;
		}
	}

	public void PointerDown() {
		firing = true;	
	}

	public void PointerUp() {
		firing = false;
	}
}
