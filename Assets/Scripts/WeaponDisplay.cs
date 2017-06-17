using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour {

	private Image currentWeapon;
	private WeaponManager wm;

	public Sprite[] weaponSprites;

	// Use this for initialization
	void Start () {
		currentWeapon = GetComponent<Image> ();
		wm = GameObject.Find ("Player").GetComponent<WeaponManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		currentWeapon.sprite = weaponSprites [wm.currentGun];
	}
}
