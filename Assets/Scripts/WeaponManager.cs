using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

	public const int PISTOL = 0, RIFLE = 1, SHOTGUN = 2;
	public readonly int[] CLIP_SIZES = { 7, 30, 5 }; 

	public int currentGun;
	public int[] currentAmmo;
	public int[] totalAmmo;


	// Use this for initialization
	void Start () {
		currentAmmo = new int[3];
		totalAmmo = new int[3];
		currentAmmo [0] = CLIP_SIZES [0];
		totalAmmo [0] = 21;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
